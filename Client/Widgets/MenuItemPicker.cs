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
using SdlDotNet.Widgets;
using System.Drawing;

namespace Client.Logic.Widgets
{
    class MenuItemPicker : Widget
    {
        short lineLength = 10;
        int selectedItem;

        public int SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }
        public MenuItemPicker(string name)
            : base(name)
        {
            this.Size = new Size(30, 20);
            this.BackColor = Color.Transparent;

            base.Paint += new EventHandler(MenuItemPicker_Paint);
        }

        void MenuItemPicker_Paint(object sender, EventArgs e)
        {
            this.Buffer.Draw(new SdlDotNet.Graphics.Primitives.Triangle(0, 0, 0, lineLength, lineLength, (short)(lineLength / 2)), Color.WhiteSmoke, false, true);
            this.Buffer.Draw(new SdlDotNet.Graphics.Primitives.Triangle(0, 0, 0, lineLength, lineLength, (short)(lineLength / 2)), Color.Black, false, false);
        }
    }
}
