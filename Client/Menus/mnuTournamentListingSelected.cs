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
using PMDCP.Core;
using SdlDotNet.Widgets;
using Client.Logic.Network;
using Client.Logic.Tournaments;


namespace Client.Logic.Menus
{
    class mnuTournamentListingSelected : Widgets.BorderedPanel, Core.IMenu
    {
        public bool Modal
        {
            get;
            set;
        }

        Label lblJoin;
        Label lblViewRules;
        Widgets.MenuItemPicker itemPicker;
        const int MAX_ITEMS = 1;
        TournamentListing selectedListing;
        Enums.TournamentListingMode mode;

        public Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }

        public mnuTournamentListingSelected(string name, TournamentListing selectedListing, Enums.TournamentListingMode mode)
            : base(name)
        {
            this.selectedListing = selectedListing;
            this.mode = mode;

            base.Size = new Size(185, 125);

            base.MenuDirection = Enums.MenuDirection.Horizontal;
            base.Location = new Point(335, 40);

            itemPicker = new Widgets.MenuItemPicker("itemPicker");
            itemPicker.Location = new Point(18, 23);

            lblJoin = new Label("lblJoin");
            lblJoin.Font = FontManager.LoadFont("PMDCP", 32);
            lblJoin.AutoSize = true;
            if (mode == Enums.TournamentListingMode.Join)
            {
                lblJoin.Text = "Join";
            }
            else if (mode == Enums.TournamentListingMode.Spectate)
            {
                lblJoin.Text = "Spectate";
            }
            lblJoin.Location = new Point(30, 8);
            lblJoin.HoverColor = Color.Red;
            lblJoin.ForeColor = Color.WhiteSmoke;
            lblJoin.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblJoin_Click);

            lblViewRules = new Label("lblViewRules");
            lblViewRules.Font = FontManager.LoadFont("PMDCP", 32);
            lblViewRules.AutoSize = true;
            lblViewRules.Text = "View Rules";
            lblViewRules.Location = new Point(30, 58);
            lblViewRules.HoverColor = Color.Red;
            lblViewRules.ForeColor = Color.WhiteSmoke;
            lblViewRules.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblViewRules_Click);

            this.AddWidget(itemPicker);
            this.AddWidget(lblJoin);
            this.AddWidget(lblViewRules);
        }

        void lblViewRules_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(1);
        }


        void lblJoin_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(0);
        }

        public void ChangeSelected(int itemNum)
        {
            itemPicker.Location = new Point(18, 23 + (50 * itemNum));
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
                        CloseMenu();
                        Music.Music.AudioPlayer.PlaySoundEffect("beep3.wav");
                    }
                    break;
            }
        }


        private void SelectItem(int selectedItem)
        {
            switch (selectedItem)
            {
                case 0:
                    { // Join tournament / Spectate
                        if (mode == Enums.TournamentListingMode.Join)
                        {
                            Messenger.SendJoinTournament(selectedListing.TournamentID);
                        }
                        else if (mode == Enums.TournamentListingMode.Spectate)
                        {
                            Messenger.SendSpectateTournament(selectedListing.TournamentID);
                        }
                        MenuSwitcher.CloseAllMenus();
                    }
                    break;
                case 1:
                    { // View tournament rules
                        Messenger.SendViewTournamentRules(selectedListing.TournamentID);
                        MenuSwitcher.CloseAllMenus();
                    }
                    break;
            }
        }

        private void CloseMenu()
        {
            Windows.WindowSwitcher.GameWindow.MenuManager.RemoveMenu(this);
        }
    }
}
