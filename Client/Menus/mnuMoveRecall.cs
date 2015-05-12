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
using PMDCP.Core;
using Client.Logic.Graphics;

using SdlDotNet.Widgets;

namespace Client.Logic.Menus
{
	/// <summary>
	/// Description of mnuLinkShop.
	/// </summary>
	class mnuMoveRecall : Widgets.BorderedPanel, Core.IMenu
	{
		public bool Modal
        {
            get;
            set;
        }

        bool loaded;
        Label[] lblVisibleItems;
        Label lblItemCollection;
        Widgets.MenuItemPicker itemPicker;
        public int currentTen;
        Label lblItemNum;
        public List<int> RecallMoves
        {

            get;
            set;
        }

        public Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }
		
		public mnuMoveRecall(string name)
            : base(name)
        {
            base.Size = new Size(315, 360);
            base.MenuDirection = Enums.MenuDirection.Vertical;
            base.Location = new Point(10, 40);
            
            itemPicker = new Widgets.MenuItemPicker("itemPicker");
            itemPicker.Location = new Point(18, 63);

            lblItemCollection = new Label("lblItemCollection");
            lblItemCollection.AutoSize = true;
            lblItemCollection.Font = FontManager.LoadFont("PMDCP", 48);
            lblItemCollection.Text = "Move Recall";
            lblItemCollection.Location = new Point(20, 0);
            lblItemCollection.ForeColor = Color.WhiteSmoke;

            lblItemNum = new Label("lblItemNum");
            //lblItemNum.Size = new Size(100, 30);
            lblItemNum.AutoSize = true;
            lblItemNum.Location = new Point(196, 15);
            lblItemNum.Font = FontManager.LoadFont("PMDCP", 32);
            lblItemNum.BackColor = Color.Transparent;
            lblItemNum.Text = "0/0";
            lblItemNum.ForeColor = Color.WhiteSmoke;


            lblVisibleItems = new Label[10];
            for (int i = 0; i < lblVisibleItems.Length; i++)
            {
                lblVisibleItems[i] = new Label("lblVisibleItems" + i);
                //lblVisibleItems[i].AutoSize = true;
                //lblVisibleItems[i].Size = new Size(200, 32);
                lblVisibleItems[i].Width = 200;
                lblVisibleItems[i].Font = FontManager.LoadFont("PMDCP", 32);
                lblVisibleItems[i].Location = new Point(35, (i * 30) + 48);
                //lblVisibleItems[i].HoverColor = Color.Red;
                lblVisibleItems[i].ForeColor = Color.WhiteSmoke;
                lblVisibleItems[i].Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(moveItem_Click);
                this.AddWidget(lblVisibleItems[i]);
            }

            
            this.AddWidget(lblItemCollection);
            this.AddWidget(lblItemNum);
            this.AddWidget(itemPicker);

            
                //DisplayItems(currentTen * 10 + 1);
                //ChangeSelected((itemSelected - 1) % 10);
                //UpdateSelectedItemInfo();
                //loaded = true;
            lblVisibleItems[0].Text = "Loading...";
		}
		
		public void LoadRecallMoves(string[] parse)
        {
			RecallMoves = new List<int>();
			
        	if (parse.Length <= 2) {
        		lblVisibleItems[0].Text = "Nothing";
        		return;
        	}
            
            
            for (int i = 1; i < parse.Length - 1; i++) {
            	RecallMoves.Add(parse[i].ToInt());
            }

            
            DisplayItems(currentTen * 10);
            lblItemNum.Text = (currentTen + 1) + "/" + ((RecallMoves.Count - 1) / 10 + 1);
            loaded = true;
        }
		
		public void ChangeSelected(int itemNum)
        {
            itemPicker.Location = new Point(18, 63 + (30 * itemNum));
            itemPicker.SelectedItem = itemNum;
        }
		
