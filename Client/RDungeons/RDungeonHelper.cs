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

namespace Client.Logic.RDungeons
{
	
	class RDungeonHelper
	{
		#region Fields

        private static int dataLoadPercent = 0;
        private static RDungeonCollection mRDungeons;

        #endregion Fields

        #region Properties

        public static int DataLoadPercent
        {
            get { return dataLoadPercent; }
        }

        public static RDungeonCollection RDungeons
        {
            get { return mRDungeons; }
        }

        #endregion Properties

        #region Methods

        public static void InitRDungeonCollection()
        {
            mRDungeons = new RDungeonCollection();
        }

        public static void LoadRDungeonsFromPacket(string[] parse)
        {
            try {
                int n = 2;
                MaxInfo.MaxRDungeons = parse[1].ToInt();
                mRDungeons.ClearRDungeons();
                if (MaxInfo.MaxRDungeons > 0) {
                    for (int i = 0; i < MaxInfo.MaxRDungeons; i++) {
                        dataLoadPercent = System.Math.Min(99, Logic.MathFunctions.CalculatePercent(i, MaxInfo.MaxRDungeons));
                        mRDungeons.AddRDungeon(i, new RDungeon());
                        mRDungeons[i].Name = parse[n];
                        n += 1;
                        ((Windows.winLoading)Windows.WindowSwitcher.FindWindow("winLoading")).UpdateLoadText("Recieving Data... " + DataManager.AverageLoadPercent().ToString() + "%");
                    }
                    dataLoadPercent = 100;
                }
            } catch (Exception ex) {
                Exceptions.ExceptionHandler.OnException(ex);
            }
        }

        #endregion Methods
	}
}
