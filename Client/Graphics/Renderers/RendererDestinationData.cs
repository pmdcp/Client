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
using System.Drawing;

namespace Client.Logic.Graphics.Renderers
{
    class RendererDestinationData
    {
        const bool BUFFERLESS = false;

        Surface surface;

        public Surface Surface
        {
            get { return surface; }
            set { surface = value; }
        }
        Point location;
        Size size;

        public Size Size
        {
            get { return size; }
            set { size = value; }
        }

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

        public RendererDestinationData(Surface surface, Point location, Size size)
        {
            this.surface = surface;
            this.location = location;
            this.size = size;
        }

        public void Blit(Surface surface, Point location)
        {
            if (BUFFERLESS)
            {
                Rectangle sourceRec = new Rectangle();
                if (location.X + surface.Width < 0)
                {
                    return;
                }
                else if (location.X > this.Size.Width)
                {
                    return;
                }
                else
                {
                    if (location.X < 0)
                    {
                        sourceRec.X = System.Math.Abs(location.X);
                        location.X = 0;
                        sourceRec.Width = surface.Width - sourceRec.X;
                    }
                    else if (location.X + surface.Width > this.Size.Width)
                    {
                        if (location.X >= this.Size.Width)
                        {
                            sourceRec.X = 0;
                            sourceRec.Width = 0;
                        }
                        else
                        {
                            sourceRec.X = 0;
                            sourceRec.Width = surface.Width - System.Math.Abs(this.Size.Width - (location.X + surface.Width));
                        }
                    }
                    else
                    {
                        sourceRec.X = 0;
                        sourceRec.Width = surface.Width - sourceRec.X;
                    }
                }
                if (location.Y + surface.Height < 0)
                {
                    return;
                }
                else
                {
                    if (location.Y < 0)
                    {
                        sourceRec.Y = System.Math.Abs(location.Y);
                        location.Y = 0;
                        sourceRec.Height = surface.Height - sourceRec.Y;
                    }
                    else if (location.Y + surface.Height > this.Size.Height)
                    {
                        if (location.Y >= this.Size.Height)
                        {
                            sourceRec.Y = 0;
                            sourceRec.Height = 0;
                        }
                        else
                        {
                            sourceRec.Y = 0;
                            sourceRec.Height = surface.Height - System.Math.Abs(this.Size.Height - (location.Y + surface.Height));
                        }
                    }
                    else
                    {
                        sourceRec.Y = 0;
                        sourceRec.Height = surface.Height - sourceRec.Y;
                    }
                }
                if (sourceRec.Height != 0 && sourceRec.Width != 0)
                {
                    this.Surface.Blit(surface, new Point(this.location.X + location.X, this.location.Y + location.Y), sourceRec);
                }
            }
            else
            {
                this.Surface.Blit(surface, location);
            }
        }

        public void Blit(Surface surface, Point location, Rectangle sourceRectangle)
        {
            if (BUFFERLESS)
            {
                Rectangle sourceRec = new Rectangle();
                if (location.X + sourceRectangle.Width < 0)
                {
                    return;
                }
                else
                {
                    if (location.X < 0)
                    {
                        sourceRec.X = System.Math.Abs(location.X);
                        location.X = 0;
                        sourceRec.Width = sourceRectangle.Width - sourceRec.X;
                    }
                    else if (location.X + sourceRectangle.Width > this.Size.Width)
                    {
                        if (location.X >= this.Size.Width)
                        {
                            sourceRec.X = 0;
                            sourceRec.Width = 0;
                        }
                        else
                        {
                            sourceRec.X = 0;
                            sourceRec.Width = sourceRectangle.Width - System.Math.Abs(this.Size.Width - (location.X + sourceRectangle.Width));
                        }
                    }
                    else
                    {
                        sourceRec.X = 0;
                        sourceRec.Width = sourceRectangle.Width - sourceRec.X;
                    }
                }
                if (location.Y + sourceRectangle.Height < 0)
                {
                    return;
                }
                else
                {
                    if (location.Y < 0)
                    {
                        sourceRec.Y = System.Math.Abs(location.Y);
                        location.Y = 0;
                        sourceRec.Height = sourceRectangle.Height - sourceRec.Y;
                    }
                    else if (location.Y + sourceRectangle.Height > this.Size.Height)
                    {
                        if (location.Y >= this.Size.Height)
                        {
                            sourceRec.Y = 0;
                            sourceRec.Height = 0;
                        }
                        else
                        {
                            sourceRec.Y = 0;
                            sourceRec.Height = sourceRectangle.Height - System.Math.Abs(this.Size.Height - (location.Y + sourceRectangle.Height));
                        }
                    }
                    else
                    {
                        sourceRec.Y = 0;
                        sourceRec.Height = sourceRectangle.Height - sourceRec.Y;
                    }
                }
                sourceRectangle.X = sourceRectangle.X + sourceRec.X;
                sourceRectangle.Y = sourceRectangle.Y + sourceRec.Y;
                sourceRectangle.Width = sourceRec.Width;
                sourceRectangle.Height = sourceRec.Height;
                if (sourceRec.Height != 0 && sourceRec.Width != 0)
                {
                    this.Surface.Blit(surface, new Rectangle(this.location.X + location.X, this.location.Y + location.Y, this.Size.Width, size.Height), sourceRectangle);
                }
            }
            else
            {
                this.Surface.Blit(surface, location, sourceRectangle);
            }
        }

        public void Draw(IPrimitive primitive, Color color, bool antiAlias, bool fill)
        {
            this.Surface.Draw(primitive, color, antiAlias, fill);
        }
    }
}
