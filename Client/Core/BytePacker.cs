﻿using System;
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


namespace Client.Logic.Core
{
    public class BytePacker
    {
        #region Fields

        List<BytePackerItem> items;

        #endregion Fields

        #region Constructors

        public BytePacker()
        {
            items = new List<BytePackerItem>();
        }

        #endregion Constructors

        #region Properties

        public List<BytePackerItem> Items
        {
            get { return items; }
        }

        #endregion Properties

        #region Methods

        public void AddItem(int highestRangeValue, int value)
        {
            items.Add(new BytePackerItem(highestRangeValue, value));
        }

        public int PackItems()
        {
            int baseNumber = 1;
            int packedNumber = 0;
            for (int i = 0; i < items.Count; i++)
            {
                packedNumber += items[i].Value * baseNumber;
                baseNumber *= items[i].HighestRangeValue;
            }
            return packedNumber;
        }

        #endregion Methods
    }
}