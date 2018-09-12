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
    class mnuItemSummary : Widgets.BorderedPanel, Core.IMenu
    {
        public bool Modal
        {
            get;
            set;
        }

        Enums.InvMenuType originalMenu;
        int itemSlot;
        PictureBox picPreview;
        Label lblItem;
        Label lblRarity;
        Label lblPrice;
        Label lblDroppable;
        Label lblLoseable;
        Label lblDescription;




        public Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }

        public mnuItemSummary(string name, int itemNum, int itemSlot, Enums.InvMenuType originalMenu)
            : base(name)
        {
            base.Size = new Size(380, 288);
            base.MenuDirection = Enums.MenuDirection.Vertical;
            base.Location = new Point(10, 40);

            this.originalMenu = originalMenu;
            this.itemSlot = itemSlot;

            picPreview = new PictureBox("picPreview");
            picPreview.Size = new Size(32, 32);
            picPreview.BackColor = Color.Transparent;
            picPreview.Location = new Point(10, 10);
            picPreview.Image = Tools.CropImage(GraphicsManager.Items, new Rectangle((Items.ItemHelper.Items[itemNum].Pic - (int)(Items.ItemHelper.Items[itemNum].Pic / 6) * 6) * Constants.TILE_WIDTH, (int)(Items.ItemHelper.Items[itemNum].Pic / 6) * Constants.TILE_WIDTH, Constants.TILE_WIDTH, Constants.TILE_HEIGHT));

            lblItem = new Label("lblItem");
            lblItem.Location = new Point(46, 10);
            lblItem.AutoSize = true;
            lblItem.Font = FontManager.LoadFont("PMDCP", 32);
            lblItem.Text = Items.ItemHelper.Items[itemNum].Name;
            lblItem.ForeColor = Color.WhiteSmoke;

            lblRarity = new Label("lblRarity");
            lblRarity.Location = new Point(20, 42);
            lblRarity.AutoSize = true;
            lblRarity.Font = FontManager.LoadFont("PMDCP", 16);
            lblRarity.Text = "Rarity: " + Items.ItemHelper.Items[itemNum].Rarity;
            lblRarity.ForeColor = Color.WhiteSmoke;

            int y = 42;
            y += 20;
            lblPrice = new Label("lblPrice");
            lblPrice.Location = new Point(20, y);
            lblPrice.AutoSize = true;
            lblPrice.Font = FontManager.LoadFont("PMDCP", 16);
            if (Items.ItemHelper.Items[itemNum].Price > 0)
            {
                lblPrice.Text = "Sell Price: " + Items.ItemHelper.Items[itemNum].Price;
            }
            else
            {
                lblPrice.Text = "Cannot be sold.";
            }
            lblPrice.ForeColor = Color.WhiteSmoke;

            if (Items.ItemHelper.Items[itemNum].Bound)
            {
                y += 20;
                lblDroppable = new Label("lblDroppable");
                lblDroppable.Location = new Point(20, y);
                lblDroppable.AutoSize = true;
                lblDroppable.Font = FontManager.LoadFont("PMDCP", 16);
                lblDroppable.Text = "Cannot be dropped.";
                lblDroppable.ForeColor = Color.WhiteSmoke;
            }

            if (Items.ItemHelper.Items[itemNum].Bound)
            {
                y += 20;
                lblLoseable = new Label("lblLoseable");
                lblLoseable.Location = new Point(20, y);
                lblLoseable.AutoSize = true;
                lblLoseable.Font = FontManager.LoadFont("PMDCP", 16);
                lblLoseable.Text = "Cannot be lost.";
                lblLoseable.ForeColor = Color.WhiteSmoke;
            }

            y += 30;
            lblDescription = new Label("lblDescription");
            lblDescription.Location = new Point(20, y);
            //lblDescription.AutoSize = true;
            lblDescription.Size = new Size(300, 220);
            lblDescription.Font = FontManager.LoadFont("PMDCP", 16);
            lblDescription.Text = Items.ItemHelper.Items[itemNum].Desc;
            lblDescription.ForeColor = Color.WhiteSmoke;

            this.AddWidget(picPreview);
            this.AddWidget(lblItem);
            this.AddWidget(lblRarity);
            this.AddWidget(lblPrice);
            this.AddWidget(lblDroppable);
            this.AddWidget(lblLoseable);
            this.AddWidget(lblDescription);
        }



        public override void OnKeyboardDown(SdlDotNet.Input.KeyboardEventArgs e)
        {
            base.OnKeyboardDown(e);
            switch (e.Key)
            {
                case SdlDotNet.Input.Key.Return:
                    {
                        MenuBack();
                    }
                    break;
                case SdlDotNet.Input.Key.Backspace:
                    {
                        // Show the main menu when the backspace key is pressed
                        MenuBack();
                    }
                    break;
            }
        }

        private void MenuBack()
        {
            switch (originalMenu)
            {
                case Enums.InvMenuType.Use:
                    {
                        MenuSwitcher.ShowInventoryMenu(itemSlot);
                        Music.Music.AudioPlayer.PlaySoundEffect("beep3.wav");
                    }
                    break;
                case Enums.InvMenuType.Store:
                    {
                        MenuSwitcher.ShowBankDepositMenu(itemSlot);
                        Music.Music.AudioPlayer.PlaySoundEffect("beep3.wav");
                    }
                    break;
                case Enums.InvMenuType.Take:
                    {
                        MenuSwitcher.ShowBankWithdrawMenu(itemSlot);
                        Music.Music.AudioPlayer.PlaySoundEffect("beep3.wav");
                    }
                    break;
                case Enums.InvMenuType.Sell:
                    {
                        MenuSwitcher.ShowShopSellMenu(itemSlot);
                        Music.Music.AudioPlayer.PlaySoundEffect("beep3.wav");
                    }

                    break;
                case Enums.InvMenuType.Buy:
                    {
                        MenuSwitcher.ShowShopBuyMenu(itemSlot);
                        Music.Music.AudioPlayer.PlaySoundEffect("beep3.wav");
                    }

                    break;
                case Enums.InvMenuType.Recycle:
                    {
                    }

                    break;
            }
        }
    }
}
