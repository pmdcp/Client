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
using SdlDotNet.Widgets;
using Client.Logic.Graphics;

namespace Client.Logic.ExpKit.Modules
{
    class kitChat : Panel, IKitModule
    {
        int moduleIndex;
        Size containerSize;
        Label lblChat;
        TextBox txtCommands;
        bool enabled;
        Label lblChannel;
        ComboBox channelSelector;

        public Label Chat {
            get {
                return lblChat;
            }
        }

        public kitChat(string name)
            : base(name) {
            enabled = true;

            base.BackColor = Color.Transparent;

            lblChat = new Label("lblChat");
            //lblChat.Location = new Point(0, 0);
            lblChat.Size = new Size(200, this.Height);
            lblChat.AutoScroll = IO.Options.AutoScroll;
            lblChat.Font = FontManager.LoadFont("PMDCP", 16);

            lblChannel = new Label("lblChannel");
            lblChannel.Font = FontManager.LoadFont("tahoma", 15);
            lblChannel.Text = "Channel:";
            lblChannel.ForeColor = Color.WhiteSmoke;

            channelSelector = new ComboBox("channelSelector");
            

            txtCommands = new TextBox("txtCommands");
            Skins.SkinManager.LoadTextBoxGui(txtCommands);
            //txtCommands.Location = new Point(0, lblChat.Y + lblChat.Height);
            //txtCommands.Size = new Size(this.Width, 20);
            txtCommands.Font = FontManager.LoadFont("PMDCP", 16);
            txtCommands.KeyUp += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(txtCommands_KeyUp);
            //txtCommands. = FontManager.LoadFont("tahoma", 12);

            this.AddWidget(lblChat);
            this.AddWidget(txtCommands);
            this.AddWidget(lblChannel);
            this.AddWidget(channelSelector);
        }

        public void AppendChat(string text, SdlDotNet.Widgets.CharRenderOptions[] renderOptions) {
            lblChat.AppendText(text, renderOptions);
            if (lblChat.Text.Length > 10000) {
                GlyphRenderData[] newRenderOptions = new GlyphRenderData[10000];
                lblChat.CharRenderOptions.CopyTo(lblChat.CharRenderOptions.Count - 10000, newRenderOptions, 0, 10000);
                lblChat.SetText(newRenderOptions);
            }
            lblChat.ScrollToBottom();
        }

        public void AppendChat(string text, SdlDotNet.Widgets.CharRenderOptions renderOptions) {
            lblChat.AppendText(text, renderOptions);
            lblChat.ScrollToBottom();
        }

        public void AppendChat(string text, Color color) {
            AppendChat(text + "\n", new CharRenderOptions(color));
        }

        void txtCommands_KeyUp(object sender, SdlDotNet.Input.KeyboardEventArgs e) {
            if (e.Key == SdlDotNet.Input.Key.Return) {
                CommandProcessor.ProcessCommand(txtCommands.Text, (Enums.ChatChannel)Enum.Parse(typeof(Enums.ChatChannel), channelSelector.SelectedItem.TextIdentifier, true));
                txtCommands.Text = "";
            }
        }

        public void SetAutoScroll(bool set) {
            lblChat.AutoScroll = set;
        }

        public void Created(int index) {
            moduleIndex = index;
        }

        public void SwitchOut() {

        }

        public void Initialize(Size containerSize) {
            this.containerSize = containerSize;
            RecalculatePositions();
            this.RequestRedraw();
        }

        private void RecalculatePositions() {
            lblChat.Location = new Point(0, 0);
            lblChat.Size = new Size(containerSize.Width, containerSize.Height - 40 - 18);
            txtCommands.Location = new Point(0, lblChat.Y + lblChat.Height + 1);
            txtCommands.Size = new Size(containerSize.Width, 20);
            Skins.SkinManager.LoadTextBoxGui(txtCommands);

            lblChannel.Font = FontManager.LoadFont("PMDCP", 16);
            lblChannel.Size = new Size(75, 18);
            lblChannel.Location = new Point(0, txtCommands.Y + txtCommands.Height);

            channelSelector.Size = new Size(containerSize.Width - lblChannel.Width, 18);
            channelSelector.Location = new Point(lblChannel.Width, txtCommands.Y + txtCommands.Height);
            channelSelector.BorderColor = Color.Black;
            channelSelector.BorderWidth = 1;
            channelSelector.BorderStyle = SdlDotNet.Widgets.BorderStyle.FixedSingle;

            int selectedIndex = channelSelector.SelectedIndex;
            channelSelector.Items.Clear();
            channelSelector.Items.Add(new ListBoxTextItem(FontManager.LoadFont("PMDCP", 16), "Local"));
            channelSelector.Items.Add(new ListBoxTextItem(FontManager.LoadFont("PMDCP", 16), "Global"));
            channelSelector.Items.Add(new ListBoxTextItem(FontManager.LoadFont("PMDCP", 16), "Guild"));
            if (Ranks.IsAllowed(Players.PlayerManager.MyPlayer, Enums.Rank.Moniter)) {
                channelSelector.Items.Add(new ListBoxTextItem(FontManager.LoadFont("PMDCP", 16), "Staff"));
            }
            if (selectedIndex < channelSelector.Items.Count && selectedIndex > -1) {
                channelSelector.SelectItem(selectedIndex);
            } else {
                channelSelector.SelectItem(0);
            }
            //lblCounter.Size = new Size(containerSize.Width - 10, 30);
            //btnIncrement.Location = new Point(DrawingSupport.GetCenter(containerSize, btnIncrement.Size).X - (btnIncrement.Width / 2), lblCounter.Y + lblCounter.Height + 5);
            //btnDecrement.Location = new Point(DrawingSupport.GetCenter(containerSize, btnDecrement.Size).X + (btnDecrement.Width / 2), lblCounter.Y + lblCounter.Height + 5);
        }

        public int ModuleIndex {
            get { return moduleIndex; }
        }

        public string ModuleName {
            get { return "Chat"; }
        }

        public Panel ModulePanel {
            get { return this; }
        }


        public bool Enabled {
            get { return enabled; }
            set {
                enabled = value;
                if (EnabledChanged != null)
                    EnabledChanged(this, EventArgs.Empty);
            }
        }


        public event EventHandler EnabledChanged;


        public Enums.ExpKitModules ModuleID {
            get { return Enums.ExpKitModules.Chat; }
        }
    }
}
