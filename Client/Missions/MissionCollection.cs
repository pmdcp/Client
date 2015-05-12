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


namespace Client.Logic.Missions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class MissionCollection
    {
        #region Fields

        private PMDCP.Core.ListPair<int, Mission> mMissions;

        #endregion Fields

        #region Constructors

        internal MissionCollection()
        {
            mMissions = new PMDCP.Core.ListPair<int, Mission>();
        }

        #endregion Constructors

        #region Indexers

        public Mission this[int index]
        {
            get { return mMissions[index]; }
            set { mMissions[index] = value; }
        }

        #endregion Indexers

        #region Methods

        public void AddMission(int index, Mission missionToAdd)
        {
            mMissions.Add(index, missionToAdd);
        }

        public void ClearMissions()
        {
            mMissions.Clear();
        }

        #endregion Methods
    }
}