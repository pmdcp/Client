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
using Client.Logic.Network;


namespace Client.Logic.Menus
{
    class mnuJobSelected : Widgets.BorderedPanel, Core.IMenu
    {
        int jobSlot;
        Label lblAccept;
        Label lblDescription;
        Label lblDelete;
        Label lblSend;
        TextBox txtSend;
        Widgets.MenuItemPicker itemPicker;
        int maxItems;

        public int JobSlot
        {
            get { return jobSlot; }
            set
            {
                jobSlot = value;
            }
        }

        public Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }

        public mnuJobSelected(string name, int jobSlot)
            : base(name)
        {
            int size = 95;
            maxItems = 1;
            if (Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Finished ||
                Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Failed)
            {
            }
            else
            {
                size += 30;
                maxItems++;
            }
            if (Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].CanSend)
            {
                size += 60;
                maxItems++;
            }
            base.Size = new Size(180, size);
            base.MenuDirection = Enums.MenuDirection.Horizontal;
            base.Location = new Point(300, 34);

            itemPicker = new Widgets.MenuItemPicker("itemPicker");
            itemPicker.Location = new Point(18, 23);

            int locY = 8;

            if (Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Finished ||
                Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Failed)
            {
            }
            else
            {
                lblAccept = new Label("lblAccept");
                lblAccept.Font = FontManager.LoadFont("PMDCP", 32);
                lblAccept.AutoSize = true;
                if (Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Obtained ||
                    Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Suspended)
                {
                    lblAccept.Text = "Accept";
                }
                else if (Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Taken)
                {
                    lblAccept.Text = "Cancel";
                }
                lblAccept.Location = new Point(30, locY);
                lblAccept.HoverColor = Color.Red;
                lblAccept.ForeColor = Color.WhiteSmoke;
                lblAccept.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblAccept_Click);

                this.AddWidget(lblAccept);

                locY += 30;
            }



            lblDescription = new Label("lblDescription");
            lblDescription.Font = FontManager.LoadFont("PMDCP", 32);
            lblDescription.AutoSize = true;
            lblDescription.Text = "Description";
            lblDescription.Location = new Point(30, locY);
            lblDescription.HoverColor = Color.Red;
            lblDescription.ForeColor = Color.WhiteSmoke;
            lblDescription.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblDescription_Click);
            locY += 30;

            lblDelete = new Label("lblDelete");
            lblDelete.Font = FontManager.LoadFont("PMDCP", 32);
            lblDelete.AutoSize = true;
            lblDelete.Text = "Delete";
            lblDelete.Location = new Point(30, locY);
            lblDelete.HoverColor = Color.Red;
            lblDelete.ForeColor = Color.WhiteSmoke;
            lblDelete.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblDelete_Click);
            locY += 30;

            if (Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].CanSend)
            {
                lblSend = new Label("lblSend");
                lblSend.Font = FontManager.LoadFont("PMDCP", 32);
                lblSend.AutoSize = true;
                lblSend.Text = "Send to:";
                lblSend.Location = new Point(30, locY);
                lblSend.HoverColor = Color.Red;
                lblSend.ForeColor = Color.WhiteSmoke;
                lblSend.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblSend_Click);
                locY += 40;

                txtSend = new TextBox("txtSend");
                txtSend.Size = new Size(120, 24);
                txtSend.Location = new Point(32, locY);
                txtSend.Font = FontManager.LoadFont("PMDCP", 16);
                Skins.SkinManager.LoadTextBoxGui(txtSend);

                this.AddWidget(lblSend);
                this.AddWidget(txtSend);
            }


            this.AddWidget(itemPicker);
            this.AddWidget(lblDescription);
            this.AddWidget(lblDelete);

            this.jobSlot = jobSlot;
        }



        void lblAccept_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(0, jobSlot);
        }

        void lblDescription_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(1, jobSlot);
        }

        void lblDelete_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(2, jobSlot);
        }

        void lblSend_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(3, jobSlot);
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
                        SelectItem(itemPicker.SelectedItem, jobSlot);
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

        private void SelectItem(int itemNum, int jobSlot)
        {
            if (Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Finished ||
                Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Failed)
            {
                itemNum++;
            }
            switch (itemNum)
            {
                case 0:
                    { // Accept
                        if (Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Obtained ||
                            Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Suspended)
                        {
                            Messenger.SendStartMission(jobSlot);
                        }
                        else if (Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot].Accepted == Enums.JobStatus.Taken)
                        {
                            Messenger.SendCancelJob(jobSlot);
                        }
                        MenuSwitcher.ShowJobListMenu();
                        Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
                    }
                    break;
                case 1:
                    { // Description
                        MenuSwitcher.ShowJobSummary(Players.PlayerManager.MyPlayer.JobList.Jobs[jobSlot]);
                        Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
                    }
                    break;
                case 2:
                    { // Delete
                        Messenger.SendDeleteJob(jobSlot);
                        CloseMenu();
                        Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
                    }
                    break;
                case 3:
                    { // Send
                        Messenger.SendSendMission(jobSlot, txtSend.Text);
                        CloseMenu();
                        Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
                    }
                    break;
            }
        }

        private void CloseMenu()
        {
            Windows.WindowSwitcher.GameWindow.MenuManager.RemoveMenu(this);
            Windows.WindowSwitcher.GameWindow.MenuManager.SetActiveMenu("mnuJobList");
        }



        public bool Modal
        {
            get;
            set;
        }
    }
}
