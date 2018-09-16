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
    class GenericPlayer : IPlayer
    {
        public PlayerType PlayerType
        {
            get { return Players.PlayerType.Generic; }
        }

        public Logic.Graphics.SpriteSheet SpriteSheet
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int IdleTimer { get; set; }
        public int IdleFrame { get; set; }
        public int LastWalkTime { get; set; }
        public int WalkingFrame { get; set; }

        public string MapID
        {
            get;
            set;
        }

        public int X
        {
            get { return Location.X; }
            set { Location = new Point(value, Location.Y); }
        }

        public int Y
        {
            get { return Location.Y; }
            set { Location = new Point(Location.X, value); }
        }

        public Point Location
        {
            get;
            set;
        }

        public string Guild
        {
            get;
            set;
        }

        public Enums.GuildRank GuildAccess
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public int Sprite
        {
            get;
            set;
        }
        public int Form { get; set; }
        public Enums.Coloration Shiny { get; set; }
        public Enums.Sex Sex { get; set; }

        public bool Hunted
        {
            get;
            set;
        }

        public bool Dead
        {
            get;
            set;
        }

        public Enums.Rank Access
        {
            get;
            set;
        }

        public Enums.Direction Direction
        {
            get;
            set;
        }

        public string ID
        {
            get;
            set;
        }

        public Enums.MovementSpeed MovementSpeed { get; set; }


        public Enums.StatusAilment StatusAilment { get; set; }

        public List<int> VolatileStatus
        {
            get;
            set;
        }

        public bool Attacking
        {
            get;
            set;
        }
        public int TotalAttackTime { get; set; }

        public int AttackTimer
        {
            get;
            set;
        }

        public Point Offset { get; set; }

        //public Enums.Size Size
        //{
        //    get;
        //    set;
        //}

        public bool Leaving { get; set; }

        public bool ScreenActive { get; set; }

        public int SleepTimer
        {
            get;
            set;
        }

        public int SleepFrame
        {
            get;
            set;
        }


        public Graphics.Renderers.Sprites.SpeechBubble CurrentSpeech { get; set; }

        public Graphics.Renderers.Sprites.Emoticon CurrentEmote { get; set; }

        public PlayerPet[] Pets { get; set; }

        public GenericPlayer()
        {
            Pets = new PlayerPet[MaxInfo.MAX_ACTIVETEAM];
            VolatileStatus = new List<int>();
        }
    }
}
