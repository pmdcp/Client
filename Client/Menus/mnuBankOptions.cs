﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using Client.Logic.Graphics;

using SdlDotNet.Widgets;
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


namespace Client.Logic.Menus
{
    class mnuBankOptions : Logic.Widgets.BorderedPanel, Core.IMenu
    {
        public bool Modal
        {
            get;
            set;
        }
        #region Fields

        const int MAX_ITEMS = 1;

        Logic.Widgets.MenuItemPicker itemPicker;
        Label lblDeposit;
        Label lblWithdraw;

        #endregion Fields

        #region Constructors

        public mnuBankOptions(string name)
            : base(name)
        {
            this.Size = new Size(155, 88);
            this.MenuDirection = Enums.MenuDirection.Vertical;
            this.Location = new Point(10, 40);

            itemPicker = new Logic.Widgets.MenuItemPicker("itemPicker");
            itemPicker.Location = new Point(18, 23);

            lblDeposit = new Label("lblDeposit");
            lblDeposit.AutoSize = true;
            lblDeposit.Location = new Point(30, 8);
            lblDeposit.Font = FontManager.LoadFont("PMDCP", 32);
            lblDeposit.Text = "Store";
            lblDeposit.HoverColor = Color.Red;
            lblDeposit.ForeColor = Color.WhiteSmoke;
            lblDeposit.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblDeposit_Click);

            lblWithdraw = new Label("lblWithdraw");
            lblWithdraw.AutoSize = true;
            lblWithdraw.Location = new Point(30, 38);
            lblWithdraw.Font = FontManager.LoadFont("PMDCP", 32);
            lblWithdraw.Text = "Take";
            lblWithdraw.HoverColor = Color.Red;
            lblWithdraw.ForeColor = Color.WhiteSmoke;
            lblWithdraw.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblWithdraw_Click);


            this.AddWidget(itemPicker);
            this.AddWidget(lblDeposit);
            this.AddWidget(lblWithdraw);
        }

        void lblDeposit_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(0);
        }

        void lblWithdraw_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(1);
        }



        #endregion Constructors

        #region Properties

        public Logic.Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }

        #endregion Properties

        #region Methods

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
            }
        }

        private void SelectItem(int itemNum)
        {
            switch (itemNum)
            {
                case 0:
                    {
                        MenuSwitcher.ShowBankDepositMenu(1);
                        Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
                    }
                    break;
                case 1:
                    {
                        MenuSwitcher.ShowBankWithdrawMenu(0);
                        Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
                    }
                    break;
            }
        }

        #endregion Methods
    }
}