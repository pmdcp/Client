using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using SdlDotNet.Widgets;
using Client.Logic.Graphics;
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


namespace Client.Logic.Menus.Core
{
    class MenuBase : Panel
    {
        #region Fields

        Enums.MenuDirection menuDirection;

        #endregion Fields

        #region Constructors

        public MenuBase(string name)
            : base(name)
        {
            this.BackColor = Color.Transparent;
            //this.BackgroundImageSizeMode = ImageSizeMode.StretchImage;
            this.PreventFocus = true;
        }

        #endregion Constructors

        #region Properties

        public bool ReadyToConfigure
        {
            get;
            set;
        }

        public Enums.MenuDirection MenuDirection
        {
            get { return menuDirection; }
            set
            {
                menuDirection = value;
                switch (menuDirection)
                {
                    case Enums.MenuDirection.Horizontal:
                        {
                            this.BackgroundImage = GraphicsCache.MenuHorizontal.CreateStretchedSurface(this.Size);
                        }
                        break;
                    case Enums.MenuDirection.Vertical:
                        {
                            this.BackgroundImage = GraphicsCache.MenuVertical.CreateStretchedSurface(this.Size);
                        }
                        break;
                }
            }
        }

        #endregion Properties

        #region Methods

        public virtual void Close()
        {
            base.FreeResources();
        }

        #endregion Methods
    }
}