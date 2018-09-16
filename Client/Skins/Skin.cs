﻿// This file is part of Mystery Dungeon eXtended.

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


using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using SdlDotNet.Graphics;

namespace Client.Logic.Skins
{
    class Skin
    {
        string name;
        string creator;
        string version;
        Surface ingameBackground;

        public Surface IngameBackground
        {
            get { return ingameBackground; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Creator
        {
            get { return creator; }
        }

        public string Version
        {
            get { return version; }
        }

        public void LoadSkin(string name)
        {
            this.name = name;

            string configPath = IO.Paths.SkinPath + name + "/Configuration/";
            if (System.IO.Directory.Exists(configPath) == false)
            {
                System.IO.Directory.CreateDirectory(configPath);
            }

            LoadConfigXml(configPath + "config.xml");

            ingameBackground = SkinManager.LoadGui("Game Window");
        }

        private void LoadConfigXml(string fullPath)
        {
            if (!IO.IO.FileExists(fullPath))
            {
                SaveEmptyConfigFile(fullPath);
            }
            using (XmlReader reader = XmlReader.Create(fullPath))
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
        }

        private void SaveEmptyConfigFile(string fullPath)
        {
            using (XmlWriter writer = XmlWriter.Create(fullPath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("SkinConfiguration");

                writer.WriteStartElement("General");

                writer.WriteElementString("Creator", "");
                writer.WriteElementString("Version", "");

                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public void Unload()
        {
            if (ingameBackground != null)
            {
                ingameBackground.Close();
            }
        }
    }
}
