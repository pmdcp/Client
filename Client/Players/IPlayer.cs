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
using System.Drawing;

namespace Client.Logic.Players
{
    interface IPlayer : Graphics.Renderers.Sprites.ISprite
    {
        PlayerType PlayerType { get; }
        string Name { get; set; }
        string MapID { get; set; }
        string Guild { get; set; }
        Enums.GuildRank GuildAccess { get; set; }
        string Status { get; set; }
        bool Hunted { get; set; }
        bool Dead { get; set; }
        Enums.Rank Access { get; set; }
        string ID { get; set; }
        PlayerPet[] Pets { get; set; }
    }
}
