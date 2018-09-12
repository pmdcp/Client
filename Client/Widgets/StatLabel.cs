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

namespace Client.Logic.Widgets
{
    class StatLabel : Panel
    {
        Label lblAtk;
        Label lblDef;
        Label lblSpd;
        Label lblSpclAtk;
        Label lblSpclDef;
        Label lblStats;

        public StatLabel(string name)
            : base(name)
        {
            base.BackColor = Color.Transparent;

            lblAtk = new Label("lblAtk");
            lblAtk.BackColor = Color.Transparent;
            lblAtk.ForeColor = Color.WhiteSmoke;
            lblAtk.Font = Logic.Graphics.FontManager.LoadFont("tahoma", 12);
            lblAtk.Location = new Point(5, 5);
            lblAtk.AutoSize = true;
            lblAtk.Text = "Atk";

            lblDef = new Label("lblDef");
            lblDef.BackColor = Color.Transparent;
            lblDef.ForeColor = Color.WhiteSmoke;
            lblDef.Font = Logic.Graphics.FontManager.LoadFont("tahoma", 12);
            lblDef.Location = new Point(lblAtk.X + lblAtk.Width + 5, 5);
            lblDef.AutoSize = true;
            lblDef.Text = "Def";

            lblSpd = new Label("lblSpd");
            lblSpd.BackColor = Color.Transparent;
            lblSpd.ForeColor = Color.WhiteSmoke;
            lblSpd.Font = Logic.Graphics.FontManager.LoadFont("tahoma", 12);
            lblSpd.Location = new Point(lblDef.X + lblDef.Width + 5, 5);
            lblSpd.AutoSize = true;
            lblSpd.Text = "Spd";

            lblSpclAtk = new Label("lblSpclAtk");
            lblSpclAtk.BackColor = Color.Transparent;
            lblSpclAtk.ForeColor = Color.WhiteSmoke;
            lblSpclAtk.Font = Logic.Graphics.FontManager.LoadFont("tahoma", 12);
            lblSpclAtk.Location = new Point(lblSpd.X + lblSpd.Width + 5, 5);
            lblSpclAtk.AutoSize = true;
            lblSpclAtk.Text = "Sp. Atk";

            lblSpclDef = new Label("lblSpclDef");
            lblSpclDef.BackColor = Color.Transparent;
            lblSpclDef.ForeColor = Color.WhiteSmoke;
            lblSpclDef.Font = Logic.Graphics.FontManager.LoadFont("tahoma", 12);
            lblSpclDef.Location = new Point(lblSpclAtk.X + lblSpclAtk.Width + 5, 5);
            lblSpclDef.AutoSize = true;
            lblSpclDef.Text = "Sp. Def";

            lblStats = new Label("lblStats");
            lblStats.BackColor = Color.Transparent;
            lblStats.ForeColor = Color.WhiteSmoke;
            lblStats.Font = Logic.Graphics.FontManager.LoadFont("tahoma", 12);
            lblStats.Location = new Point(5, 5);
            lblStats.AutoSize = true;
            lblStats.Text = "Stats";

            this.AddWidget(lblStats);
            // this.AddWidget(lblAtk);
            //this.AddWidget(lblDef);
            //this.AddWidget(lblSpd);
            //this.AddWidget(lblSpclAtk);
            //this.AddWidget(lblSpclDef);
        }

        string currentAtk;
        string currentDef;
        string currentSpd;
        string currentSpclAtk;
        string currentSpclDef;

        public void SetStats(string atk, string def, string spd, string spclAtk, string spclDef)
        {
            currentAtk = atk;
            currentDef = def;
            currentSpd = spd;
            currentSpclAtk = spclAtk;
            currentSpclDef = spclDef;
            lblStats.Text = "Atk: " + atk + " Def: " + def + " Spd: " + spd + " Sp. Atk: " + spclAtk + " Sp. Def: " + spclDef;
            //SetAtk(atk);
            //SetDef(def);
            //SetSpd(spd);
            //SetSpclAtk(spclAtk);
            //SetSpclDef(spclDef);
        }

        public void SetAtk(string atk)
        {
            //lblAtk.Text = "Atk: " + atk;
            //lblAtk.Location = new Point(5, 5);
            SetStats(atk, currentDef, currentSpd, currentSpclAtk, currentSpclDef);
        }

        public void SetDef(string def)
        {
            //lblDef.Text = "Def: " + def;
            //lblDef.Location = new Point(lblAtk.X + lblAtk.Width + 5, 5);
            SetStats(currentAtk, def, currentSpd, currentSpclAtk, currentSpclDef);
        }

        public void SetSpd(string spd)
        {
            //lblSpd.Text = "Spd: " + spd;
            //lblSpd.Location = new Point(lblDef.X + lblDef.Width + 5, 5);
            SetStats(currentAtk, currentDef, spd, currentSpclAtk, currentSpclDef);
        }

        public void SetSpclAtk(string spclAtk)
        {
            //lblSpclAtk.Text = "Sp. Atk: " + spclAtk;
            //lblSpclAtk.Location = new Point(lblSpd.X + lblSpd.Width + 5, 5);
            SetStats(currentAtk, currentDef, currentSpd, spclAtk, currentSpclDef);
        }

        public void SetSpclDef(string spclDef)
        {
            //lblSpclDef.Text = "Sp. Def: " + spclDef;
            //lblSpclDef.Location = new Point(lblSpclAtk.X + lblSpclAtk.Width + 5, 5);
            SetStats(currentAtk, currentDef, currentSpd, currentSpclAtk, spclDef);
        }
    }
}
