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


namespace Client.Logic.Graphics.Renderers.Moves
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;

    interface IMoveAnimation
    {
        #region Properties

        bool Active {
            get;
            set;
        }

        int AnimationIndex {
            get;
            set;
        }

        int CompletedLoops {
            get;
            set;
        }

        int Frame {
            get;
            set;
        }

        int FrameLength {
            get;
            set;
        }

        int MoveTime {
            get;
            set;
        }

        int RenderLoops {
            get;
            set;
        }

        int StartX {
            get;
            set;
        }

        int StartY {
            get;
            set;
        }

        Enums.MoveAnimationType AnimType {
            get;
        }

        #endregion
    }
}