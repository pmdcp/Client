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
    class mnuTeam : Widgets.BorderedPanel, Core.IMenu
    {
        public bool Modal
        {
            get;
            set;
        }
        #region Fields

        const int MAX_ITEMS = 3;

        Widgets.MenuItemPicker itemPicker;
        Label lblPoke;
        Label[] lblAllPoke;
        /*Label lblPoke1;
        Label lblPoke2;
        Label lblPoke3;
        Label lblPoke4;
        */
        #endregion Fields

        #region Constructors

        public mnuTeam(string name)
            : base(name)
        {
            this.Size = new Size(280, 188);
            this.MenuDirection = Enums.MenuDirection.Vertical;
            this.Location = new Point(10, 40);

            itemPicker = new Widgets.MenuItemPicker("itemPicker");
            itemPicker.Location = new Point(18, 63);

            lblPoke = new Label("lblPoke");
            lblPoke.Location = new Point(20, 0);
            lblPoke.AutoSize = true;
            lblPoke.Font = FontManager.LoadFont("PMDCP", 48);
            lblPoke.ForeColor = Color.WhiteSmoke;
            lblPoke.Text = "Team";

            lblAllPoke = new Label[4];
            for (int i = 0; i < 4; i++)
            {
                lblAllPoke[i] = new Label("lblAllPoke" + i);
                lblAllPoke[i].AutoSize = true;
                lblAllPoke[i].Font = FontManager.LoadFont("PMDCP", 32);
                lblAllPoke[i].Location = new Point(30, (i * 30) + 48);
                lblAllPoke[i].HoverColor = Color.Red;
                lblAllPoke[i].ForeColor = Color.WhiteSmoke;
                lblAllPoke[i].Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(team_Click);
                this.AddWidget(lblAllPoke[i]);
            }


            /*
            lblPoke1 = new Label("lblPoke1");
            lblPoke1.AutoSize = true;
            lblPoke1.Location = new Point(30, 48);
            lblPoke1.Font = FontManager.LoadFont("PMDCP", 32);
            lblPoke1.Text = "Pokemon 1";
            lblPoke1.HoverColor = Color.Red;

            lblPoke2 = new Label("lblPoke2");
            lblPoke2.AutoSize = true;
            lblPoke2.Location = new Point(30, 78);
            lblPoke2.Font = FontManager.LoadFont("PMDCP", 32);
            lblPoke2.Text = "Pokemon 2";
            lblPoke2.HoverColor = Color.Red;

            lblPoke3 = new Label("lblPoke3");
            lblPoke3.AutoSize = true;
            lblPoke3.Location = new Point(30, 108);
            lblPoke3.Font = FontManager.LoadFont("PMDCP", 32);
            lblPoke3.Text = "Pokemon 3";
            lblPoke3.HoverColor = Color.Red;

            lblPoke4 = new Label("lblPoke4");
            lblPoke4.AutoSize = true;
            lblPoke4.Location = new Point(30, 138);
            lblPoke4.Font = FontManager.LoadFont("PMDCP", 32);
            lblPoke4.Text = "Pokemon 4";
            lblPoke4.HoverColor = Color.Red;
            */

            this.AddWidget(itemPicker);

            this.AddWidget(lblPoke);
            /*this.AddWidget(lblPoke1);
            this.AddWidget(lblPoke2);
            this.AddWidget(lblPoke3);
            this.AddWidget(lblPoke4);
            */

            DisplayTeam();

            ChangeSelected(0);
        }

        void team_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(Array.IndexOf(lblAllPoke, sender));
        }

        #endregion Constructors

        #region Methods

        public void ChangeSelected(int itemNum)
        {
            itemPicker.Location = new Point(18, 63 + (30 * itemNum));
            itemPicker.SelectedItem = itemNum;
        }

        public override void OnKeyboardDown(SdlDotNet.Input.KeyboardEventArgs e)
        {
            base.OnKeyboardDown(e);
            switch (e.Key)
            {
                case SdlDotNet.Input.Key.DownArrow:
                    {
                        if (itemPicker.SelectedItem == MAX_ITEMS)
                        {
                            ChangeSelected(0);
                        }
                        else
                        {
                            ChangeSelected(itemPicker.SelectedItem + 1);
                        }
                        Music.Music.AudioPlayer.PlaySoundEffect("beep1.wav");
                    }
                    break;
                case SdlDotNet.Input.Key.UpArrow:
                    {
                        if (itemPicker.SelectedItem == 0)
                        {
                            ChangeSelected(MAX_ITEMS);
                        }
                        else
                        {
                            ChangeSelected(itemPicker.SelectedItem - 1);
                        }
                        Music.Music.AudioPlayer.PlaySoundEffect("beep1.wav");
                    }
                    break;
                case SdlDotNet.Input.Key.Return:
                    {
                        SelectItem(itemPicker.SelectedItem);
                    }
                    break;
                case SdlDotNet.Input.Key.Backspace:
                    {
                        MenuSwitcher.ShowMainMenu();
                        Music.Music.AudioPlayer.PlaySoundEffect("beep3.wav");
                    }
                    break;
            }
        }

        private void SelectItem(int itemNum)
        {
            if (!string.IsNullOrEmpty(Players.PlayerManager.MyPlayer.Team[itemNum].Name))
            {
                Windows.WindowSwitcher.GameWindow.MenuManager.AddMenu(new Menus.mnuTeamSelected("mnuTeamSelected", itemNum));
                Windows.WindowSwitcher.GameWindow.MenuManager.SetActiveMenu("mnuTeamSelected");
                Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
            }
        }

        public void DisplayTeam()
        {
            for (int i = 0; i < 4; i++)
            {
                if (!string.IsNullOrEmpty(Players.PlayerManager.MyPlayer.Team[i].Name))
                {
                    lblAllPoke[i].Text = Players.PlayerManager.MyPlayer.Team[i].Name;
                }
                else
                {
                    lblAllPoke[i].Text = "-----";
                    //lblAllMovesPP[i].Text = "--/--";
                }

                /*lblPoke1.Text = Players.PlayerManager.Players.GetMyPlayerRecruit(0).Name;
                lblPoke2.Text = Players.PlayerManager.Players.GetMyPlayerRecruit(1).Name;
                lblPoke3.Text = Players.PlayerManager.Players.GetMyPlayerRecruit(2).Name;
                lblPoke4.Text = Players.PlayerManager.Players.GetMyPlayerRecruit(3).Name;*/
            }
        }

        public Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }

        #endregion Methods
    }
}
