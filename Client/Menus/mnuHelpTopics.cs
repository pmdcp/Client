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

namespace Client.Logic.Menus
{
    class mnuHelpTopics : Widgets.BorderedPanel, Core.IMenu
    {
        public bool Modal {
            get;
            set;
        }

        #region Fields

        Label lblHelpTopics;
        ListBox lstHelpTopics;
        Button btnShowHelp;

        #endregion Fields

        #region Constructors

        public mnuHelpTopics(string name)
            : base(name) {
            this.Size = new Size(185, 220);
            this.MenuDirection = Enums.MenuDirection.Vertical;
            this.Location = new Point(10, 40);

            lblHelpTopics = new Label("lblHelpTopics");
            lblHelpTopics.Location = new Point(20, 0);
            lblHelpTopics.Font = FontManager.LoadFont("PMDCP", 36);
            lblHelpTopics.AutoSize = true;
            lblHelpTopics.Text = "Help Topics";
            lblHelpTopics.ForeColor = Color.WhiteSmoke;

            lstHelpTopics = new ListBox("lstHelpTopics");
            lstHelpTopics.Location = new Point(10, 50);
            lstHelpTopics.Size = new Size(this.Width - lstHelpTopics.X * 2, this.Height - lstHelpTopics.Y - 10 - 30);
            lstHelpTopics.BackColor = Color.Transparent;
            lstHelpTopics.BorderStyle = SdlDotNet.Widgets.BorderStyle.None;

            btnShowHelp = new Button("btnShowHelp");
            btnShowHelp.Location = new Point(10, lstHelpTopics.Y + lstHelpTopics.Height + 5);
            btnShowHelp.Size = new Size(100, 30);
            btnShowHelp.Text = "Load Topic";
            Skins.SkinManager.LoadButtonGui(btnShowHelp);
            btnShowHelp.Click += new EventHandler<MouseButtonEventArgs>(btnShowHelp_Click);

            this.AddWidget(lblHelpTopics);
            this.AddWidget(lstHelpTopics);
            this.AddWidget(btnShowHelp);

            LoadHelpTopics();
        }

        void btnShowHelp_Click(object sender, MouseButtonEventArgs e) {
            if (lstHelpTopics.SelectedItems.Count > 0) {
                MenuSwitcher.ShowHelpPage(((ListBoxTextItem)lstHelpTopics.SelectedItems[0]).Text, 0);
                Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
            }
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

        public void LoadHelpTopics() {
            string[] dirs = System.IO.Directory.GetDirectories(IO.Paths.StartupPath + "Help");
            for (int i = 0; i < dirs.Length; i++) {
                ListBoxTextItem lbi = new ListBoxTextItem(Logic.Graphics.FontManager.LoadFont("tahoma", 10), System.IO.Path.GetFileNameWithoutExtension(dirs[i]));
                lbi.ForeColor = Color.WhiteSmoke;
                lstHelpTopics.Items.Add(lbi);
            }
        }

        public Widgets.BorderedPanel MenuPanel {
            get { return this; }
        }

        #endregion Methods
    }
}
