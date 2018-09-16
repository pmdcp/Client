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
using System.Text;
using System.Drawing;
using Client.Logic.Graphics;
using SdlDotNet.Widgets;
using Client.Logic.Tournaments;

namespace Client.Logic.Menus
{
    class mnuTournamentListing : Widgets.BorderedPanel, Core.IMenu
    {
        public bool Modal
        {
            get;
            set;
        }

        Enums.TournamentListingMode mode;
        Label[] lblActiveTournaments;
        Label lblJoinTournament;
        Widgets.MenuItemPicker itemPicker;
        public int currentTen;
        Label lblItemNum;
        TournamentListing[] listings;

        public Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }

        public mnuTournamentListing(string name, TournamentListing[] listings, Enums.TournamentListingMode mode)
            : base(name)
        {
            this.listings = listings;
            this.mode = mode;

            base.Size = new Size(315, 360);
            base.MenuDirection = Enums.MenuDirection.Vertical;
            base.Location = new Point(10, 40);

            itemPicker = new Widgets.MenuItemPicker("itemPicker");
            itemPicker.Location = new Point(18, 63);

            lblJoinTournament = new Label("lblJoinTournament");
            lblJoinTournament.AutoSize = true;
            lblJoinTournament.Font = FontManager.LoadFont("PMDCP", 48);
            if (mode == Enums.TournamentListingMode.Join)
            {
                lblJoinTournament.Text = "Join A Tournament";
            }
            else if (mode == Enums.TournamentListingMode.Spectate)
            {
                lblJoinTournament.Text = "Spectate In A Tournament";
            }
            lblJoinTournament.ForeColor = Color.WhiteSmoke;
            lblJoinTournament.Location = new Point(20, 0);

            lblItemNum = new Label("lblItemNum");
            //lblItemNum.Size = new Size(100, 30);
            lblItemNum.AutoSize = true;
            lblItemNum.Location = new Point(182, 15);
            lblItemNum.Font = FontManager.LoadFont("PMDCP", 32);
            lblItemNum.BackColor = Color.Transparent;
            lblItemNum.ForeColor = Color.WhiteSmoke;
            lblItemNum.Text = "";//"0/" + ((MaxInfo.MaxInv - 1) / 10 + 1);

            lblActiveTournaments = new Label[10];
            for (int i = 0; i < lblActiveTournaments.Length; i++)
            {
                lblActiveTournaments[i] = new Label("lblActiveTournaments" + i);
                //lblVisibleItems[i].AutoSize = true;
                //lblVisibleItems[i].Size = new Size(200, 32);
                lblActiveTournaments[i].Width = 200;
                lblActiveTournaments[i].Font = FontManager.LoadFont("PMDCP", 32);
                lblActiveTournaments[i].Location = new Point(35, (i * 30) + 48);
                //lblVisibleItems[i].HoverColor = Color.Red;
                lblActiveTournaments[i].ForeColor = Color.WhiteSmoke;
                lblActiveTournaments[i].Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblActiveTournament_Click);
                this.AddWidget(lblActiveTournaments[i]);
            }

            this.AddWidget(itemPicker);
            this.AddWidget(lblJoinTournament);
            this.AddWidget(lblItemNum);

            currentTen = 0;
            DisplayItems(currentTen * 10);
            ChangeSelected(0 % 10);
        }

        void lblActiveTournament_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            if (Players.PlayerManager.MyPlayer.GetInvItemNum(currentTen * 10 + Array.IndexOf(lblActiveTournaments, sender)) > 0)
            {
                ChangeSelected(Array.IndexOf(lblActiveTournaments, sender));

                Windows.WindowSwitcher.GameWindow.MenuManager.AddMenu(new Menus.mnuTournamentListingSelected("mnuTournamentListingSelected", listings[GetSelectedItemSlot()], mode));
                Windows.WindowSwitcher.GameWindow.MenuManager.SetActiveMenu("mnuTournamentListingSelected");


                Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
            }
        }

        public void DisplayItems(int startNum)
        {
            this.BeginUpdate();
            for (int i = 0; i < lblActiveTournaments.Length; i++)
            {
                if (startNum + i >= listings.Length)
                {
                    break;
                }
                lblActiveTournaments[i].Text = listings[startNum + i].Name;
            }
            this.EndUpdate();
        }

        public void ChangeSelected(int itemNum)
        {
            itemPicker.Location = new Point(18, 63 + (30 * itemNum));
            itemPicker.SelectedItem = itemNum;
        }

        private int GetSelectedItemSlot()
        {
            return itemPicker.SelectedItem + currentTen * 10;
        }

        public override void OnKeyboardDown(SdlDotNet.Input.KeyboardEventArgs e)
        {
            base.OnKeyboardDown(e);
            switch (e.Key)
            {
                case SdlDotNet.Input.Key.DownArrow:
                    {
                        if (itemPicker.SelectedItem >= 9 || itemPicker.SelectedItem + 1 + currentTen >= listings.Length)
                        {
                            ChangeSelected(0);
                            //DisplayItems(1);
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
                        if (itemPicker.SelectedItem <= 0)
                        {
                            ChangeSelected(System.Math.Min(9, (listings.Length - 1) % 10));
                        }
                        else
                        {
                            ChangeSelected(itemPicker.SelectedItem - 1);
                        }
                        Music.Music.AudioPlayer.PlaySoundEffect("beep1.wav");
                    }
                    break;
                case SdlDotNet.Input.Key.LeftArrow:
                    {
                        //int itemSlot = (currentTen + 1) - 10;//System.Math.Max(1, GetSelectedItemSlot() - (11 - itemPicker.SelectedItem));
                        if (currentTen <= 0)
                        {
                            currentTen = ((listings.Length - 1) / 10);
                        }
                        else
                        {
                            currentTen--;
                        }
                        DisplayItems(currentTen * 10);
                        Music.Music.AudioPlayer.PlaySoundEffect("beep4.wav");
                    }
                    break;
                case SdlDotNet.Input.Key.RightArrow:
                    {
                        //int itemSlot = currentTen + 1 + 10;
                        if (currentTen >= ((listings.Length - 1) / 10))
                        {
                            currentTen = 0;
                        }
                        else
                        {
                            currentTen++;
                        }
                        DisplayItems(currentTen * 10);
                        Music.Music.AudioPlayer.PlaySoundEffect("beep4.wav");
                    }
                    break;
                case SdlDotNet.Input.Key.Return:
                    {
                        Windows.WindowSwitcher.GameWindow.MenuManager.AddMenu(new Menus.mnuTournamentListingSelected("mnuTournamentListingSelected", listings[GetSelectedItemSlot()], mode));
                        Windows.WindowSwitcher.GameWindow.MenuManager.SetActiveMenu("mnuTournamentListingSelected");

                        Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
                    }
                    break;
                case SdlDotNet.Input.Key.Backspace:
                    {
                    }
                    break;
            }
        }
    }
}
