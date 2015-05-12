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

using Client.Logic.Graphics;

using SdlDotNet.Widgets;

namespace Client.Logic.Menus {
    class mnuBattleLog : Widgets.BorderedPanel, Core.IMenu {
        public bool Modal {
            get;
            set;
        }

        #region Fields

        Label lblBattleLog;
        Label lblBattleEntries;
        ListBox lstBattleEntries;

        #endregion Fields

        #region Constructors

        public mnuBattleLog(string name)
            : base(name) {
            this.Size = new Size(600, 440);
            this.MenuDirection = Enums.MenuDirection.Vertical;
            this.Location = new Point(10, 20);

            lblBattleLog = new Label("lblBattleLog");
            lblBattleLog.Location = new Point(20, 10);
            lblBattleLog.Font = FontManager.LoadFont("PMDCP", 36);
            lblBattleLog.AutoSize = true;
            lblBattleLog.Text = "Battle Log";
            lblBattleLog.ForeColor = Color.WhiteSmoke;

            lstBattleEntries = new ListBox("lstBattleEntries");
            lstBattleEntries.Location = new Point(16, 50);
            lstBattleEntries.Size = new Size(this.Width - lstBattleEntries.X * 2, this.Height - lstBattleEntries.Y - 20);
            lstBattleEntries.BackColor = Color.Transparent;
            lstBattleEntries.BorderStyle = SdlDotNet.Widgets.BorderStyle.None;

            this.AddWidget(lblBattleLog);
            this.AddWidget(lstBattleEntries);
            AddEntries();
        }

        #endregion Constructors
        #region Methods

        public override void OnKeyboardDown(SdlDotNet.Input.KeyboardEventArgs e) {
            base.OnKeyboardDown(e);
            switch (e.Key) {
                case SdlDotNet.Input.Key.Backspace: {
                        // Show the others menu when the backspace key is pressed
                        MenuSwitcher.ShowOthersMenu();
                        Music.Music.AudioPlayer.PlaySoundEffect("beep3.wav");
                    }
                    break;
            }
        }

        public Widgets.BorderedPanel MenuPanel {
            get { return this; }
        }

        public void AddEntries() {
            string[] messageArray = Logic.Logs.BattleLog.Messages.ToArray();
            Color[] colorArray = Logic.Logs.BattleLog.MessageColor.ToArray();

            for (int i = 0; i < messageArray.Length; i++) {
                ListBoxTextItem item = new ListBoxTextItem(FontManager.LoadFont("PMDCP", 16), messageArray[i]);
                item.ForeColor = colorArray[i];
                lstBattleEntries.Items.Add(item);
            }
            
        }

        #endregion Methods
    }
}
