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

namespace Client.Logic.Dungeons
{
    class DungeonHelper
    {
        #region Fields

        private static int dataLoadPercent = 0;
        private static DungeonCollection mDungeons;

        #endregion Fields

        #region Properties

        public static int DataLoadPercent
        {
            get { return dataLoadPercent; }
        }

        public static DungeonCollection Dungeons
        {
            get { return mDungeons; }
        }

        #endregion Properties

        #region Methods

        public static void InitDungeonCollection()
        {
            mDungeons = new DungeonCollection();
        }

        public static void LoadDungeonsFromPacket(string[] parse)
        {
            try
            {
                int n = 2;
                MaxInfo.MaxDungeons = parse[1].ToInt();
                mDungeons.ClearDungeons();
                if (MaxInfo.MaxDungeons > 0)
                {
                    for (int i = 0; i < MaxInfo.MaxDungeons; i++)
                    {
                        dataLoadPercent = System.Math.Min(99, Logic.MathFunctions.CalculatePercent(i, MaxInfo.MaxDungeons));
                        mDungeons.AddDungeon(i, new Dungeon());
                        mDungeons[i].Name = parse[n];
                        n += 1;
                        ((Windows.winLoading)Windows.WindowSwitcher.FindWindow("winLoading")).UpdateLoadText("Recieving Data... " + DataManager.AverageLoadPercent().ToString() + "%");
                    }
                    dataLoadPercent = 100;
                }
            }
            catch (Exception ex)
            {
                Exceptions.ExceptionHandler.OnException(ex);
            }
        }

        #endregion Methods
    }
}
