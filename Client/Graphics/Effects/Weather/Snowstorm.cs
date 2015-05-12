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

using Client.Logic.Graphics.Effects.Overlays;
using SdlDotNet.Graphics;
using System.Drawing;
using SdlDotNet.Graphics.Sprites;

namespace Client.Logic.Graphics.Effects.Weather
{
    class Snowstorm : IWeather
    {
        #region Fields

        bool disposed;

        List<Snowflake> snowflakes = new List<Snowflake>();

        #endregion Fields

        #region Constructors

        public Snowstorm() {
            disposed = false;

            for (int i = 0; i < 120; i++) {
                snowflakes.Add(new Snowflake());
            }
        }

        #endregion Constructors

        #region Properties

        public bool Disposed {
            get { return disposed; }
        }

        #endregion Properties

        #region Methods

        public void FreeResources() {
            disposed = true;
            for (int i = snowflakes.Count - 1; i >= 0; i--) {
                snowflakes[i].Dispose();
                snowflakes.RemoveAt(i);
            }
        }

        public void Render(Renderers.RendererDestinationData destData, int tick) {
            for (int i = 0; i < snowflakes.Count; i++) {
                snowflakes[i].UpdateLocation(5);
                destData.Blit(snowflakes[i], new Point(snowflakes[i].X, snowflakes[i].Y));
            }
        }

        #endregion Methods

        public Enums.Weather ID {
            get { return Enums.Weather.Snowstorm; }
        }
    }
}
