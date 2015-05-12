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

namespace Client.Logic.Menus {
    class mnuChangeBounds : Widgets.BorderedPanel, Core.IMenu {
        public bool Modal {
            get;
            set;
        }

        Label lblAddTile;
        Label lblXY;
        NumericUpDown nudAmountX;
        NumericUpDown nudAmountY;
        Label lblPrice;
        Button btnAccept;
        Button btnCancel;
        int price;
        int currX;
        int currY;

        public mnuChangeBounds(string name, int price)
            : base(name) {
                this.price = price;
                currX = Logic.Maps.MapHelper.ActiveMap.MaxX + 1;
                currY = Logic.Maps.MapHelper.ActiveMap.MaxY + 1;

            this.Size = new Size(250, 250);
            this.MenuDirection = Enums.MenuDirection.Vertical;
            this.Location = Client.Logic.Graphics.DrawingSupport.GetCenter(Windows.WindowSwitcher.GameWindow.MapViewer.Size, this.Size);

            lblAddTile = new Label("lblAddTile");
            lblAddTile.Location = new Point(25, 15);
            lblAddTile.AutoSize = false;
            lblAddTile.Size = new System.Drawing.Size(this.Width - lblAddTile.X * 2, 40);
            lblAddTile.Text = "Enter the new dimensions for your house:";
            lblAddTile.ForeColor = Color.WhiteSmoke;

            lblXY = new Label("lblXY");
            lblXY.Location = new Point(lblAddTile.X, lblAddTile.Y + lblAddTile.Height + 5);
            lblXY.AutoSize = false;
            lblXY.Size = new System.Drawing.Size(this.Width - lblXY.X * 2, 40);
            lblXY.Text = "Width:          Height:";
            lblXY.ForeColor = Color.WhiteSmoke;

            nudAmountX = new NumericUpDown("nudAmountX");
            nudAmountX.Size = new Size(60, 24);
            nudAmountX.Location = new Point(lblAddTile.X, lblAddTile.Y + lblAddTile.Height + 20);
            nudAmountX.Maximum = 50;
            nudAmountX.Minimum = 20;
            nudAmountX.Value = currX;
            nudAmountX.ValueChanged +=new EventHandler<ValueChangedEventArgs>(nudAmount_ValueChanged);

            nudAmountY = new NumericUpDown("nudAmountY");
            nudAmountY.Size = new Size(60, 24);
            nudAmountY.Location = new Point(lblAddTile.X + nudAmountX.Width + 20, lblAddTile.Y + lblAddTile.Height + 20);
            nudAmountY.Maximum = 50;
            nudAmountY.Minimum = 15;
            nudAmountY.Value = currY;
            nudAmountY.ValueChanged += new EventHandler<ValueChangedEventArgs>(nudAmount_ValueChanged);

            lblPrice = new Label("lblPrice");
            lblPrice.Location = new Point(lblAddTile.X, nudAmountX.Y + nudAmountX.Height + 10);
            lblPrice.AutoSize = false;
            lblPrice.Size = new System.Drawing.Size(120, 40);
            int deltaPrice = ((nudAmountX.Value * nudAmountY.Value - currX * currY) * price);
            if (deltaPrice < 0) deltaPrice = 0;
            lblPrice.Text = "New dimensions will cost " + deltaPrice + " " + Items.ItemHelper.Items[1].Name + ".";
            lblPrice.ForeColor = Color.WhiteSmoke;

            btnAccept = new Button("btnAccept");
            btnAccept.Location = new Point(lblAddTile.X, lblPrice.Y + lblPrice.Height + 10);
            btnAccept.Size = new Size(80, 30);
            btnAccept.Text = "OK";
            btnAccept.Font = FontManager.LoadFont("tahoma", 10);
            Skins.SkinManager.LoadButtonGui(btnAccept);
            btnAccept.Click += new EventHandler<MouseButtonEventArgs>(btnAccept_Click);
            
            btnCancel = new Button("btnCancel");
            btnCancel.Location = new Point(btnAccept.X + btnAccept.Width, lblPrice.Y + lblPrice.Height + 10);
            btnCancel.Size = new Size(80, 30);
            btnCancel.Text = "Cancel";
            btnCancel.Font = FontManager.LoadFont("tahoma", 10);
            Skins.SkinManager.LoadButtonGui(btnCancel);
            btnCancel.Click += new EventHandler<MouseButtonEventArgs>(btnCancel_Click);

            this.AddWidget(lblAddTile);
            this.AddWidget(lblXY);
            this.AddWidget(nudAmountX);
            this.AddWidget(nudAmountY);
            this.AddWidget(lblPrice);
            this.AddWidget(btnAccept);
            this.AddWidget(btnCancel);
        }

        void nudAmount_ValueChanged(object sender, ValueChangedEventArgs e) {

            int deltaPrice = ((nudAmountX.Value * nudAmountY.Value - currX * currY) * price);
            if (deltaPrice < 0) deltaPrice = 0;
            lblPrice.Text = "New dimensions will cost " + deltaPrice + " " + Items.ItemHelper.Items[1].Name + ".";
        }

        void btnAccept_Click(object sender, MouseButtonEventArgs e) {
            Messenger.SendExpansionRequest(nudAmountX.Value-1, nudAmountY.Value-1);
            MenuSwitcher.CloseAllMenus();
            Music.Music.AudioPlayer.PlaySoundEffect("beep2.wav");
        }

        void btnCancel_Click(object sender, MouseButtonEventArgs e) {
            MenuSwitcher.CloseAllMenus();
            Music.Music.AudioPlayer.PlaySoundEffect("beep3.wav");
        }

        public Widgets.BorderedPanel MenuPanel {
            get { return this; }
        }
    }
}
