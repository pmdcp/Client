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


namespace Client.Logic.Players
{
    class Recruit
    {
        #region Constructors

        public Recruit()
        {
            Loaded = false;
        }

        #endregion Constructors

        #region Properties

        public int Num
        {
            get;
            set;
        }
        public int Form
        {
            get;
            set;
        }
        public Enums.Coloration Shiny
        {
            get;
            set;
        }

        public bool Loaded
        {
            get;
            set;
        }


        public string Name
        {
            get;
            set;
        }

        public int HP
        {
            get;
            set;
        }

        public int MaxHP
        {
            get;
            set;
        }

        public Enums.Sex Sex
        {
            get;
            set;
        }

        public Enums.StatusAilment StatusAilment
        {
            get;
            set;
        }

        public int HeldItemSlot { get; set; }

        public int ExpPercent { get; set; }

        public int Level { get; set; }

        #endregion Properties
    }
}