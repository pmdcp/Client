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

namespace Client.Logic.Npc
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PMDCP.Core;

    class NpcHelper
    {
        #region Fields

        private static int dataLoadPercent;
        private static NpcCollection mNpcs;

        #endregion Fields

        #region Properties

        public static int DataLoadPercent
        {
            get { return dataLoadPercent; }
        }

        public static NpcCollection Npcs
        {
            get { return mNpcs; }
        }

        #endregion Properties

        #region Methods

        public static void InitNpcArray()
        {
            mNpcs = new NpcCollection(MaxInfo.MaxNpcs);
        }

        public static void LoadNpcsFromPacket(string[] parse)
        {
            try {
                int n, temp;
                n = 1;
                for (int i = 1; i <= MaxInfo.MaxNpcs; i++) {
                    temp = Logic.MathFunctions.CalculatePercent(i, MaxInfo.MaxNpcs+1);
                    if (temp >= 100) {
                        temp = 99;
                    }
                    dataLoadPercent = temp;

                    mNpcs.AddNpc(parse[n + 1]);

                    n += 2;

                    ((Windows.winLoading)Windows.WindowSwitcher.FindWindow("winLoading")).UpdateLoadText("Recieving Data... " + DataManager.AverageLoadPercent().ToString() + "%");
                }
                dataLoadPercent = 100;
            } catch (Exception ex) {
                Exceptions.ExceptionHandler.OnException(ex);
            }
        }

        #endregion Methods
    }
}