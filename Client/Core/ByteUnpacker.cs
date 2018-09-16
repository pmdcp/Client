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


namespace Client.Logic.Core
{
    public class ByteUnpacker
    {
        #region Fields

        List<int> items;
        List<BytePackerItem> unpackedItems;

        #endregion Fields

        #region Constructors

        public ByteUnpacker()
        {
            items = new List<int>();
        }

        #endregion Constructors

        #region Properties

        public List<int> Items
        {
            get { return items; }
        }

        public List<BytePackerItem> UnpackedItems
        {
            get { return unpackedItems; }
        }

        #endregion Properties

        #region Methods

        public void AddRange(int highestRangeValue)
        {
            items.Add(highestRangeValue);
        }

        public List<BytePackerItem> UnpackByte(int packedValue)
        {
            unpackedItems = new List<BytePackerItem>();
            int baseNumber = 1;
            for (int i = 0; i < items.Count; i++)
            {
                unpackedItems.Add(new BytePackerItem(items[i], (packedValue % (items[i] * baseNumber)) / baseNumber));
                baseNumber *= items[i];
            }
            return unpackedItems;
        }

        #endregion Methods
    }
}