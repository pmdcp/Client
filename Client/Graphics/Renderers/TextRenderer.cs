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

namespace Client.Logic.Graphics.Renderers
{
    class TextRenderer
    {
        public static SdlDotNet.Graphics.Font Font {
            get { return FontManager.GameFont; }
        }

        public static void DrawText(RendererDestinationData destData, SdlDotNet.Graphics.Font font, string text, Color textColor, Point destinationPosition) {
            Surface textSurface = font.Render(text, textColor);
            destData.Blit(textSurface, destinationPosition);
            textSurface.Close();
        }

        public static void DrawText(RendererDestinationData destData, string text, Color textColor, Point destinationPosition) {
            Surface textSurface = Logic.Graphics.FontManager.GameFont.Render(text, textColor);
            destData.Blit(textSurface, destinationPosition);
            textSurface.Close();
        }

        public static void DrawText(RendererDestinationData destData, string text, Color textColor, int destX, int destY) {
            DrawText(destData, text, textColor, new Point(destX, destY));
        }

        public static void DrawText(RendererDestinationData destData, string text, Color textColor, Color borderColor, Point destinationPosition) {
            Surface borderSurf = FontManager.GameFont.Render(text, borderColor);
            destData.Blit(borderSurf, new Point(destinationPosition.X + 1, destinationPosition.Y + 1));
            destData.Blit(borderSurf, new Point(destinationPosition.X + 2, destinationPosition.Y));
            destData.Blit(borderSurf, new Point(destinationPosition.X, destinationPosition.Y + 2));
            //destData.Blit(borderSurf, new Point(destinationPosition.X, destinationPosition.Y + 1));
            //destData.Blit(borderSurf, new Point(destinationPosition.X - 1, destinationPosition.Y));
            //destData.Blit(borderSurf, new Point(destinationPosition.X, destinationPosition.Y - 1));
            Surface textSurface = FontManager.GameFont.Render(text, textColor);
            destData.Blit(textSurface, destinationPosition);
            textSurface.Close();
            borderSurf.Close();
        }

        public static void DrawText(RendererDestinationData destData, string text, Color textColor, Color borderColor, int destX, int destY) {
            DrawText(destData, text, textColor, borderColor, new Point(destX, destY));
        }

        public static Size SizeText(string text) {
            return Font.SizeText(text);
        }
    }
}
