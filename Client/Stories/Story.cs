using System;
using System.Collections.Generic;
using System.Text;
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

namespace Client.Logic.Stories
{
    class Story
    {
        #region Constructors

        public Story()
        {
            Segments = new List<ISegment>();
            ExitAndContinue = new List<int>();
        }

        #endregion Constructors

        #region Properties

        public List<int> ExitAndContinue
        {
            get;
            set;
        }

        public bool Loaded
        {
            get;
            set;
        }

        public bool LocalStory
        {
            get;
            set;
        }

        public int MaxSegments
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Revision
        {
            get;
            set;
        }

        public List<ISegment> Segments
        {
            get;
            set;
        }

        public StoryState State
        {
            get;
            set;
        }

        public int StoryStart
        {
            get;
            set;
        }

        public int Version
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public void AppendSegment(ISegment segment)
        {
            this.Segments.Add(segment);
        }

        #endregion Methods
    }
}