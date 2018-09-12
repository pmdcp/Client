using System;
using System.Collections.Generic;
using System.Text;
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


namespace Client.Logic.IO
{
    class Paths
    {
        #region Fields

        /// <summary>
        /// Directory seperator character used by the OS.
        /// </summary>
        static char dirChar = System.IO.Path.DirectorySeparatorChar;
        static string fontPath;
        static string gfxPath;
        static string mapPath;
        static string musicPath;
        static string sfxPath;
        static string skinPath;
        static string startupPath;
        static string storyDataPath;

        #endregion Fields

        #region Properties

        public static char DirChar
        {
            get { return dirChar; }
        }

        public static string FontPath
        {
            get { return fontPath; }
        }

        public static string StoryDataPath
        {
            get { return storyDataPath; }
        }

        public static string GfxPath
        {
            get { return gfxPath; }
        }

        public static string MapPath
        {
            get { return mapPath; }
        }

        public static string MusicPath
        {
            get { return musicPath; }
        }

        public static string SfxPath
        {
            get { return sfxPath; }
        }

        public static string SkinPath
        {
            get { return skinPath; }
        }

        public static string StartupPath
        {
            get { return startupPath; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates a file path in the format used by the host OS.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>A file path in the format used by the host OS</returns>
        public static string CreateOSPath(string fileName)
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                if (fileName.Contains("\\"))
                    fileName = fileName.Replace('\\', dirChar);
            }
            else if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                if (fileName.Contains("/"))
                    fileName = fileName.Replace('/', dirChar);
            }
            if (fileName.StartsWith(StartupPath) == false)
            {
                fileName = StartupPath + fileName;
            }
            return fileName;
        }

        /// <summary>
        /// Initializes this class
        /// </summary>
        public static void Initialize()
        {
            Paths.startupPath = System.Windows.Forms.Application.StartupPath;
            //#if DEBUG
            if (/*Globals.InDebugMode &&*/ Globals.CommandLine.ContainsCommandArg("-overridepath"))
            {
                int index = Globals.CommandLine.FindCommandArg("-overridepath");
                Paths.startupPath = Globals.CommandLine.CommandArgs[index + 1];
            }
            //#endif
            Paths.startupPath = System.IO.Path.GetFullPath(Paths.startupPath);
            if (Paths.startupPath.EndsWith(dirChar.ToString()) == false)
                Paths.startupPath += dirChar;

            Paths.gfxPath = Paths.StartupPath + "GFX" + dirChar;
            Paths.skinPath = Paths.StartupPath + "Skins" + dirChar;
            Paths.fontPath = Paths.StartupPath + "Fonts" + dirChar;
            Paths.mapPath = Paths.StartupPath + "MapData" + dirChar;
            Paths.musicPath = Paths.StartupPath + "Music" + dirChar;
            Paths.sfxPath = Paths.StartupPath + "SFX" + dirChar;
            Paths.storyDataPath = Paths.StartupPath + "Story" + dirChar;
        }

        #endregion Methods
    }
}