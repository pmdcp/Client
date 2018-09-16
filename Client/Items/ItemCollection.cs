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


namespace Client.Logic.Items
{
    class ItemCollection
    {
        #region Fields

        private PMDCP.Core.ListPair<int, Item> mItems;

        #endregion Fields

        #region Constructors

        internal ItemCollection(int maxItems)
        {
            mItems = new PMDCP.Core.ListPair<int, Item>();
        }

        #endregion Constructors

        #region Indexers

        public Item this[int index]
        {
            get { return mItems[index]; }
            set
            {
                mItems[index] = value;
            }
        }

        #endregion Indexers

        public void AddItem(int index, Item value)
        {
            mItems.Add(index, value);
        }
    }
}