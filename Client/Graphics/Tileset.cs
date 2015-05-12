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
using System.Drawing;
using System.IO;
using PMDCP.Core;
using SdlDotNet.Graphics;

namespace Client.Logic.Graphics
{
    class Tileset : LRUCache<int, TileGraphic>
    {
        int tileCount;
        int tileSetNumber;
        Size size;
        string filePath;
        Object lockObject = new object();

        long headerSize;
        long[] tilePositionCache;
        int[] tileSizeCache;

        public Size Size {
            get { return this.size; }
        }

        public int TilesetNumber {
            get { return tileSetNumber; }
        }

        public int TileCount {
            get { return tileCount; }
        }

        public Tileset(int tileSetNumber, int maxCacheSize)
            : base(maxCacheSize) {
            this.tileSetNumber = tileSetNumber;
            size = new Size();
        }

        public long GetTilePosition(int index)
        {
            return tilePositionCache[index] + headerSize;
        }

        public void Load(string filePath) {
            this.filePath = filePath;
            // File format:
            // [tileset-width(4)][tileset-height(4)][tile-count(4)]
            // [tileposition-1(4)][tilesize-1(4)][tileposition-2(4)][tilesize-2(4)][tileposition-n(n*4)][tilesize-n(n*4)]
            // [tile-1(variable)][tile-2(variable)][tile-n(variable)]
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Read tileset width
                    this.size.Width = reader.ReadInt32();
                    // Read tileset height
                    this.size.Height = reader.ReadInt32();

                    this.tileCount = (size.Width / Constants.TILE_WIDTH) * (size.Height / Constants.TILE_HEIGHT);

                    // Prepare tile information cache
                    this.tilePositionCache = new long[tileCount];
                    this.tileSizeCache = new int[tileCount];

                    // Load tile information
                    for (int i = 0; i < tileCount; i++)
                    {
                        // Read tile position data
                        this.tilePositionCache[i] = reader.ReadInt64();
                        // Read tile size data
                        this.tileSizeCache[i] = reader.ReadInt32();
                    }
                    headerSize = stream.Position;
                }
            }
            SetupInitialDataFromTile(0);
        }

        private void SetupInitialDataFromTile(int tileNumber) {

            byte[] tileBytes = new byte[tileSizeCache[tileNumber]];
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                // Seek to the location of the tile
                stream.Seek(GetTilePosition(tileNumber), SeekOrigin.Begin);
                stream.Read(tileBytes, 0, tileBytes.Length);
            }
            using (MemoryStream stream = new MemoryStream(tileBytes))
            {
                Bitmap bitmap = (Bitmap)Image.FromStream(stream);
                Surface tileSurface = new Surface(bitmap);

                tileSurface.Transparent = true;
                int rawSurfaceSize = tileSurface.Width * tileSurface.Height * tileSurface.BitsPerPixel / 8;
                TileGraphic tileGraphic = new TileGraphic(this.tileSetNumber, tileNumber, tileSurface, rawSurfaceSize);
                //base.Add(tileNumber, tileGraphic);
                base.Add(tileNumber, tileGraphic);
            }

        }

        public TileGraphic GetTileGraphic(int tileNumber) {
            if (tileNumber > -1 && tileNumber < tileCount) {

                TileGraphic graphic = base.Get(tileNumber);
                if (graphic != null) {
                    return graphic;
                } else {
                    byte[] tileBytes = new byte[this.tileSizeCache[tileNumber]];
                    using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                        // Seek to the location of the tile
                        stream.Seek(GetTilePosition(tileNumber), SeekOrigin.Begin);
                        stream.Read(tileBytes, 0, tileBytes.Length);
                    }
                    using (MemoryStream stream = new MemoryStream(tileBytes))
                    {
                        Bitmap bitmap = (Bitmap)Image.FromStream(stream);
                        Surface tileSurface = new Surface(bitmap);
                        tileSurface.Transparent = true;
                        int rawSurfaceSize = tileSurface.Width * tileSurface.Height * tileSurface.BitsPerPixel / 8;
                        TileGraphic tileGraphic = new TileGraphic(this.tileSetNumber, tileNumber, tileSurface, rawSurfaceSize);
                        //base.Add(tileNumber, tileGraphic);
                        base.Add(tileNumber, tileGraphic);
                        //tiles[tileNumber] = tileGraphic;
                        return tileGraphic;
                    }
                }

            } else {
                return GetTileGraphic(0);
            }
        }

        public Surface this[int tileNumber] {
            get { return GetTileGraphic(tileNumber).Tile; }
        }
    }
}
