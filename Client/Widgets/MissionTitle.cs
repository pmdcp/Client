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
using SdlDotNet.Widgets;
using System.Drawing;
using Client.Logic.Graphics;
using Client.Logic.Missions;

namespace Client.Logic.Widgets
{
    class MissionTitle : Panel
    {
        Label lblJobName;
        Label lblDifficulty;
        Label lblGoal;

        public MissionTitle(string name, int containerWidth)
            : base(name) {
            base.BackColor = Color.Transparent;

            base.Size = new Size(containerWidth - 20, 40);

            lblJobName = new Label("lblJobName");
            lblJobName.Font = FontManager.LoadFont("PMDCP", 16);
            lblJobName.Location = new Point(15, 0);
            lblJobName.AutoSize = true;
            lblJobName.ForeColor = Color.WhiteSmoke;

            lblDifficulty = new Label("lblDifficulty");
            lblDifficulty.Location = new Point(containerWidth - 40, 5);
            lblDifficulty.Font = FontManager.LoadFont("PMDCP", 16);
            lblDifficulty.AutoSize = true;
            lblDifficulty.ForeColor = Color.WhiteSmoke;

            lblGoal = new Label("lblGoal");
            lblGoal.Font = FontManager.LoadFont("PMDCP", 16);
            lblGoal.Location = new Point(lblJobName.X, lblJobName.Y + 16);
            lblGoal.AutoSize = true;
            lblGoal.ForeColor = Color.WhiteSmoke;

            this.AddWidget(lblJobName);
            this.AddWidget(lblDifficulty);
            this.AddWidget(lblGoal);
        }

        public void SetJob(Job job) {
            if (job != null) {
                if (job.Accepted == Enums.JobStatus.Taken) {
                    lblJobName.ForeColor = Color.Yellow;
                    lblGoal.ForeColor = Color.Yellow;
                    lblDifficulty.ForeColor = Color.Yellow;
                } else if (job.Accepted == Enums.JobStatus.Failed) {
                    lblJobName.ForeColor = Color.Red;
                    lblGoal.ForeColor = Color.Red;
                    lblDifficulty.ForeColor = Color.Red;
                } else if (job.Accepted == Enums.JobStatus.Finished) {
                    lblJobName.ForeColor = Color.LightGreen;
                    lblGoal.ForeColor = Color.LightGreen;
                    lblDifficulty.ForeColor = Color.LightGreen;
                } else {
                    lblJobName.ForeColor = Color.WhiteSmoke;
                    lblGoal.ForeColor = Color.WhiteSmoke;
                    lblDifficulty.ForeColor = Color.WhiteSmoke;
                }
                lblJobName.Text = job.Title;
                lblDifficulty.Text = MissionManager.DifficultyToString(job.Difficulty);
                lblDifficulty.Location = new Point(this.Width - lblDifficulty.Width - 40, 0);
                lblGoal.Text = job.GoalName;
            } else {
                lblJobName.ForeColor = Color.Gray;
                lblJobName.Text = "----------";
                lblDifficulty.Text = "";
                lblDifficulty.Location = new Point(this.Width - lblDifficulty.Width - 40, 0);
                lblGoal.Text = "";
            }
        }


    }
}
