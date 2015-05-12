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
using System.Drawing;
using System.Text;
using PMDCP.Core;
using SdlDotNet.Widgets;
using Client.Logic.Players.Parties;

namespace Client.Logic.ExpKit.Modules
{
    class kitParty : Panel, IKitModule
    {
        int moduleIndex;
        Size containerSize;
        PictureBox[] picMemberMugshot;
        Label[] lblMemberName;
        ProgressBar[] pgbMemberHP;
        ProgressBar[] pgbMemberExp;

        bool enabled;

        const int PARTY_SIZE = 4;

        public kitParty(string name)
            : base(name) {
            enabled = true;

            base.BackColor = Color.Transparent;
            picMemberMugshot = new PictureBox[PARTY_SIZE];
            for (int i = 0; i < PARTY_SIZE; i++) {
                picMemberMugshot[i] = new PictureBox("picMemberMugshot" + i);
                picMemberMugshot[i].Size = new Size(40, 40);
                picMemberMugshot[i].BorderStyle = SdlDotNet.Widgets.BorderStyle.FixedSingle;
                picMemberMugshot[i].BorderWidth = 1;
                picMemberMugshot[i].BorderColor = Color.Black;

                picMemberMugshot[i].X = 10;

                this.AddWidget(picMemberMugshot[i]);
            }
            lblMemberName = new Label[PARTY_SIZE];
            for (int i = 0; i < PARTY_SIZE; i++) {
                lblMemberName[i] = new Label("lblMemberName" + i);
                lblMemberName[i].AutoSize = true;
                lblMemberName[i].Font = Logic.Graphics.FontManager.LoadFont("PMDCP", 24);
                lblMemberName[i].ForeColor = Color.WhiteSmoke;

                this.AddWidget(lblMemberName[i]);
            }
            pgbMemberHP = new ProgressBar[PARTY_SIZE];
            pgbMemberExp = new ProgressBar[PARTY_SIZE];
            for (int i = 0; i < PARTY_SIZE; i++) {
                pgbMemberHP[i] = new ProgressBar("pgbMemberHP" + i);
                pgbMemberExp[i] = new ProgressBar("pgbMemberExp" + i);

                pgbMemberHP[i].Maximum = 100;
                pgbMemberHP[i].TextStyle = ProgressBarTextStyle.Custom;

                pgbMemberExp[i].Maximum = 100;
                pgbMemberExp[i].TextStyle = ProgressBarTextStyle.Custom;

                this.AddWidget(pgbMemberHP[i]);
                this.AddWidget(pgbMemberExp[i]);
            }
        }

        public void Created(int index) {
            moduleIndex = index;
        }

        public void SwitchOut() {

        }

        public void Initialize(Size containerSize) {
            this.containerSize = containerSize;
            RecalculatePositions();
            for (int i = 0; i < picMemberMugshot.Length; i++) {
                DisplayPartyMemberData(i);
            }
            this.RequestRedraw();
        }

        private void RecalculatePositions() {
            for (int i = 0; i < PARTY_SIZE; i++) {
                picMemberMugshot[i].Visible = false;
                lblMemberName[i].Visible = false;
                pgbMemberHP[i].Visible = false;
                pgbMemberExp[i].Visible = false;

                picMemberMugshot[i].Y = (80 * i + 30);
                lblMemberName[i].Location = new Point(5, 80 * i);
                pgbMemberHP[i].Location = new Point(picMemberMugshot[i].X + 45, 80 * i + 32);
                pgbMemberExp[i].Location = new Point(picMemberMugshot[i].X + 45, 80 * i + 52);

                pgbMemberHP[i].Size = new Size(this.containerSize.Width - picMemberMugshot[i].X - picMemberMugshot[i].Width - 10, 15);
                pgbMemberExp[i].Size = new Size(this.containerSize.Width - picMemberMugshot[i].X - picMemberMugshot[i].Width - 10, 15);
            }
        }

        public void DisplayPartyMemberData(int slot) {
            PartyData party = Players.PlayerManager.MyPlayer.Party;
            if (party != null) {
                PartyMember member = party.Members[slot];
                if (member != null) {
                    picMemberMugshot[slot].Image = Logic.Graphics.GraphicsManager.GetMugshot(member.MugshotNum, member.MugshotForm, (int)member.MugshotShiny, (int)member.MugshotGender).GetEmote(0);//Tools.CropImage(Logic.Graphics.GraphicsManager.Speakers, new Rectangle(((member.Mugshot - 1) % 15) * 40, ((member.Mugshot - 1) / 15) * 40, 40, 40));
                    lblMemberName[slot].Text = member.Name;

                    pgbMemberHP[slot].Value = MathFunctions.CalculatePercent(member.HP, member.MaxHP);
                    pgbMemberExp[slot].Value = (int)MathFunctions.CalculatePercent(member.Exp, member.MaxExp);

                    pgbMemberHP[slot].Text = "HP: " + member.HP + "/" + member.MaxHP;
                    pgbMemberExp[slot].Text = "Exp: " + pgbMemberExp[slot].Percent + "%";

                    if (member.HP < member.MaxHP / 5) {
                        pgbMemberHP[slot].BarColor = Color.Red;
                    } else if (member.HP < member.MaxHP / 2) {
                        pgbMemberHP[slot].BarColor = Color.Yellow;
                    } else {
                        pgbMemberHP[slot].BarColor = Color.Green;
                    }

                    ChangeSlotVisibility(slot, true);
                } else {
                    ChangeSlotVisibility(slot, false);
                }
            } else {
                ChangeSlotVisibility(slot, false);
            }
        }

        public void ChangeSlotVisibility(int slot, bool visible) {
            picMemberMugshot[slot].Visible = visible;
            lblMemberName[slot].Visible = visible;
            pgbMemberHP[slot].Visible = visible;
            pgbMemberExp[slot].Visible = visible;
        }

        public int ModuleIndex {
            get { return moduleIndex; }
        }

        public string ModuleName {
            get { return "Party"; }
        }

        public Panel ModulePanel {
            get { return this; }
        }

        public bool Enabled {
            get { return enabled; }
            set {
                enabled = value;
                if (EnabledChanged != null)
                    EnabledChanged(this, EventArgs.Empty);
            }
        }


        public event EventHandler EnabledChanged;


        public Enums.ExpKitModules ModuleID {
            get { return Enums.ExpKitModules.Party; }
        }
    }
}
