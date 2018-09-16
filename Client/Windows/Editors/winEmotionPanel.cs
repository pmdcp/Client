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
using SdlDotNet.Widgets;
using Client.Logic.Network;
using PMDCP.Sockets;
using PMDCP.Core;

namespace Client.Logic.Windows.Editors
{
    class winEmotionPanel : Core.WindowCore
    {
        #region Fields

        int itemNum = 0;

        Panel pnlEmoteList;
        Panel pnlEmoteEditor;

        ListBox lbxEmotionList;
        ListBoxTextItem lbiEmote;
        //Button btnAddNew; (Can implement later... Needed?)
        Button btnCancel;
        Button btnEdit;

        Button btnEditorCancel;
        Button btnEditorOK;

        HScrollBar hsbENum;
        Label lblENum;
        PictureBox picEmote;
        Label lblCommand;
        TextBox txtCommand;

        #endregion

        #region Constructors
        public winEmotionPanel()
            : base("winEmotionPanel")
        {
            this.Windowed = true;
            this.ShowInWindowSwitcher = false;
            this.Size = new System.Drawing.Size(200, 230);
            this.Location = new System.Drawing.Point(210, WindowSwitcher.GameWindow.ActiveTeam.Y + WindowSwitcher.GameWindow.ActiveTeam.Height + 0);
            this.AlwaysOnTop = true;
            this.TitleBar.CloseButton.Visible = true;
            this.TitleBar.Font = Graphics.FontManager.LoadFont("tahoma", 10);
            this.TitleBar.Text = "Emotion Panel";

            pnlEmoteList = new Panel("pnlEmoteList");
            pnlEmoteList.Size = new System.Drawing.Size(200, 230);
            pnlEmoteList.Location = new Point(0, 0);
            pnlEmoteList.BackColor = Color.White;
            pnlEmoteList.Visible = true;

            pnlEmoteEditor = new Panel("pnlEmoteEditor");
            pnlEmoteEditor.Size = new System.Drawing.Size(230, 166);
            pnlEmoteEditor.Location = new Point(0, 0);
            pnlEmoteEditor.BackColor = Color.White;
            pnlEmoteEditor.Visible = false;

            lbxEmotionList = new ListBox("lbxEmotionList");
            lbxEmotionList.Location = new Point(10, 10);
            lbxEmotionList.Size = new Size(180, 140);
            for (int i = 0; i < 10; i++)
            {
                lbiEmote = new ListBoxTextItem(Graphics.FontManager.LoadFont("tahoma", 10), i + ": ---");
                lbxEmotionList.Items.Add(lbiEmote);
            }

            btnEdit = new Button("btnEdit");
            btnEdit.Location = new Point(10, 190);
            btnEdit.Font = Graphics.FontManager.LoadFont("tahoma", 10);
            btnEdit.Size = new System.Drawing.Size(64, 16);
            btnEdit.Visible = true;
            btnEdit.Text = "Edit";
            btnEdit.Click += new EventHandler<MouseButtonEventArgs>(btnEdit_Click);

            btnCancel = new Button("btnCancel");
            btnCancel.Location = new Point(126, 190);
            btnCancel.Font = Graphics.FontManager.LoadFont("tahoma", 10);
            btnCancel.Size = new System.Drawing.Size(64, 16);
            btnCancel.Visible = true;
            btnCancel.Text = "Cancel";
            btnCancel.Click += new EventHandler<MouseButtonEventArgs>(btnCancel_Click);

            //btnAddNew = new Button("btnAddNew");
            //btnAddNew.Location = new Point();
            //btnAddNew.Font = Graphics.FontManager.LoadFont("tahoma", 10);
            //btnAddNew.Size = new System.Drawing.Size(64, 16);
            //btnAddNew.Visible = true;
            //btnAddNew.Text = "Add New";
            //btnAddNew.Click += new EventHandler<MouseButtonEventArgs>(btnAddNew_Click);

            btnEditorCancel = new Button("btnEditorCancel");
            btnEditorCancel.Location = new Point(120, 125);
            btnEditorCancel.Font = Graphics.FontManager.LoadFont("tahoma", 10);
            btnEditorCancel.Size = new System.Drawing.Size(64, 16);
            btnEditorCancel.Visible = true;
            btnEditorCancel.Text = "Cancel";
            btnEditorCancel.Click += new EventHandler<MouseButtonEventArgs>(btnEditorCancel_Click);

            btnEditorOK = new Button("btnEditorOK");
            btnEditorOK.Location = new Point(20, 125);
            btnEditorOK.Font = Graphics.FontManager.LoadFont("tahoma", 10);
            btnEditorOK.Size = new System.Drawing.Size(64, 16);
            btnEditorOK.Visible = true;
            btnEditorOK.Text = "OK";
            btnEditorOK.Click += new EventHandler<MouseButtonEventArgs>(btnEditorOK_Click);

            lblENum = new Label("lblENum");
            lblENum.Font = Graphics.FontManager.LoadFont("Tahoma", 10);
            lblENum.Text = "Emoticon: ";
            lblENum.AutoSize = true;
            lblENum.Location = new Point(10, 4);

            txtCommand = new TextBox("txtCommand");
            txtCommand.Size = new Size(200, 16);
            txtCommand.Location = new Point(10, 94);
            txtCommand.Font = Graphics.FontManager.LoadFont("Tahoma", 12);

            lblCommand = new Label("lblCommand");
            lblCommand.Font = Graphics.FontManager.LoadFont("Tahoma", 10);
            lblCommand.Text = "Command:";
            lblCommand.AutoSize = true;
            lblCommand.Location = new Point(10, 80);

            picEmote = new PictureBox("picEmote");
            picEmote.Location = new Point(10, 18);
            picEmote.Size = new Size(32, 32);

            hsbENum = new HScrollBar("hsbPic");
            hsbENum.Maximum = MaxInfo.MaxEmoticons;
            hsbENum.Location = new Point(10, 54);
            hsbENum.Size = new Size(200, 12);
            hsbENum.ValueChanged += new EventHandler<ValueChangedEventArgs>(hsbENum_ValueChanged);

            pnlEmoteList.AddWidget(lbxEmotionList);
            //pnlEmoteList.AddWidget(btnAddNew); Needed?
            pnlEmoteList.AddWidget(btnEdit);
            pnlEmoteList.AddWidget(btnCancel);

            pnlEmoteEditor.AddWidget(hsbENum);
            pnlEmoteEditor.AddWidget(lblENum);
            pnlEmoteEditor.AddWidget(picEmote);
            pnlEmoteEditor.AddWidget(lblCommand);
            pnlEmoteEditor.AddWidget(txtCommand);
            pnlEmoteEditor.AddWidget(btnEditorCancel);
            pnlEmoteEditor.AddWidget(btnEditorOK);

            this.AddWidget(pnlEmoteList);
            this.AddWidget(pnlEmoteEditor);

            RefreshEmoteList();
            this.LoadComplete();
        }
        #endregion

