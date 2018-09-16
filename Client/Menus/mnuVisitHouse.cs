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
using System.Text;
using System.Drawing;

using Client.Logic.Graphics;

using SdlDotNet.Widgets;
using Client.Logic.Network;

namespace Client.Logic.Menus
{
    class mnuVisitHouse : Widgets.BorderedPanel, Core.IMenu
    {
        public bool Modal
        {
            get;
            set;
        }

        Label lblHouseSelection;
        TextBox txtHouse;
        Button btnAccept;
        Button btnMyHouse;
        Button btnCancel;

        public mnuVisitHouse(string name)
            : base(name)
        {
            this.Size = new Size(300, 200);
            this.MenuDirection = Enums.MenuDirection.Vertical;
            this.Location = Client.Logic.Graphics.DrawingSupport.GetCenter(Windows.WindowSwitcher.GameWindow.MapViewer.Size, this.Size);

            lblHouseSelection = new Label("lblHouseSelection");
            lblHouseSelection.Location = new Point(25, 15);
            lblHouseSelection.AutoSize = false;
            lblHouseSelection.Size = new System.Drawing.Size(this.Width - lblHouseSelection.X * 2, 40);
            lblHouseSelection.Text = "Enter the name of the player whose house you wish to visit.";
            lblHouseSelection.ForeColor = Color.WhiteSmoke;

            txtHouse = new TextBox("txtHouse");
            txtHouse.Location = new Point(lblHouseSelection.X, lblHouseSelection.Y + lblHouseSelection.Height + 10);
            txtHouse.Size = new Size(this.Width - (lblHouseSelection.X * 2), 16);
            Skins.SkinManager.LoadTextBoxGui(txtHouse);

            btnAccept = new Button("btnAccept");
            btnAccept.Location = new Point(lblHouseSelection.X, txtHouse.Y + txtHouse.Height + 10);
            btnAccept.Size = new Size(50, 30);
            btnAccept.Text = "Visit!";
            btnAccept.Font = FontManager.LoadFont("tahoma", 10);
            Skins.SkinManager.LoadButtonGui(btnAccept);
            btnAccept.Click += new EventHandler<MouseButtonEventArgs>(btnAccept_Click);

            btnMyHouse = new Button("btnMyHouse");
            btnMyHouse.Location = new Point(btnAccept.X + btnAccept.Width, txtHouse.Y + txtHouse.Height + 10);
            btnMyHouse.Size = new Size(80, 30);
            btnMyHouse.Text = "Visit My House";
            btnMyHouse.Font = FontManager.LoadFont("tahoma", 10);
            Skins.SkinManager.LoadButtonGui(btnMyHouse);
            btnMyHouse.Click += new EventHandler<MouseButtonEventArgs>(btnMyHouse_Click);

            btnCancel = new Button("btnCancel");
            btnCancel.Location = new Point(btnMyHouse.X + btnMyHouse.Width, txtHouse.Y + txtHouse.Height + 10);
            btnCancel.Size = new Size(50, 30);
            btnCancel.Text = "Cancel";
            btnCancel.Font = FontManager.LoadFont("tahoma", 10);
            Skins.SkinManager.LoadButtonGui(btnCancel);
            btnCancel.Click += new EventHandler<MouseButtonEventArgs>(btnCancel_Click);

            this.AddWidget(lblHouseSelection);
            this.AddWidget(txtHouse);
            this.AddWidget(btnAccept);
            this.AddWidget(btnMyHouse);
            this.AddWidget(btnCancel);
        }

        void btnMyHouse_Click(object sender, MouseButtonEventArgs e)
        {
            Messenger.SendHouseVisitRequest(Players.PlayerManager.MyPlayer.Name);
            MenuSwitcher.CloseAllMenus();
            Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
        }

        void btnAccept_Click(object sender, MouseButtonEventArgs e)
        {
            Messenger.SendHouseVisitRequest(txtHouse.Text);
            MenuSwitcher.CloseAllMenus();
            Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
        }

        void btnCancel_Click(object sender, MouseButtonEventArgs e)
        {
            MenuSwitcher.CloseAllMenus();
            Music.Music.AudioPlayer.PlaySoundEffect("beep3.wav");
        }

        public Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }
    }
}
