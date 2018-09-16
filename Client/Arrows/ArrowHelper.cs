using System;
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


namespace Client.Logic.Arrows
{
    class ArrowHelper
    {
        #region Fields

        private static int dataLoadPercent = 0;
        private static ArrowCollection mArrows;

        #endregion Fields

        #region Properties

        public static ArrowCollection Arrows
        {
            get { return mArrows; }
        }

        public static int DataLoadPercent
        {
            get { return dataLoadPercent; }
        }

        #endregion Properties

        #region Methods

        public static void InitArrowCollection()
        {
            mArrows = new ArrowCollection(MaxInfo.MAX_ARROWS + 2);
        }

        public static void LoadArrowsFromPacket(string[] parse)
        {
            try
            {
                int n = 1;
                for (int i = 0; i < MaxInfo.MAX_ARROWS; i++)
                {
                    dataLoadPercent = System.Math.Min(99, Logic.MathFunctions.CalculatePercent(i, MaxInfo.MAX_ARROWS));
                    mArrows[i] = new Arrow();
                    mArrows[i].Name = parse[n + 1];
                    mArrows[i].Pic = parse[n + 2].ToInt();
                    mArrows[i].Range = parse[n + 3].ToInt();
                    mArrows[i].Amount = parse[n + 4].ToInt();
                    n += 5;
                    ((Windows.winLoading)Windows.WindowSwitcher.FindWindow("winLoading")).UpdateLoadText("Recieving Data... " + DataManager.AverageLoadPercent().ToString() + "%");
                }
                dataLoadPercent = 100;
            }
            catch (Exception ex)
            {
                Exceptions.ExceptionHandler.OnException(ex);
            }
        }

        #endregion Methods
    }
}