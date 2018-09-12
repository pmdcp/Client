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
using PMDCP.Core;

namespace Client.Logic.Players
{
    class PlayerCollection
    {
        ListPair<string, IPlayer> players;
        Object lockObject = new object();

        //public ListPair<string, IPlayer> Players {
        //    get { return players; }
        //}

        public PlayerCollection()
        {
            players = new ListPair<string, IPlayer>();
        }

        public IPlayer this[string connectionID]
        {
            get
            {
                lock (lockObject)
                {
                    if (players.ContainsKey(connectionID) == false)
                    {
                        return null;
                    }
                    else
                    {
                        return players[connectionID];
                    }
                }
            }
            set
            {
                lock (lockObject)
                {
                    players[connectionID] = value;
                }
            }
        }

        public void Clear()
        {
            lock (lockObject)
            {
                players.Clear();
            }
        }

        public void Add(string connectionID, IPlayer player)
        {
            lock (lockObject)
            {
                if (!players.ContainsKey(connectionID))
                {
                    players.Add(connectionID, player);
                }
                else
                {
                    players[connectionID] = player;
                }
            }
        }

        public void Remove(string connectionID)
        {
            lock (lockObject)
            {
                players.RemoveAtKey(connectionID);
            }
        }

        public IEnumerable<IPlayer> GetAllPlayers()
        {
            lock (lockObject)
            {
                foreach (IPlayer player in players.Values)
                {
                    yield return player;
                }
            }
        }
    }
}
