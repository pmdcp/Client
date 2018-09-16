﻿using System;
using System.Collections.Generic;
using System.Text;

using SdlDotNet.Graphics;
using SdlDotNet.Widgets;
using System.Drawing;
using System.IO;
using System.Xml;
using System.IO.Compression;
// This file is part of Mystery Dungeon eXtended.

// Copyright (C) 2015 Pikablu, MDX Contributors, PMU Staff

// Mystery Dungeon eXtended is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Mystery Dungeon eXtended is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with Mystery Dungeon eXtended.  If not, see <http://www.gnu.org/licenses/>.


namespace Client.Logic.Skins
{
    class SkinManager
    {
        #region Fields

        static Skin activeSkin;
        static Surface screenBackground;

        #endregion Fields

        #region Properties

        public static Surface ScreenBackground
        {
            get { return screenBackground; }
            set { screenBackground = value; }
        }

        public static Skin ActiveSkin
        {
            get { return activeSkin; }
        }

        #endregion Properties

        #region Methods

        public static void ChangeActiveSkin(string skinName)
        {
            if (activeSkin != null)
            {
                activeSkin.Unload();
            }
            activeSkin = new Skin();
            activeSkin.LoadSkin(skinName);
            IO.Options.ActiveSkin = skinName;
            if (screenBackground != null)
            {
                screenBackground.Close();
                screenBackground = null;
            }
            screenBackground = LoadGui("General/Background");
            if (screenBackground != null)
            {
                //lock (screenBackground) {
                //    screenBackground = screenBackground.CreateStretchedSurface(SdlDotNet.Graphics.Video.Screen.Size);
                //}
            }
            SdlDotNet.Widgets.Widgets.ResourceDirectory = IO.Paths.SkinPath + ActiveSkin.Name + "/Widgets/";
        }

        public static void PlaySkinMusic()
        {
            //Music.Music.AudioPlayer.PlayMusic("Title.ogg");
            //string activeSkinMusicFile = Music.Music.AudioPlayer.FindMusicFile(Skins.SkinManager.GetActiveSkinFolder() + "Music/", "Title");
            //if (!string.IsNullOrEmpty(activeSkinMusicFile)) {
            //    Music.Music.AudioPlayer.PlayMusicDirect(activeSkinMusicFile, -1, false, true);
            //} else {
            //    Music.Music.AudioPlayer.PlayMusic("Title.ogg");
            //}
            string activeSkinMusicFile = Music.AudioHelper.FindMusicFile(Skins.SkinManager.GetActiveSkinFolder() + "Music/", "Title");
            if (!string.IsNullOrEmpty(activeSkinMusicFile))
            {
                Music.Music.AudioPlayer.PlayMusic(activeSkinMusicFile, -1, false, true);
            }
            else
            {
                Music.Music.AudioPlayer.PlayMusic("PMD3) Title.ogg");
            }
        }

        public static Surface LoadGui(string guiToLoad)
        {
            if (IO.IO.FileExists("Skins/" + ActiveSkin.Name + "/" + guiToLoad + "/gui.png"))
            {
                Surface surf = Logic.Graphics.SurfaceManager.LoadSurface("Skins/" + ActiveSkin.Name + "/" + guiToLoad + "/gui.png");
                Surface surf2 = surf.Convert();
                surf2.Transparent = true;
                surf.Close();
                return surf2;
            }
            return null;
        }

        public static Surface LoadGuiElement(string guiToLoad, string elementName)
        {
            return LoadGuiElement(guiToLoad, elementName, true);
        }

        public static Surface LoadGuiElement(string guiToLoad, string elementName, bool convert)
        {
            if (IO.IO.FileExists("Skins/" + ActiveSkin.Name + "/" + guiToLoad + "/" + elementName))
            {
                Surface surf = Logic.Graphics.SurfaceManager.LoadSurface("Skins/" + ActiveSkin.Name + "/" + guiToLoad + "/" + elementName);
                if (convert)
                {
                    Surface surf2 = surf.Convert();
                    surf2.Transparent = true;
                    surf.Close();
                    return surf2;
                }
                else
                {
                    return surf;
                }
            }
            return null;
        }

        public static void LoadButtonGui(SdlDotNet.Widgets.Button button)
        {
            button.BackColor = Color.Transparent;
            button.BackgroundImageSizeMode = ImageSizeMode.StretchImage;
            button.BorderStyle = BorderStyle.None;
            button.BackgroundImage = Skins.SkinManager.LoadGuiElement("Game Window", "Widgets/button.png");
            button.HighlightType = HighlightType.Image;
            Surface unstretchedHoverImage = Skins.SkinManager.LoadGuiElement("Game Window", "Widgets/button-h.png");
            button.HighlightSurface = unstretchedHoverImage.CreateStretchedSurface(button.Size);
            unstretchedHoverImage.Close();
        }

        public static void LoadTextBoxGui(SdlDotNet.Widgets.TextBox textBox)
        {
            textBox.BackColor = Color.Transparent;
            textBox.ForeColor = Color.WhiteSmoke;
            textBox.BackgroundImageSizeMode = ImageSizeMode.StretchImage;
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackgroundImage = Skins.SkinManager.LoadGuiElement("Game Window", "Widgets/textbox.png");
        }

        public static string GetActiveSkinFolder()
        {
            return IO.Paths.SkinPath + ActiveSkin.Name + "/";
        }

        public static bool InstallSkin(string skinPackagePath)
        {
            try
            {
                using (var fileStream = new FileStream(skinPackagePath, FileMode.Open))
                {
                    using (var zip = new ZipArchive(fileStream))
                    {
                        bool skinValid = false;
                        foreach (var entry in zip.Entries)
                        {
                            if (entry.Name == "Configuration/config.xml")
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    using (var entryStream = entry.Open())
                                    {
                                        entryStream.CopyTo(ms);
                                    }
                                    ms.Seek(0, SeekOrigin.Begin);
                                    skinValid = ValidateSkinConfigEntry(ms);
                                }
                                break;
                            }
                        }
                        if (skinValid)
                        {
                            string skinDir = IO.Paths.SkinPath + Path.GetFileNameWithoutExtension(skinPackagePath);
                            if (Directory.Exists(skinDir) == false)
                            {
                                Directory.CreateDirectory(skinDir);
                            }

                            ZipFile.ExtractToDirectory(skinPackagePath, skinDir);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private static bool ValidateSkinConfigEntry(MemoryStream configStream)
        {
            string creator = null;
            string version = null;
            using (XmlReader reader = XmlReader.Create(configStream))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "Creator":
                                {
                                    creator = reader.ReadString();
                                }
                                break;
                            case "Version":
                                {
                                    version = reader.ReadString();
                                }
                                break;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(creator) && !string.IsNullOrEmpty(version))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Methods
    }
}