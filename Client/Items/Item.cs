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
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Item
    {
        #region Properties

        public string Name { get; set; }
        public string Desc { get; set; }
        public int Pic { get; set; }
        public Enums.ItemType Type { get; set; }
        public int Data1 { get; set; }
        public int Data2 { get; set; }
        public int Data3 { get; set; }
        public int Price { get; set; }
        public int StackCap { get; set; }
        public bool Bound { get; set; }
        public bool Loseable { get; set; }
        public int Rarity { get; set; }

        public int AttackReq { get; set; }
        public int DefenseReq { get; set; }
        public int SpAtkReq { get; set; }
        public int SpDefReq { get; set; }
        public int SpeedReq { get; set; }
        public int ScriptedReq { get; set; }

        public int AddHP { get; set; }
        public int AddPP { get; set; }
        public int AddAttack { get; set; }
        public int AddDefense { get; set; }
        public int AddSpAtk { get; set; }
        public int AddSpDef { get; set; }
        public int AddSpeed { get; set; }
        public int AddEXP { get; set; }
        public int AttackSpeed { get; set; }
        public int RecruitBonus { get; set; }

        #endregion Properties
        
        public Item() {
        	Name = "";
        	Desc = "";
        }
    }
}