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

namespace Client.Logic.Missions
{
    static class MissionManager
    {
        public static int DetermineMissionExpReward(Enums.JobDifficulty difficulty)
        {
            switch (difficulty)
            {
                case Enums.JobDifficulty.E:
                    return 10;
                case Enums.JobDifficulty.D:
                    return 15;
                case Enums.JobDifficulty.C:
                    return 20;
                case Enums.JobDifficulty.B:
                    return 30;
                case Enums.JobDifficulty.A:
                    return 50;
                case Enums.JobDifficulty.S:
                    return 70;
                case Enums.JobDifficulty.Star:
                    return 100;
                case Enums.JobDifficulty.TwoStar:
                    return 200;
                case Enums.JobDifficulty.ThreeStar:
                    return 300;
                case Enums.JobDifficulty.FourStar:
                    return 400;
                case Enums.JobDifficulty.FiveStar:
                    return 500;
                case Enums.JobDifficulty.SixStar:
                    return 700;
                case Enums.JobDifficulty.SevenStar:
                    return 1000;
                case Enums.JobDifficulty.EightStar:
                    return 1300;
                case Enums.JobDifficulty.NineStar:
                    return 1500;
                default:
                    return 0;
            }
        }

        public static int DetermineMissionExpRequirement(Enums.ExplorerRank rank)
        {
            switch (rank)
            {
                case Enums.ExplorerRank.Normal:
                    return 0;
                case Enums.ExplorerRank.Bronze:
                    return 100;
                case Enums.ExplorerRank.Silver:
                    return 300;
                case Enums.ExplorerRank.Gold:
                    return 1600;
                case Enums.ExplorerRank.Diamond:
                    return 3200;
                case Enums.ExplorerRank.Super:
                    return 5000;
                case Enums.ExplorerRank.Ultra:
                    return 7500;
                case Enums.ExplorerRank.Hyper:
                    return 10500;
                case Enums.ExplorerRank.Master:
                    return 13500;
                case Enums.ExplorerRank.MasterX:
                    return 17000;
                case Enums.ExplorerRank.MasterXX:
                    return 21000;
                case Enums.ExplorerRank.MasterXXX:
                    return 25000;
                case Enums.ExplorerRank.Guildmaster:
                    return 100000;
                default:
                    return -1;
            }
        }


        public static string RankToString(Enums.ExplorerRank rank)
        {
            switch (rank)
            {
                case Enums.ExplorerRank.Normal:
                case Enums.ExplorerRank.Bronze:
                case Enums.ExplorerRank.Silver:
                case Enums.ExplorerRank.Gold:
                case Enums.ExplorerRank.Diamond:
                case Enums.ExplorerRank.Super:
                case Enums.ExplorerRank.Ultra:
                case Enums.ExplorerRank.Hyper:
                case Enums.ExplorerRank.Master:
                case Enums.ExplorerRank.Guildmaster:
                    return rank.ToString();
                case Enums.ExplorerRank.MasterX:
                    return "Master*";
                case Enums.ExplorerRank.MasterXX:
                    return "Master**";
                case Enums.ExplorerRank.MasterXXX:
                    return "Master***";
                default:
                    return "???";
            }
        }

        public static string DifficultyToString(Enums.JobDifficulty difficulty)
        {
            switch (difficulty)
            {
                case Enums.JobDifficulty.E:
                case Enums.JobDifficulty.D:
                case Enums.JobDifficulty.C:
                case Enums.JobDifficulty.B:
                case Enums.JobDifficulty.A:
                case Enums.JobDifficulty.S:
                    return difficulty.ToString();
                case Enums.JobDifficulty.Star:
                    return "*1";
                case Enums.JobDifficulty.TwoStar:
                    return "*2";
                case Enums.JobDifficulty.ThreeStar:
                    return "*3";
                case Enums.JobDifficulty.FourStar:
                    return "*4";
                case Enums.JobDifficulty.FiveStar:
                    return "*5";
                case Enums.JobDifficulty.SixStar:
                    return "*6";
                case Enums.JobDifficulty.SevenStar:
                    return "*7";
                case Enums.JobDifficulty.EightStar:
                    return "*8";
                case Enums.JobDifficulty.NineStar:
                    return "*9";
                default:
                    return "?";
            }
        }
    }
}
