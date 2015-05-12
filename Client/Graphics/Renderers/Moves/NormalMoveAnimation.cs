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

    class NormalMoveAnimation : IMoveAnimation
    {
        #region Constructors

        public NormalMoveAnimation(int targetX, int targetY)
        {
            StartX = targetX;
            StartY = targetY;
        }

        #endregion Constructors

        #region Properties

        public bool Active
        {
            get;
            set;
        }

        public int AnimationIndex
        {
            get;
            set;
        }

        public int CompletedLoops
        {
            get;
            set;
        }

        public int Frame
        {
            get;
            set;
        }

        public int FrameLength
        {
            get;
            set;
        }

        public int MoveTime
        {
            get;
            set;
        }

        public int RenderLoops
        {
            get;
            set;
        }

        public Enums.MoveAnimationType AnimType
        {
            get { return Enums.MoveAnimationType.Normal; }
        }

        public int StartX
        {
            get;
            set;
        }

        public int StartY
        {
            get;
            set;
        }

        #endregion Properties

        
    }
}