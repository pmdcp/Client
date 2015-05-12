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
using PMDCP.Core;
using SdlDotNet.Graphics;

namespace Client.Logic.Graphics
{
    public class TileGraphic : ICacheable
    {
        int sizeInBytes;
        Surface tile;
        int tileSet;
        int tileNum;

        public TileGraphic(int tileSet, int tileNum, Surface tile, int sizeInBytes) {
            this.tileSet = tileSet;
            this.tileNum = tileNum;
            this.tile = tile;
            this.sizeInBytes = sizeInBytes;
        }

        public Surface Tile {
            get {
                return tile;
            }
        }

        public int TileSet {
            get { return tileSet; }
        }

        public int TileNum {
            get { return tileNum; }
        }

        public int BytesUsed {
            get { return sizeInBytes; }
        }
    }
}
