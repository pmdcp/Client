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

namespace Client.Logic.Maps
{
    class DungeonRoom
    {
         #region Fields

        int height;
        int width;
        int x;
        int y;

        #endregion Fields

        #region Constructors

        public DungeonRoom(int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        #endregion Constructors

        #region Properties

        public int Height {
            get { return height; }
            set { height = value; }
        }

        public int Width {
            get { return width; }
            set { width = value; }
        }

        public int X {
            get { return x; }
            set { x = value; }
        }

        public int Y {
            get { return y; }
            set { y = value; }
        }

        #endregion Properties

        public bool IsInRoom(int x, int y) {
            return true;
            return (
               x >= this.x &&
               y >= this.y &&
               x - this.x <= this.width &&
               y - this.y <= this.height
               );
        }
    }
}
