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

namespace Client.Logic.Graphics.Renderers.Sprites
{
    public class Emoticon
    {
        public int EmoteIndex { get; set; }

        public int EmoteSpeed { get; set; }

        public int EmoteTime { get; set; }

        public int EmoteFrame { get; set; }

        public int EmoteCycles { get; set; }

        public int CurrentCycle { get; set; }

        public Emoticon(int index, int speed, int cycles)
        {
            EmoteIndex = index;
            EmoteSpeed = speed;
            EmoteCycles = cycles;
        }
    }
}
