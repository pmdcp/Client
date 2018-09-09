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
using SdlDotNet.Widgets;

namespace Client.Logic.Stories.Components
{
    class SpokenTextMenu : Widgets.BorderedPanel, Menus.Core.IMenu
    {
        Label lblText;
        PictureBox picSpeaker;

        public Widgets.BorderedPanel MenuPanel {
            get { return this; }
        }

        public bool Modal {
            get;
            set;
        }

        public SpokenTextMenu(string name, Size storyBounds)
            : base(name) {

            this.Size = new System.Drawing.Size(storyBounds.Width - 10, 100);
            this.Location = new Point(5, storyBounds.Height - this.Height);

            lblText = new Label("lblText");
            lblText.BackColor = Color.Transparent;
            lblText.ForeColor = Color.WhiteSmoke;
            lblText.AutoSize = false;
            lblText.Font = Graphics.FontManager.LoadFont("PMDCP", 32);
            lblText.Location = new Point(15, 10);
            lblText.Size = new System.Drawing.Size(this.WidgetPanel.Width - lblText.Location.X, this.WidgetPanel.Height - lblText.Location.Y);

            picSpeaker = new PictureBox("picSpeaker");
            picSpeaker.Size = new Size(40, 40);
            picSpeaker.Location = new Point(10, DrawingSupport.GetCenter(WidgetPanel.Height, 40));
            picSpeaker.BorderWidth = 1;
            picSpeaker.BorderStyle = SdlDotNet.Widgets.BorderStyle.FixedSingle;

            this.WidgetPanel.AddWidget(lblText);
            this.WidgetPanel.AddWidget(picSpeaker);
        }

        public void DisplayText(string text) {
            DisplayText(text, -1);
        }

        public void DisplayText(string text, int mugshot) {
            bool displayMugshot = false;
            if (mugshot > -1) {
                Logic.Graphics.Mugshot mugshotImg = Logic.Graphics.GraphicsManager.GetMugshot(mugshot, 0, 0, 0);
                if (mugshotImg != null) {
                    displayMugshot = true;
                }
            }
            if (displayMugshot) {
                picSpeaker.Image = Logic.Graphics.GraphicsManager.GetMugshot(mugshot, 0, 0, 0).GetEmote(0);//Tools.CropImage(Logic.Graphics.GraphicsManager.Speakers, new Rectangle((mugshot % 15) * 40, (mugshot / 15) * 40, 40, 40));
                lblText.Location = new Point(picSpeaker.X + picSpeaker.Width + 10, 10);
                lblText.Size = new System.Drawing.Size(this.WidgetPanel.Width - lblText.Location.X, this.WidgetPanel.Height - lblText.Location.Y);
                picSpeaker.Show();
            } else {
                picSpeaker.Hide();
                lblText.Location = new Point(15, 10);
                lblText.Size = new System.Drawing.Size(this.WidgetPanel.Width - lblText.Location.X, this.WidgetPanel.Height - lblText.Location.Y);
            }
            CharRenderOptions[] renderOptions = new CharRenderOptions[text.Length];
            for (int i = 0; i < renderOptions.Length; i++) {
                renderOptions[i] = new CharRenderOptions(Color.WhiteSmoke);
            }
            renderOptions = Client.Logic.Graphics.StringParser.ParseText(renderOptions, ref text);
            lblText.SetText(text, renderOptions);
        }

        public override void Close() {
            base.Close();
            if (this.ParentContainer != null) {
                this.ParentContainer.RemoveWidget(this.GroupedWidget.Name);
            }
        }
    }
}
