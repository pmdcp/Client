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


namespace Client.Logic.Windows.Core
{
    class TickStabalizer
    {
        #region Fields

        private static float lastVal = 0;

        #endregion Fields

        #region Methods

        public static bool CanUpdate(SdlDotNet.Core.TickEventArgs e)
        {
            float val = 1.0f / 1000 * e.TicksElapsed * Constants.FRAME_RATE;
            val += lastVal;
            if (val > 1)
            {
                lastVal = 0;
                return true;
            }
            else
            {
                lastVal = val;
                return false;
            }
        }

        #endregion Methods
    }
}