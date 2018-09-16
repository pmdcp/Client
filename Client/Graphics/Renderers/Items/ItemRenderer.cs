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
using Client.Logic.Items;
using Client.Logic.Maps;
using Client.Logic.Graphics.Renderers.Screen;

namespace Client.Logic.Graphics.Renderers.Items
{
    class ItemRenderer
    {
        public static void DrawMapItem(RendererDestinationData destData, Map map, Enums.MapID targetMapID, int itemSlot)
        {
            Item item = ItemHelper.Items[map.MapItems[itemSlot].Num];

            Rectangle cropRect = new Rectangle((item.Pic - (item.Pic / 6) * 6) * Constants.TILE_WIDTH,
                                               (item.Pic / 6) * Constants.TILE_HEIGHT, Constants.TILE_WIDTH, Constants.TILE_HEIGHT);

            int itemX = map.MapItems[itemSlot].X;
            int itemY = map.MapItems[itemSlot].Y;

            Renderers.Maps.SeamlessWorldHelper.ConvertCoordinatesToBorderless(map, targetMapID, ref itemX, ref itemY);
            Point dstPoint = new Point(ScreenRenderer.ToScreenX(itemX * Constants.TILE_WIDTH),
                                       ScreenRenderer.ToScreenY(itemY * Constants.TILE_HEIGHT));

            //Surface itemSurface = new Surface(32,32);
            //itemSurface.Blit(Graphics.GraphicsManager.Items, cropRect);

            //if (darkness != null && !darkness.Disposed) {
            //    Point darknessPoint = new Point(darkness.Buffer.Width / 2 + dstPoint.X - darkness.Focus.X, darkness.Buffer.Height / 2 + dstPoint.Y - darkness.Focus.Y);
            //    Surface darknessSurface = new Surface(32, 32);
            //    darknessSurface.Blit(darkness.Buffer, new Point(0, 0), new Rectangle(darknessPoint, new Size(Constants.TILE_WIDTH, Constants.TILE_HEIGHT)));

            //}
            //destData.Blit(itemSurface, dstPoint);
            destData.Blit(Graphics.GraphicsManager.Items, dstPoint, cropRect);
        }
    }
}
