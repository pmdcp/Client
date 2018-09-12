using System;
using System.Collections.Generic;
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


namespace Client.Logic.Missions
{
    class Mission
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string GoalName { get; set; }
        public int ClientSpecies { get; set; }
        public int ClientForm { get; set; }
        public Enums.JobDifficulty Difficulty { get; set; }
        public Enums.MissionType MissionType { get; set; }
        public int Data1 { get; set; }
        public int Data2 { get; set; }
        public int RewardNum { get; set; }
        public int RewardAmount { get; set; }

        //public Mission(string missionName, string newSummary, string goal, int species, int form, JobDifficulty difficulty, int itemNum, int amount) {
        //    this.Title = missionName;
        //    this.Summary = newSummary;
        //    this.GoalName = goal;
        //    this.ClientSpecies = species;
        //    this.ClientForm = form;
        //    this.Difficulty = difficulty;
        //    this.RewardNum = itemNum;
        //    this.RewardAmount = amount;
        //}
    }
}