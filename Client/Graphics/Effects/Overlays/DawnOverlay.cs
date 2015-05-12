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
using System.Drawing;
using System.Text;

using SdlDotNet.Graphics;

namespace Client.Logic.Graphics.Effects.Overlays
{
    class DawnOverlay : IOverlay
    {
        #region Fields

        Surface buffer;
        bool disposed;

        #endregion Fields

        #region Constructors

        public DawnOverlay() {
            disposed = false;
            buffer = new Surface(20 * Constants.TILE_WIDTH, 15 * Constants.TILE_HEIGHT);
            for (int x = 0; x < 20; x++) {
                for (int y = 0; y < 15; y++) {
                    buffer.Blit(GraphicsManager.Tiles[10][49], new Point(x * Constants.TILE_WIDTH, y * Constants.TILE_HEIGHT));
                }
            }
            buffer.AlphaBlending = true;
            buffer.Alpha = 60;
        }

        #endregion Constructors

        #region Properties

        public SdlDotNet.Graphics.Surface Buffer {
            get { return buffer; }
        }

        public bool Disposed {
            get { return disposed; }
        }

        #endregion Properties

        #region Methods

        public void FreeResources() {
            disposed = true;
            buffer.Dispose();
        }

        public void Render(Renderers.RendererDestinationData destData, int tick) {
            // We don't need to render anything as this overlay isn't animated and always remains the same
            destData.Blit(buffer, new Point(0, 0));
        }

        #endregion Methods
    }
}