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
using PMDCP.Core;

namespace Client.Logic.Stories.Segments
{
    class PlayerPadlockSegment : ISegment
    {
        #region Fields

        private Enums.PadlockState state;
        ListPair<string, string> parameters;
        StoryState storyState;

        #endregion Fields

        #region Constructors

        public PlayerPadlockSegment(Enums.PadlockState state)
        {
            Load(state);
        }

        public PlayerPadlockSegment()
        {
        }

        #endregion Constructors

        #region Properties

        public Enums.StoryAction Action
        {
            get { return Enums.StoryAction.PlayerPadlock; }
        }

        public Enums.PadlockState State
        {
            get { return state; }
            set { state = value; }
        }

        public ListPair<string, string> Parameters
        {
            get { return parameters; }
        }

        public bool UsesSpeechMenu
        {
            get { return false; }
        }

        #endregion Properties

        #region Methods

        public void Load(Enums.PadlockState state)
        {
            this.state = state;
        }

        public void LoadFromSegmentData(ListPair<string, string> parameters)
        {
            this.parameters = parameters;
            state = (Enums.PadlockState)Enum.Parse(typeof(Enums.PadlockState), parameters.GetValue("MovementState"));
        }

        public void Process(StoryState state)
        {
            switch (this.state)
            {
                case Enums.PadlockState.Lock:
                    {
                        Players.PlayerManager.MyPlayer.MovementLocked = true;
                    }
                    break;
                case Enums.PadlockState.Unlock:
                    {
                        Players.PlayerManager.MyPlayer.MovementLocked = false;
                    }
                    break;
            }
        }

        #endregion Methods
    }
}
