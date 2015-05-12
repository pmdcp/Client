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
using SdlDotNet.Graphics;

namespace Client.Logic.Widgets
{
    class MenuNumberSelector : Widget
    {
        Label lblLeftArrow;
        Label lblRightArrow;
        Label lblSelectedNumber;

        SdlDotNet.Graphics.Font font;

        public SdlDotNet.Graphics.Font Font {
            get {
                CheckFont();
                return font;
            }
            set {
                font = value;
            }
        }

        public MenuNumberSelector(string name)
            : base(name, true) {
                base.Paint += new EventHandler(MenuNumberSelector_Paint);
        }

        void MenuNumberSelector_Paint(object sender, EventArgs e) {
        }

        private void CheckFont() {
            if (font == null) {
                font = new Font(SdlDotNet.Widgets.Widgets.DefaultFontPath, SdlDotNet.Widgets.Widgets.DefaultFontSize);
            }
        }
    }
}
