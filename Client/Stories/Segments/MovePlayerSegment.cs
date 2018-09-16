﻿using System;
using System.Collections.Generic;
using System.Text;

using PMDCP.Core;
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

namespace Client.Logic.Stories.Segments
{
    class MovePlayerSegment : ISegment
    {
        #region Fields

        bool pause;
        StoryState storyState;
        int x;
        int y;
        int speed;
        ListPair<string, string> parameters;

        #endregion Fields

        #region Constructors

        public MovePlayerSegment(int x, int y, int speed, bool pause)
        {
            Load(x, y, speed, pause);
        }

        public MovePlayerSegment()
        {
        }

        #endregion Constructors

        #region Properties

        public Enums.StoryAction Action
        {
            get { return Enums.StoryAction.MovePlayer; }
        }

        public ListPair<string, string> Parameters
        {
            get { return parameters; }
        }

        public bool Pause
        {
            get { return pause; }
            set { pause = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public bool UsesSpeechMenu
        {
            get { return false; }
        }

        #endregion Properties

        #region Methods

        public void Load(int x, int y, int speed, bool pause)
        {
            this.x = x;
            this.y = y;
            this.speed = speed;
            this.pause = pause;
        }

        public void LoadFromSegmentData(ListPair<string, string> parameters)
        {
            this.parameters = parameters;

            Load(parameters.GetValue("X").ToInt(), parameters.GetValue("Y").ToInt(), parameters.GetValue("Speed").ToInt(), parameters.GetValue("Pause").ToBool());
        }

        public void Process(StoryState state)
        {
            storyState = state;

            Players.MyPlayer myPlayer = Players.PlayerManager.MyPlayer;
            myPlayer.TargetX = x;
            myPlayer.TargetY = y;
            myPlayer.StoryMovementSpeed = (Enums.MovementSpeed)speed;

            if (pause)
            {
                state.StoryPaused = true;
                state.Pause();
                state.StoryPaused = false;
            }
        }

        #endregion Methods
    }
}