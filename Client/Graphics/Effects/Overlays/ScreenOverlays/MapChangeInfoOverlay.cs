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
using SdlDotNet.Graphics;
using System.Drawing;
using SdlDotNet.Widgets;

using PMDCP.Core;

namespace Client.Logic.Graphics.Effects.Overlays.ScreenOverlays
{
    class MapChangeInfoOverlay : IOverlay
    {
        #region Fields

        Surface buffer;
        bool disposed;
        SdlDotNet.Graphics.Font textFont;
        TickCount tickCount;
        int minDisplayTime;
        string mapName;

        public bool MinTimePassed { get; set; }

        #endregion Fields

        #region Constructors

        public MapChangeInfoOverlay(string mapName, int minDisplayTime) {
            disposed = false;

            this.mapName = mapName;
            textFont = FontManager.LoadFont("PMDCP", 36);
            buffer = new Surface(20 * Constants.TILE_WIDTH, 15 * Constants.TILE_HEIGHT);
            buffer.Fill(Color.Black);
            Surface textSurf = TextRenderer.RenderTextBasic(textFont, mapName, null, Color.WhiteSmoke, false, 0, 0, 0, 0);
            buffer.Blit(textSurf, new Point(DrawingSupport.GetCenterX(buffer.Width, textSurf.Width), 100));
            this.minDisplayTime = minDisplayTime;
            tickCount = new TickCount(SdlDotNet.Core.Timer.TicksElapsed);
            //TextRenderer.RenderText(buffer, textFont, mapName, Color.WhiteSmoke, true, 0, 0, 100, 50);
            //for (int x = 0; x < 20; x++) {
            //    for (int y = 0; y < 15; y++) {

            //        buffer.Blit(GraphicsManager.Tiles[10][59 + (x % 2) + 2 * (y % 2)], new Point(x * Constants.TILE_WIDTH, y * Constants.TILE_HEIGHT));
            //    }
            //}
            //buffer.AlphaBlending = true;
            //buffer.Alpha = 50;
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
            if (tick > tickCount.Tick + minDisplayTime) {
                //if (Renderers.Screen.ScreenRenderer.RenderOptions.Map.Loaded && Renderers.Screen.ScreenRenderer.RenderOptions.Map == Maps.MapHelper.Maps[Enums.MapID.TempActive]) {
                    if (Renderers.Screen.ScreenRenderer.RenderOptions.Map.Name == this.mapName) {
                        Renderers.Screen.ScreenRenderer.RenderOptions.ScreenOverlay = null;
                    }
                //}
                MinTimePassed = true;
            }
        }

        #endregion Methods
    }
}
