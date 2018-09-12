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

namespace Client.Logic.Players.Parties
{
    class PartyData
    {
        PartyMember[] members;
        public PartyMember[] Members
        {
            get { return members; }
        }

        public PartyData()
        {
            members = new PartyMember[4];
        }

        public void LoadMember(int slot, string name, int mugshot, int form, Enums.Coloration shiny, Enums.Sex gender, ulong exp, ulong maxExp, int hp, int maxHP)
        {
            members[slot] = new PartyMember();
            members[slot].Name = name;
            members[slot].MugshotNum = mugshot;
            members[slot].MugshotForm = form;
            members[slot].MugshotShiny = shiny;
            members[slot].MugshotGender = gender;
            members[slot].Exp = exp;
            members[slot].MaxExp = maxExp;
            members[slot].HP = hp;
            members[slot].MaxHP = maxHP;
        }

        public void ClearSlot(int slot)
        {
            members[slot] = null;
        }
    }
}
