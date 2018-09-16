﻿// This file is part of Mystery Dungeon eXtended.

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

namespace Client.Logic.Editors.Moves
{
    class EditableMove
    {
        #region Properties

        public bool Big
        {
            get;
            set;
        }

        public int Data1
        {
            get;
            set;
        }

        public int Data2
        {
            get;
            set;
        }

        public int Data3
        {
            get;
            set;
        }

        public Enums.MoveType EffectType
        {
            get;
            set;
        }

        public bool IsKey
        {
            get;
            set;
        }

        public int KeyItem
        {
            get;
            set;
        }

        public int LevelReq
        {
            get;
            set;
        }

        public int MaxPP
        {
            get;
            set;
        }

        public Enums.PokemonType MoveType
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Enums.MoveRange Range
        {
            get;
            set;
        }

        public int Sound
        {
            get;
            set;
        }

        public int SpellAnim
        {
            get;
            set;
        }

        public int SpellDone
        {
            get;
            set;
        }

        public int SpellTime
        {
            get;
            set;
        }

        public Enums.MoveTarget TargetType
        {
            get;
            set;
        }

        #endregion Properties
    }
}
