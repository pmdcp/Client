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
using Client.Logic.Maps;

namespace Client.Logic.Editors.RDungeons
{
    class EditableRDungeonItem
    {
        public int ItemNum { get; set; }
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public int AppearanceRate { get; set; }
        public int StickyRate { get; set; }
        public string Tag { get; set; }
        public bool Hidden { get; set; }
        public bool OnGround { get; set; }
        public bool OnWater { get; set; }
        public bool OnWall { get; set; }

        public EditableRDungeonItem()
        {
            Tag = "";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EditableRDungeonItem)) return false;
            EditableRDungeonItem item = obj as EditableRDungeonItem;

            if (ItemNum != item.ItemNum) return false;
            if (MinAmount != item.MinAmount) return false;
            if (MaxAmount != item.MaxAmount) return false;
            if (AppearanceRate != item.AppearanceRate) return false;
            if (StickyRate != item.StickyRate) return false;
            if (Tag != item.Tag) return false;
            if (Hidden != item.Hidden) return false;
            if (OnGround != item.OnGround) return false;
            if (OnWater != item.OnWater) return false;
            if (OnWall != item.OnWall) return false;
            return true;
        }
    }
}
