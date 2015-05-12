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
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PMDCP.Core;

    class WarpFNPCSegment : ISegment
    {
        #region Fields

        string id;
        StoryState storyState;
        int x;
        int y;
        ListPair<string, string> parameters;

        #endregion Fields

        #region Constructors

        public WarpFNPCSegment(string id, int x, int y) {
            Load(id, x, y);
        }

        public WarpFNPCSegment() {
        }

        #endregion Constructors

        #region Properties

        public Enums.StoryAction Action {
            get { return Enums.StoryAction.WarpFNPC; }
        }

        public string ID {
            get { return id; }
            set { id = value; }
        }

        public ListPair<string, string> Parameters {
            get { return parameters; }
        }

        public int X {
            get { return x; }
            set { x = value; }
        }

        public int Y {
            get { return y; }
            set { y = value; }
        }

        public bool UsesSpeechMenu {
            get { return false; }
        }

        #endregion Properties

        #region Methods

        public void Load(string id, int x, int y) {
            this.id = id;
            this.x = x;
            this.y = y;
        }

        public void LoadFromSegmentData(ListPair<string, string> parameters)
        {
            this.parameters = parameters;
            Load(parameters.GetValue("ID"), parameters.GetValue("X").ToInt(), parameters.GetValue("Y").ToInt());
        }

        public void Process(StoryState state) {
            this.storyState = state;
            for (int i = 0; i < state.FNPCs.Count; i++) {
                if (state.FNPCs[i].ID == id) {
                    state.FNPCs[i].X = x;
                    state.FNPCs[i].Y = y;
                }
            }
        }

        #endregion Methods
    }
}