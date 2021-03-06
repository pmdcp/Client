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
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using System.Drawing;
using SdlDotNet.Core;

namespace Client.Logic.Graphics.Effects.Weather
{
    class Hailstone : Surface
    {
        float speed;
        float wind;
        float delta = 0.15f;

        public int X;
        public int Y;
        //public int terminalY;

        public Hailstone()
            : base(new Surface(32, 32)) {
            Initialize();
            Reset();
            Y = -1 * Logic.MathFunctions.Random.Next(5000 - base.Height);
        }

        void Initialize() {
            
            base.Blit(GraphicsManager.Tiles[10][188], new Point(0, 0));
            base.Transparent = true;
            //base.Surface.TransparentColor = Color.FromArgb(255, 0, 255);
            //base.Rectangle = new Rectangle(this.Width, this.Height, 0, 0);
        }

        void Reset() {
            wind = Logic.MathFunctions.Random.Next(3) / 10.0f;

            X = (int)Logic.MathFunctions.Random.Next(-1 * (int)(wind * 640), 720 - base.Width);
            Y = -64; // (int)Logic.Math.Random.Next(-1 * (int)(wind * 640), 640 - base.Width);//0 - base.Width + (Logic.Math.Random.Next(100));

            //terminalY = (int)Logic.Math.Random.Next(0, 640 - base.Width);

            speed = Logic.MathFunctions.Random.Next(100, 200);
            //base.Draw(new SdlDotNet.Graphics.Primitives.Line(0, 0, (short)(speed / 6), (short)(speed / 3)), Color.Blue);
            
            //base.Surface.Alpha =
            //    (byte)((150 - 50) / (speed - 50) * -255);
            //base.Surface.AlphaBlending = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void UpdateLocation() {
            float change = delta * speed;
            
            //this.X += (int)(change / 3);
            this.Y += (int)change;
        //    this.Y += (int)System.Math.Ceiling(change * wind);

            if (this.Y > 480) {
                Reset();
            }
        }

        #region IDisposable
        private bool disposed;

        /// <summary>
        /// Destroys the surface object and frees its memory
        /// </summary>
        /// <param name="disposing">If true, dispose unmanaged resources</param>
        protected override void Dispose(bool disposing) {
            try {
                if (!this.disposed) {
                    if (disposing) {
                    }
                    this.disposed = true;
                }
            } finally {
                base.Dispose(disposing);
            }
        }
        #endregion IDisposable
    }
}
