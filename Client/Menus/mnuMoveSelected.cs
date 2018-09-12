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
    class mnuMoveSelected : Widgets.BorderedPanel, Core.IMenu
    {
        int moveSlot;
        Label lblUse;
        Label lblShiftUp;
        Label lblShiftDown;
        Label lblForget;
        Widgets.MenuItemPicker itemPicker;
        const int MAX_ITEMS = 3;

        public int MoveSlot
        {
            get { return moveSlot; }
            set
            {
                moveSlot = value;
            }
        }

        public Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }

        public mnuMoveSelected(string name, int moveSlot)
            : base(name)
        {
            base.Size = new Size(165, 155);
            base.MenuDirection = Enums.MenuDirection.Horizontal;
            base.Location = new Point(300, 34);

            itemPicker = new Widgets.MenuItemPicker("itemPicker");
            itemPicker.Location = new Point(18, 23);

            lblUse = new Label("lblUse");
            lblUse.Font = FontManager.LoadFont("PMDCP", 32);
            lblUse.AutoSize = true;
            lblUse.Text = "Use";
            lblUse.Location = new Point(30, 8);
            lblUse.HoverColor = Color.Red;
            lblUse.ForeColor = Color.WhiteSmoke;
            lblUse.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblUse_Click);

            lblShiftUp = new Label("lblShiftUp");
            lblShiftUp.Font = FontManager.LoadFont("PMDCP", 32);
            lblShiftUp.AutoSize = true;
            lblShiftUp.Text = "Shift Up";
            lblShiftUp.Location = new Point(30, 38);
            lblShiftUp.HoverColor = Color.Red;
            lblShiftUp.ForeColor = Color.WhiteSmoke;
            lblShiftUp.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblShiftUp_Click);

            lblShiftDown = new Label("lblShiftDown");
            lblShiftDown.Font = FontManager.LoadFont("PMDCP", 32);
            lblShiftDown.AutoSize = true;
            lblShiftDown.Text = "Shift Down";
            lblShiftDown.Location = new Point(30, 68);
            lblShiftDown.HoverColor = Color.Red;
            lblShiftDown.ForeColor = Color.WhiteSmoke;
            lblShiftDown.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblShiftDown_Click);

            lblForget = new Label("lblForget");
            lblForget.Font = FontManager.LoadFont("PMDCP", 32);
            lblForget.AutoSize = true;
            lblForget.Text = "Forget";
            lblForget.Location = new Point(30, 98);
            lblForget.HoverColor = Color.Red;
            lblForget.ForeColor = Color.WhiteSmoke;
            lblForget.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblForget_Click);

            this.AddWidget(itemPicker);
            this.AddWidget(lblUse);
            this.AddWidget(lblShiftUp);
            this.AddWidget(lblShiftDown);
            this.AddWidget(lblForget);

            this.MoveSlot = moveSlot;
        }



        void lblUse_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(0, moveSlot);
        }

        void lblShiftUp_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(1, moveSlot);
        }

        void lblShiftDown_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(2, moveSlot);
        }

        void lblForget_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SelectItem(3, moveSlot);
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
                        SelectItem(itemPicker.SelectedItem, moveSlot);
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

        private void SelectItem(int itemNum, int moveSlot)
        {
            switch (itemNum)
            {
                case 0:
                    { // Use move
                        Players.PlayerManager.MyPlayer.UseMove(moveSlot);
                        CloseMenu();
                        Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
                    }
                    break;
                case 1:
                    { // Shift Up
                        if (moveSlot > 0)
                        {
                            Players.PlayerManager.MyPlayer.ShiftMove(moveSlot, true);
                            CloseMenu();
                            Music.Music.AudioPlayer.PlaySoundEffect("beep6.wav");
                        }
                    }
                    break;
                case 2:
                    { // Shift Down
                        if (moveSlot < 3)
                        {
                            Players.PlayerManager.MyPlayer.ShiftMove(moveSlot, false);
                            CloseMenu();
                            Music.Music.AudioPlayer.PlaySoundEffect("beep6.wav");
                        }
                    }
                    break;
                case 3:
                    { // Forget move
                        Players.PlayerManager.MyPlayer.ForgetMove(moveSlot);
                        CloseMenu();
                        Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
                    }
                    break;
            }
        }

        private void CloseMenu()
        {
            Windows.WindowSwitcher.GameWindow.MenuManager.RemoveMenu(this);
            Windows.WindowSwitcher.GameWindow.MenuManager.SetActiveMenu("mnuMoves");
        }



        public bool Modal
        {
            get;
            set;
        }
    }
}
