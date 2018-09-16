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

namespace Client.Logic.Graphics
{
    class GraphicsCache
    {
        public static Surface MenuHorizontal { get { return menuHorizontal; } }
        static Surface menuHorizontal;
        public static Surface MenuHorizontalFill { get { return menuHorizontalFill; } }
        static Surface menuHorizontalFill;
        public static Surface MenuHorizontalBorder { get { return menuHorizontalBorder; } }
        static Surface menuHorizontalBorder;

        public static Surface MenuVertical { get { return menuVertical; } }
        static Surface menuVertical;
        public static Surface MenuVerticalFill { get { return menuVerticalFill; } }
        static Surface menuVerticalFill;
        public static Surface MenuVerticalBorder { get { return menuVerticalBorder; } }
        static Surface menuVerticalBorder;

        public static void LoadCache()
        {
            menuHorizontal = Skins.SkinManager.LoadGuiElement("General\\Menus", "menu-horizontal.png", false);
            menuHorizontalFill = Skins.SkinManager.LoadGuiElement("General\\Menus", "menu-horizontal-fill.png", false);
            menuHorizontalBorder = Skins.SkinManager.LoadGuiElement("General\\Menus", "menu-horizontal-border.png", false);
            menuVertical = Skins.SkinManager.LoadGuiElement("General\\Menus", "menu-vertical.png", false);
            menuVerticalFill = Skins.SkinManager.LoadGuiElement("General\\Menus", "menu-vertical-fill.png", false);
            menuVerticalBorder = Skins.SkinManager.LoadGuiElement("General\\Menus", "menu-vertical-border.png", false);
        }
    }
}
