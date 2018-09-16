﻿// This file is part of Mystery Dungeon eXtended.

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
    class mnuRecruitSelected : Widgets.BorderedPanel, Core.IMenu
    {
        int recruitSlot;
        Label lblJoinTeam;
        Label lblMakeLeader;
        Label lblStandby;
        Label lblRelease;
        Label lblRename;
        TextBox txtRename;
        Widgets.MenuItemPicker itemPicker;
        int maxItems;
        int activeTeamStatus;

        public int RecruitSlot
        {
            get { return recruitSlot; }
            set
            {
                recruitSlot = value;
            }
        }

        public Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }

        public mnuRecruitSelected(string name, int recruitSlot, int activeTeamStatus)
            : base(name)
        {
            if (activeTeamStatus == 0)
            {
                maxItems = 0;
                base.Size = new Size(165, 95);
            }
            else if (activeTeamStatus == -1)
            {
                maxItems = 1;
                base.Size = new Size(165, 95);
            }
            else
            {
                maxItems = 2;
                base.Size = new Size(165, 155);
            }
            base.MenuDirection = Enums.MenuDirection.Horizontal;
            base.Location = new Point(310, 40);






            if (activeTeamStatus == 0)
            {
                lblRename = new Label("lblRename");
                lblRename.Font = FontManager.LoadFont("PMDCP", 32);
                lblRename.AutoSize = true;
                lblRename.Text = "Rename:";
                lblRename.Location = new Point(30, 8);
                lblRename.ForeColor = Color.WhiteSmoke;
                //lblRename.HoverColor = Color.Red;
                //lblRename.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblRename_Click);
                this.AddWidget(lblRename);

                txtRename = new TextBox("txtRename");
                txtRename.Size = new Size(120, 24);
                txtRename.Location = new Point(32, 43);
                txtRename.Font = FontManager.LoadFont("PMDCP", 16);
                this.AddWidget(txtRename);
            }
            else if (activeTeamStatus > 0 && activeTeamStatus < 4)
            {
                lblMakeLeader = new Label("lblMakeLeader");
                lblMakeLeader.Font = FontManager.LoadFont("PMDCP", 32);
                lblMakeLeader.AutoSize = true;
                lblMakeLeader.Text = "Make Leader";
                lblMakeLeader.Location = new Point(30, 8);
                lblMakeLeader.ForeColor = Color.WhiteSmoke;
                //lblMakeLeader.HoverColor = Color.Red;
                //lblMakeLeader.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblMakeLeader_Click);
                this.AddWidget(lblMakeLeader);

                lblStandby = new Label("lblStandby");
                lblStandby.Font = FontManager.LoadFont("PMDCP", 32);
                lblStandby.AutoSize = true;
                lblStandby.Text = "Standby";
                lblStandby.Location = new Point(30, 38);
                lblStandby.ForeColor = Color.WhiteSmoke;
                //lblStandby.HoverColor = Color.Red;
                //lblStandby.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblStandby_Click);
                this.AddWidget(lblStandby);

                lblRename = new Label("lblRename");
                lblRename.Font = FontManager.LoadFont("PMDCP", 32);
                lblRename.AutoSize = true;
                lblRename.Text = "Rename:";
                lblRename.Location = new Point(30, 68);
                lblRename.ForeColor = Color.WhiteSmoke;
                //lblRename.HoverColor = Color.Red;
                //lblRename.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblRename_Click);
                this.AddWidget(lblRename);

                txtRename = new TextBox("txtRename");
                txtRename.Size = new Size(120, 24);
                txtRename.Location = new Point(32, 103);
                txtRename.Font = FontManager.LoadFont("PMDCP", 16);
                this.AddWidget(txtRename);
            }
            else
            {
                lblJoinTeam = new Label("lblJoinTeam");
                lblJoinTeam.Font = FontManager.LoadFont("PMDCP", 32);
                lblJoinTeam.AutoSize = true;
                lblJoinTeam.Text = "Join Team";
                lblJoinTeam.Location = new Point(30, 8);
                lblJoinTeam.ForeColor = Color.WhiteSmoke;
                //lblJoinTeam.HoverColor = Color.Red;
                //lblJoinTeam.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblJoinTeam_Click);

                this.AddWidget(lblJoinTeam);

                lblRelease = new Label("lblRelease");
                lblRelease.Font = FontManager.LoadFont("PMDCP", 32);
                lblRelease.AutoSize = true;
                lblRelease.Text = "Release";
                lblRelease.Location = new Point(30, 38);
                lblRelease.ForeColor = Color.WhiteSmoke;
                //lblRelease.HoverColor = Color.Red;
                //lblRelease.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblRelease_Click);
                this.AddWidget(lblRelease);
            }

            itemPicker = new Widgets.MenuItemPicker("itemPicker");
            itemPicker.Location = new Point(18, 23);
            this.AddWidget(itemPicker);

            this.RecruitSlot = recruitSlot;
            this.activeTeamStatus = activeTeamStatus;
        }



        void lblJoinTeam_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(0, activeTeamStatus, recruitSlot);
        }

        void lblMakeLeader_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(1, activeTeamStatus, recruitSlot);
        }

        void lblStandby_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(2, activeTeamStatus, recruitSlot);
        }

        void lblRelease_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(3, activeTeamStatus, recruitSlot);
        }

        void lblRename_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(3, activeTeamStatus, recruitSlot);
        }

        public void ChangeSelected(int itemNum)
        {
            itemPicker.Location = new Point(18, 23 + (30 * itemNum));
            itemPicker.SelectedItem = itemNum;
        }

        public override void OnKeyboardDown(SdlDotNet.Input.KeyboardEventArgs e)
        {
            base.OnKeyboardDown(e);
            switch (e.Key)
            {
                case SdlDotNet.Input.Key.DownArrow:
                    {
                        if (itemPicker.SelectedItem == maxItems)
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
                            ChangeSelected(maxItems);
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
                        SelectItem(itemPicker.SelectedItem, activeTeamStatus, recruitSlot);
                    }
                    break;
                case SdlDotNet.Input.Key.Backspace:
                    {
                        CloseMenu();
                        Music.Music.AudioPlayer.PlaySoundEffect("beep1.wav");
                    }
                    break;
            }
        }

        private void SelectItem(int itemNum, int menuType, int recruitSlot)
        {
            if (menuType == 0)
            {
                menuType = 2;
            }
            else if (menuType > 0 && menuType < 4)
            {
                menuType = 1;
            }
            else
            {
                menuType = 0;
            }

            if (menuType == 1 && itemNum == 0)
            {
                //Make Leader
                Network.Messenger.SendSwitchLeader(activeTeamStatus);
                CloseMenu();
            }
            else if (menuType == 1 && itemNum == 1)
            {
                //standby
                Network.Messenger.SendStandbyFromTeam(activeTeamStatus);
                CloseMenu();
            }
            else if (menuType == 0 && itemNum == 0)
            {
                //join team
                int freeSlot = -1;
                for (int i = 1; i < 4; i++)
                {
                    if (Players.PlayerManager.MyPlayer.Team[i] == null || Players.PlayerManager.MyPlayer.Team[i].Loaded == false)
                    {
                        freeSlot = i;
                        break;
                    }
                }
                if (freeSlot == -1)
                {
                    //tell it's not possible
                }
                else
                {
                    Network.Messenger.SendAddToTeam(freeSlot, recruitSlot);
                }
                CloseMenu();
            }
            else if (menuType == 0 && itemNum == 1)
            {
                //farewell
                Network.Messenger.SendReleaseRecruit(recruitSlot);
                CloseMenu();
                MenuSwitcher.CloseAllMenus();
            }
            else if (menuType == 2 || itemNum == 2)
            {
                //rename
                //if (txtRename.Text != "") {
                Network.Messenger.SendChangeRecruitName(activeTeamStatus, txtRename.Text);
                //}
                CloseMenu();
            }
            Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");

            /*
            switch (itemNum)
            {
                case 0:
                    { // Use move
                        Players.PlayerManager.MyPlayer.UseMove(moveSlot);
                        CloseMenu();
                    }
                    break;
                case 1:
                    { // Shift Up
                        if (moveSlot > 0)
                        {
                            Players.PlayerManager.MyPlayer.ShiftMove(moveSlot, true);
                            CloseMenu();
                        }
                    }
                    break;
                case 2:
                    { // Shift Down
                        if (moveSlot < 3)
                        {
                            Players.PlayerManager.MyPlayer.ShiftMove(moveSlot, false);
                            CloseMenu();
                        }
                    }
                    break;
                case 3:
                    { // Forget move
                        Players.PlayerManager.MyPlayer.ForgetMove(moveSlot);
                        CloseMenu();
                    }
                    break;
            }
            */
        }

        private void CloseMenu()
        {
            Windows.WindowSwitcher.GameWindow.MenuManager.RemoveMenu(this);
            Windows.WindowSwitcher.GameWindow.MenuManager.SetActiveMenu("mnuAssembly");
        }



        public bool Modal
        {
            get;
            set;
        }
    }
}
