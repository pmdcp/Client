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


/*
 * Created by SharpDevelop.
 * User: Pikachu
 * Date: 27/09/2009
 * Time: 11:15 PM
 * 
 */
using System;

namespace Client.Logic.Stories
{
    /// <summary>
    /// Global variables for stories
    /// </summary>
    internal class Globals
    {
        public static bool PlayersHidden { get; set; }
        public static bool NpcsHidden { get; set; }
        public static bool IsScrolling { get; set; }
        public static int ScrollCurrentX { get; set; }
        public static int ScrollCurrentY { get; set; }
        public static int ScrollEndX { get; set; }
        public static int ScrollEndY { get; set; }
        public static int LastScroll { get; set; }
        public static int ScrollSpeed { get; set; }
    }
}
