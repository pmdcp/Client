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
using System.Drawing;
using Client.Logic.Players;

namespace Client.Logic
{
    /// <summary>
    /// Description of Ranks.
    /// </summary>
    internal class Ranks
    {
        /// <summary>
        /// Checks if the player has the specified rank permissions
        /// </summary>
        /// <param name="index">The index of the player to check</param>
        /// <param name="RankToCheck">The rank permissions to test</param>
        /// <returns>True if the player has the rank permissions; otherwise, false</returns>
        public static bool IsAllowed(IPlayer player, Enums.Rank RankToCheck)
        {
            Enums.Rank PlayerRank = player.Access;
            switch (RankToCheck)
            {
                case Enums.Rank.Normal:
                    return true;
                case Enums.Rank.Monitor:
                    if (PlayerRank == Enums.Rank.Monitor || PlayerRank == Enums.Rank.Mapper || PlayerRank == Enums.Rank.Developer || PlayerRank == Enums.Rank.Admin || PlayerRank == Enums.Rank.ServerHost || PlayerRank == Enums.Rank.Scriptor)
                    {
                        return true;
                    }
                    break;
                case Enums.Rank.Mapper:
                    if (PlayerRank == Enums.Rank.Mapper || PlayerRank == Enums.Rank.Developer || PlayerRank == Enums.Rank.Admin || PlayerRank == Enums.Rank.ServerHost || PlayerRank == Enums.Rank.Scriptor)
                    {
                        return true;
                    }
                    break;
                case Enums.Rank.Developer:
                    if (PlayerRank == Enums.Rank.Developer || PlayerRank == Enums.Rank.Admin || PlayerRank == Enums.Rank.ServerHost || PlayerRank == Enums.Rank.Scriptor)
                    {
                        return true;
                    }
                    break;
                case Enums.Rank.Admin:
                    if (PlayerRank == Enums.Rank.Admin || PlayerRank == Enums.Rank.ServerHost || PlayerRank == Enums.Rank.Scriptor)
                    {
                        return true;
                    }
                    break;
                case Enums.Rank.ServerHost:
                    if (PlayerRank == Enums.Rank.ServerHost || PlayerRank == Enums.Rank.Scriptor)
                    {
                        return true;
                    }
                    break;
                case Enums.Rank.Scriptor:
                    if (PlayerRank == Enums.Rank.Scriptor)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        /// <summary>
        /// Checks if the player does not have the specified rank permissions
        /// </summary>
        /// <param name="index">The index of the player to check</param>
        /// <param name="RankToCheck">The rank permissions to test</param>
        /// <returns>True if the player does not have the rank permissions; otherwise, false</returns>
        public static bool IsDisallowed(IPlayer player, Enums.Rank RankToCheck)
        {
            return !IsAllowed(player, RankToCheck);
        }

        /// <summary>
        /// Gets the color associated with the specified rank
        /// </summary>
        /// <param name="rank">The rank used to determine the color returned</param>
        /// <returns>The color associated with the specified rank</returns>
        public static Color GetRankColor(Enums.Rank rank)
        {
            switch (rank)
            {
                case Enums.Rank.Normal:
                    return Color.FromArgb(0xff7b7b);
                case Enums.Rank.Monitor:
                    return Color.FromArgb(0xffc663);
                case Enums.Rank.Mapper:
                    return Color.FromArgb(0xffffff);
                case Enums.Rank.Developer:
                    return Color.FromArgb(0x009cff);
                case Enums.Rank.Admin:
                    return Color.FromArgb(0xffcece);
                case Enums.Rank.ServerHost:
                    return Color.FromArgb(0xffff00);
                case Enums.Rank.Scriptor:
                    return Color.FromArgb(0xffffa5);
                default:
                    return Color.DarkRed;
            }
        }
    }
}
