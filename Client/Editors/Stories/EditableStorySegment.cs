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

namespace Client.Logic.Editors.Stories
{
    class EditableStorySegment
    {
        ListPair<string, string> parameters;

        public EditableStorySegment() {
            parameters = new ListPair<string, string>();
        }

        #region Properties

        public Enums.StoryAction Action {
            get;
            set;
        }

        public ListPair<string, string> Parameters {
            get { return parameters; }
        }

        public void AddParameter(string paramID, string value) {
            parameters.Add(paramID, value);
        }

        #endregion Properties
    }
}
