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


using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Logic.Music
{
    class AudioHelper
    {
        public static string FindMusicFile(string folder, string songName)
        {
            string[] extensions = new string[] { ".mp3", ".ogg", ".wav" };
            for (int i = 0; i < extensions.Length; i++)
            {
                if (System.IO.File.Exists(folder + songName + extensions[i]))
                {
                    return folder + songName + extensions[i];
                }
            }
            return null;
        }

        public static string FileNameConverter(string directory, string fileToTest)
        {
            if (System.IO.File.Exists(directory + fileToTest))
            {
                return fileToTest;
            }
            else if (System.IO.File.Exists(directory + System.IO.Path.ChangeExtension(fileToTest, ".ogg")))
            {
                return System.IO.Path.ChangeExtension(fileToTest, ".ogg");
            }
            else
            {
                return fileToTest;
            }
        }
    }
}