        #region Methods

        public void RefreshEmoteList()
        {
            for (int i = 0; i < MaxInfo.MaxEmoticons; i++)
            {
                if (i < MaxInfo.MaxEmoticons)
                {
                    ((ListBoxTextItem)lbxEmotionList.Items[i]).Text = i + ": " + Emotions.EmotionHelper.Emotions[i].Command;
                }
                else
                {
                    ((ListBoxTextItem)lbxEmotionList.Items[i]).Text = "---";
                }
            }
        }

        void btnEdit_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            if (lbxEmotionList.SelectedItems.Count == 1)
            {
                string[] index = ((ListBoxTextItem)lbxEmotionList.SelectedItems[0]).Text.Split(':');
                if (index[0].IsNumeric())
                {
                    itemNum = index[0].ToInt();
                    Messenger.SendEditEmotion(itemNum);
                    pnlEmoteList.Visible = false;
                }
            }
        }

        public void DisplayEmotionData()
        {
            // First, get the emote instance based on the stored emote index
            Emotions.Emotion emote = Emotions.EmotionHelper.Emotions[itemNum];
            // Update the widgets with the emote data
            txtCommand.Text = emote.Command;
            //picEmote.Image = Tools.CropImage(Logic.Graphics.GraphicsManager.Emoticons, new Rectangle(0, emote.Pic * 32, 32, 32));
            hsbENum.Value = emote.Pic;

            pnlEmoteEditor.Visible = true;
            this.Size = new System.Drawing.Size(pnlEmoteEditor.Width, pnlEmoteEditor.Height);
        }

        void btnCancel_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            this.Close();
            return;
        }

        void btnEditorCancel_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            itemNum = 0;
            pnlEmoteEditor.Visible = false;
            pnlEmoteList.Visible = true;
            this.Size = new System.Drawing.Size(pnlEmoteList.Width, pnlEmoteList.Height);
        }

        void hsbENum_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (lblENum.Text != "Emoticon: " + e.NewValue.ToString())
            {
                lblENum.Text = "Emoticon: " + e.NewValue.ToString();
                //picEmote.Image = Tools.CropImage(Logic.Graphics.GraphicsManager.Emoticons, new Rectangle(0, hsbENum.Value * 32, 32, 32));
            }
        }

        void btnEditorOK_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            Emotions.Emotion emoticonToSend = new Emotions.Emotion();
            emoticonToSend.Command = txtCommand.Text;
            emoticonToSend.Pic = hsbENum.Value;
            Messenger.SendSaveEmotion(itemNum, emoticonToSend);
            pnlEmoteEditor.Visible = false;
            pnlEmoteList.Visible = true;
            this.Size = new System.Drawing.Size(pnlEmoteList.Width, pnlEmoteList.Height);
        }

        #endregion
    }
}
