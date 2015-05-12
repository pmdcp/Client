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
using Client.Logic.Network;

namespace Client.Logic.Windows.Editors
{
    class winGuildPanel : Core.WindowCore
    {
        
        Label lblPlayer;
        Label lblGuild;
        Label lblCreate;

        TextBox txtPlayer;
        TextBox txtGuild;

        public winGuildPanel()
            : base("winGuildPanel")
        {
            this.Windowed = true;
            this.ShowInWindowSwitcher = false;
            this.Size = new System.Drawing.Size(174, 196);
            this.Location = new System.Drawing.Point(210, WindowSwitcher.GameWindow.ActiveTeam.Y + WindowSwitcher.GameWindow.ActiveTeam.Height + 0);
            this.AlwaysOnTop = true;
            this.TitleBar.CloseButton.Visible = true;
            this.TitleBar.Font = Graphics.FontManager.LoadFont("tahoma", 10);
            this.TitleBar.Text = "Guild Panel";

            lblPlayer = new Label("lblPlayer");
            lblPlayer.Location = new Point(20, 0);
            lblPlayer.Font = Graphics.FontManager.LoadFont("tahoma", 10);
            lblPlayer.AutoSize = true;
            
            lblPlayer.Text = "Player Name:";

            txtPlayer = new TextBox("txtPlayer");
            txtPlayer.Location = new Point(20, 20);
            txtPlayer.Size = new System.Drawing.Size(120, 20);
            txtPlayer.Font = Graphics.FontManager.LoadFont("PMDCP", 16);

            lblGuild = new Label("lblGuild");
            lblGuild.Location = new Point(20, 60);
            lblGuild.Font = Graphics.FontManager.LoadFont("tahoma", 10);
            lblGuild.AutoSize = true;
            lblGuild.Text = "Guild Name:";

            txtGuild = new TextBox("txtGuild");
            txtGuild.Location = new Point(20, 80);
            txtGuild.Size = new System.Drawing.Size(120, 20);
            txtGuild.Font = Graphics.FontManager.LoadFont("PMDCP", 16);

            
            lblCreate = new Label("lblCreate");
            lblCreate.Location = new Point(40, 140);
            lblCreate.Font = Graphics.FontManager.LoadFont("tahoma", 10);
            lblCreate.AutoSize = true;
            lblCreate.Text = "Create";
            lblCreate.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblCreate_Click);


            this.AddWidget(lblPlayer);
            this.AddWidget(lblGuild);
            this.AddWidget(txtPlayer);
            this.AddWidget(txtGuild);
            this.AddWidget(lblCreate);

            this.LoadComplete();
        }

        void lblCreate_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            //Messenger.MakeGuild(txtPlayer.Text, txtGuild.Text);
        }

    }
}
