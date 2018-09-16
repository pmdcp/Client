﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
    class PlayerManager
    {
        #region Fields

        static bool loggedIn = false;
        static string myConnectionID = "";
        static PlayerCollection players;
        static MyPlayer myPlayer;

        #endregion Fields

        #region Properties

        public static string MyConnectionID
        {
            get { return myConnectionID; }
            set { myConnectionID = value; }
        }

        public static PlayerCollection Players
        {
            get { return players; }
        }

        #endregion Properties

        #region Methods

        public static void Initialize()
        {
            players = new PlayerCollection();
        }

        //public static bool IsPlaying(int index) {
        //    return (!string.IsNullOrEmpty(players[index].Name));
        //}

        public static bool IsPlaying(string id)
        {
            foreach (IPlayer player in players.GetAllPlayers())
            {
                if (player.ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public static MyPlayer MyPlayer
        {
            get
            {
                if (players == null)
                {
                    return null;
                }
                if (myPlayer == null)
                {
                    myPlayer = players[myConnectionID] as MyPlayer;
                }
                return myPlayer;
            }
        }

        #endregion Methods
    }
}