		void moveItem_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            if (loaded)
            {
                if (RecallMoves[currentTen * 10 + Array.IndexOf(lblVisibleItems, sender)] > 0)
                {
                    ChangeSelected(Array.IndexOf(lblVisibleItems, sender));
                    Music.Music.AudioPlayer.PlaySoundEffect("beep1.wav");

                    //mnuRecallMoveSelected selectedMenu = (mnuRecallMoveSelected)Windows.WindowSwitcher.GameWindow.MenuManager.FindMenu("mnuRecallMoveSelected");
                    //if (selectedMenu != null)
                    //{
                    //    Windows.WindowSwitcher.GameWindow.MenuManager.RemoveMenu(selectedMenu);
                        //selectedMenu.ItemSlot = GetSelectedItemSlot();
                        //selectedMenu.ItemNum = BankItems[GetSelectedItemSlot()].Num;
                    //}
                    //    Windows.WindowSwitcher.GameWindow.MenuManager.AddMenu(new Menus.mnuRecallMoveSelected("mnuRecallMoveSelected", GetSelectedItemSlot()));
                    //    Windows.WindowSwitcher.GameWindow.MenuManager.SetActiveMenu("mnuRecallMoveSelected");
                    
                }
            }
        }
		
		public void DisplayItems(int startNum)
        {
            this.BeginUpdate();
            for (int i = 0; i < lblVisibleItems.Length; i++)
            {
                
                //shop menu; lists items and their prices
                if (startNum + i >= RecallMoves.Count) {
                        lblVisibleItems[i].Text = "";
                }else if (RecallMoves[startNum + i] < 1){
                			lblVisibleItems[i].Text = "---";
                } else {
                		lblVisibleItems[i].Text = Moves.MoveHelper.Moves[RecallMoves[startNum + i]].Name;
            		}
                
            }
            this.EndUpdate();
        }
		
		private int GetSelectedItemSlot()
        {
            return itemPicker.SelectedItem + currentTen * 10;
        }

        public override void OnKeyboardDown(SdlDotNet.Input.KeyboardEventArgs e)
        {
        	if (RecallMoves.Count == 0) {
        		return;
        	}
            if (loaded)
            {
                base.OnKeyboardDown(e);
                switch (e.Key)
                {
                    case SdlDotNet.Input.Key.DownArrow:
                        {
                            if (itemPicker.SelectedItem >= 9 || currentTen*10 + itemPicker.SelectedItem >= RecallMoves.Count - 1)
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
                                ChangeSelected(9);
                            }
                            else
                            {
                                ChangeSelected(itemPicker.SelectedItem - 1);
                            }
                            if (currentTen*10 + itemPicker.SelectedItem > RecallMoves.Count) {
                                ChangeSelected(RecallMoves.Count - currentTen*10 - 1);
                            }
                            Music.Music.AudioPlayer.PlaySoundEffect("beep1.wav");
                        }
                        break;
                    case SdlDotNet.Input.Key.LeftArrow:
                        {
                            //int itemSlot = (currentTen + 1) - 10;//System.Math.Max(1, GetSelectedItemSlot() - (11 - itemPicker.SelectedItem));
                            if (currentTen <= 0)
                            {
                                currentTen = ((RecallMoves.Count - 1) / 10);
                            }
                            else
                            {
                                currentTen--;
                            }
                            if (currentTen*10 + itemPicker.SelectedItem >= RecallMoves.Count) {
                                ChangeSelected(RecallMoves.Count - currentTen*10 - 1);
                            }
                            DisplayItems(currentTen * 10);
                            lblItemNum.Text = (currentTen + 1) + "/" + ((RecallMoves.Count - 1) / 10 + 1);
                            Music.Music.AudioPlayer.PlaySoundEffect("beep4.wav");
                        }
                        break;
                    case SdlDotNet.Input.Key.RightArrow:
                        {
                            //int itemSlot = currentTen + 1 + 10;
                            if (currentTen >= ((RecallMoves.Count - 1) / 10))
                            {
                                currentTen = 0;
                            }
                            else
                            {
                                currentTen++;
                            }
                            if (currentTen*10 + itemPicker.SelectedItem >= RecallMoves.Count) {
                                ChangeSelected(RecallMoves.Count - currentTen*10 - 1);
                            }
                            DisplayItems(currentTen * 10);
                            lblItemNum.Text = (currentTen + 1) + "/" + ((RecallMoves.Count - 1) / 10 + 1);
                            Music.Music.AudioPlayer.PlaySoundEffect("beep4.wav");
                        }
                        break;
                    case SdlDotNet.Input.Key.Return:
                        {
                            if (GetSelectedItemSlot() > -1 && GetSelectedItemSlot() < RecallMoves.Count && RecallMoves[GetSelectedItemSlot()] > -1)
                            {
                                //Windows.WindowSwitcher.GameWindow.MenuManager.AddMenu(new Menus.mnuRecallMoveSelected("mnuRecallMoveSelected", GetSelectedItemSlot()));
                                //Windows.WindowSwitcher.GameWindow.MenuManager.SetActiveMenu("mnuRecallMoveSelected");
                                
                                Network.Messenger.SendRecallMove(RecallMoves[GetSelectedItemSlot()]);
                                MenuSwitcher.CloseAllMenus();
                            }
                        }
                        break;
                }
            }
        }
		
	}
}
