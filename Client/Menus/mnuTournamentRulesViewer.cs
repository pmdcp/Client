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
using Client.Logic.Graphics;
using SdlDotNet.Widgets;
using Client.Logic.Tournaments;

namespace Client.Logic.Menus
{
    class mnuTournamentRulesViewer : Widgets.BorderedPanel, Core.IMenu
    {
        public bool Modal {
            get;
            set;
        }

        Label lblViewRules;
        TournamentRules rules;

        Label lblSleepClause;
        Label lblAccuracyClause;
        Label lblSpeciesClause;
        Label lblFreezeClause;
        Label lblOHKOClause;
        Label lblSelfKOClause;

        public Widgets.BorderedPanel MenuPanel {
            get { return this; }
        }

        public mnuTournamentRulesViewer(string name, TournamentRules rules)
            : base(name) {

            this.rules = rules;

            base.Size = new Size(315, 360);
            base.MenuDirection = Enums.MenuDirection.Vertical;
            base.Location = new Point(10, 40);

            lblViewRules = new Label("lblViewRules");
            lblViewRules.AutoSize = true;
            lblViewRules.Font = FontManager.LoadFont("PMDCP", 48);
            lblViewRules.Text = "View Rules";
            lblViewRules.ForeColor = Color.WhiteSmoke;
            lblViewRules.Location = new Point(20, 0);

            lblSleepClause = new Label("lblSleepClause");
            lblSleepClause.Location = new Point(15, 48);
            lblSleepClause.Size = new System.Drawing.Size(200, 32);
            lblSleepClause.BackColor = Color.Transparent;
            lblSleepClause.Font = FontManager.LoadFont("PMDCP", 32);
            lblSleepClause.ForeColor = Color.WhiteSmoke;
            lblSleepClause.Text = "Sleep Clause: " + (rules.SleepClause ? "Yes" : "No");

            lblAccuracyClause = new Label("lblAccuracyClause");
            lblAccuracyClause.Location = new Point(15, 80);
            lblAccuracyClause.Size = new System.Drawing.Size(200, 32);
            lblAccuracyClause.BackColor = Color.Transparent;
            lblAccuracyClause.Font = FontManager.LoadFont("PMDCP", 32);
            lblAccuracyClause.ForeColor = Color.WhiteSmoke;
            lblAccuracyClause.Text = "Accuracy Clause: " + (rules.AccuracyClause ? "Yes" : "No");

            lblSpeciesClause = new Label("lblSpeciesClause");
            lblSpeciesClause.Location = new Point(15, 112);
            lblSpeciesClause.Size = new System.Drawing.Size(200, 32);
            lblSpeciesClause.BackColor = Color.Transparent;
            lblSpeciesClause.Font = FontManager.LoadFont("PMDCP", 32);
            lblSpeciesClause.ForeColor = Color.WhiteSmoke;
            lblSpeciesClause.Text = "Species Clause: " + (rules.SpeciesClause ? "Yes" : "No");

            lblFreezeClause = new Label("lblFreezeClause");
            lblFreezeClause.Location = new Point(15, 144);
            lblFreezeClause.Size = new System.Drawing.Size(200, 32);
            lblFreezeClause.BackColor = Color.Transparent;
            lblFreezeClause.Font = FontManager.LoadFont("PMDCP", 32);
            lblFreezeClause.ForeColor = Color.WhiteSmoke;
            lblFreezeClause.Text = "Freeze Clause: " + (rules.FreezeClause ? "Yes" : "No");

            lblOHKOClause = new Label("lblOHKOClause");
            lblOHKOClause.Location = new Point(15, 176);
            lblOHKOClause.Size = new System.Drawing.Size(200, 32);
            lblOHKOClause.BackColor = Color.Transparent;
            lblOHKOClause.Font = FontManager.LoadFont("PMDCP", 32);
            lblOHKOClause.ForeColor = Color.WhiteSmoke;
            lblOHKOClause.Text = "OHKO Clause: " + (rules.OHKOClause ? "Yes" : "No");

            lblSelfKOClause = new Label("lblSelfKOClause");
            lblSelfKOClause.Location = new Point(15, 208);
            lblSelfKOClause.Size = new System.Drawing.Size(200, 32);
            lblSelfKOClause.BackColor = Color.Transparent;
            lblSelfKOClause.Font = FontManager.LoadFont("PMDCP", 32);
            lblSelfKOClause.ForeColor = Color.WhiteSmoke;
            lblSelfKOClause.Text = "Self-KO Clause: " + (rules.SelfKOClause ? "Yes" : "No");

            this.AddWidget(lblSleepClause);
            this.AddWidget(lblAccuracyClause);
            this.AddWidget(lblSpeciesClause);
            this.AddWidget(lblFreezeClause);
            this.AddWidget(lblOHKOClause);
            this.AddWidget(lblSelfKOClause);
            this.AddWidget(lblViewRules);
        }

        public override void OnKeyboardDown(SdlDotNet.Input.KeyboardEventArgs e) {
            base.OnKeyboardDown(e);
            switch (e.Key) {
                case SdlDotNet.Input.Key.Backspace: {
                    Menus.MenuSwitcher.CloseAllMenus();
                    }
                    break;
            }
        }

    }
}
