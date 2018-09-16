using System;
using System.Collections.Generic;
using System.Text;
using SdlDotNet.Widgets;
using System.Drawing;
using Client.Logic.Graphics;
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
    class mnuTournamentMatchUpViewer : Client.Logic.Widgets.BorderedPanel, Core.IMenu
    {
        Label lblLeftArrow;
        Label lblRightArrow;
        PictureBox pbxPlayerOneMugshot;
        PictureBox pbxPlayerTwoMugshot;
        Label lblVSLabel;
        Label lblPlayerOneName;
        Label lblPlayerTwoName;


        #region Properties

        public Client.Logic.Widgets.BorderedPanel MenuPanel
        {
            get { return this; }
        }

        public bool Modal
        {
            get;
            set;
        }

        #endregion Properties

        public mnuTournamentMatchUpViewer(string name)
            : base(name)
        {
            this.Size = new System.Drawing.Size(300, 400);

            lblLeftArrow = new Label("lblLeftArrow");
            lblLeftArrow.AutoSize = false;
            lblLeftArrow.Size = new System.Drawing.Size(50, 35);
            lblLeftArrow.Font = FontManager.LoadFont("PMDCP", 32);
            lblLeftArrow.Text = "<";
            lblLeftArrow.Location = new Point(5);

            lblRightArrow = new Label("lblRightArrow");
            lblRightArrow.AutoSize = false;
            lblRightArrow.Size = new System.Drawing.Size(50, 35);
            lblRightArrow.Font = FontManager.LoadFont("PMDCP", 32);
            lblRightArrow.Text = ">";
            lblRightArrow.Location = new Point(this.Width - lblRightArrow.Width - 5);

            pbxPlayerOneMugshot = new PictureBox("pbxPlayerOneMugshot");
            pbxPlayerOneMugshot.Size = new Size(40, 40);
            pbxPlayerOneMugshot.Location = new Point(lblLeftArrow.X + lblLeftArrow.Width + 5, 5);

            lblVSLabel = new Label("lblVSLabel");
            lblVSLabel.Font = FontManager.LoadFont("PMDCP", 32);
            lblVSLabel.AutoSize = false;
            lblVSLabel.Size = new Size(100, 35);
            lblVSLabel.Location = new Point(pbxPlayerOneMugshot.X + pbxPlayerOneMugshot.Width + 5, pbxPlayerOneMugshot.Y + pbxPlayerOneMugshot.Height - lblVSLabel.Height);

            pbxPlayerTwoMugshot = new PictureBox("pbxPlayerTwoMugshot");
            pbxPlayerTwoMugshot.Size = new Size(40, 40);
            pbxPlayerTwoMugshot.Location = new Point(lblVSLabel.X + lblVSLabel.Width + 5, pbxPlayerOneMugshot.Y);

            lblPlayerOneName = new Label("lblPlayerOneName");
            lblPlayerOneName.Font = FontManager.LoadFont("PMDCP", 32);
            lblPlayerOneName.Location = new Point(pbxPlayerOneMugshot.X, pbxPlayerOneMugshot.Y + pbxPlayerOneMugshot.Height + 5);

            lblPlayerTwoName = new Label("lblPlayerTwoName");
            lblPlayerTwoName.Font = FontManager.LoadFont("PMDCP", 32);
            lblPlayerTwoName.Location = new Point(pbxPlayerTwoMugshot.X, pbxPlayerTwoMugshot.Y + pbxPlayerTwoMugshot.Height + 5);
        }

        public void LoadMatchUpsFromPacket(string[] parse)
        {
            int n;
        }
    }
}