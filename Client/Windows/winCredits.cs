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

namespace Client.Logic.Windows
{
    class winCredits : Core.WindowCore
    {
        Label lblTeam;
        Label lblBack;
        Label lblProgramming;
        Label lblPikablu;

        public winCredits()
            : base("WinCredits")
        {
            this.Windowed = true;
            this.ShowInWindowSwitcher = false;
            this.TitleBar.Text = "Credits";
            this.TitleBar.CloseButton.Visible = false;
            //this.BackgroundImage = Skins.SkinManager.LoadGui("Credits");
            //this.Size = this.BackgroundImage.Size;
            this.BackColor = Color.White;
            this.Size = new Size(400, 400);
            this.Location = DrawingSupport.GetCenter(SdlDotNet.Graphics.Video.Screen.Size, this.Size);

            lblTeam = new Label("lblTeam");
            lblTeam.Font = Graphics.FontManager.LoadFont("PMDCP", 30);
            lblTeam.AutoSize = true;
            lblTeam.Location = new Point(30, 20);
            lblTeam.Text = "The PMDCP Team!";
            lblTeam.BackColor = Color.GreenYellow;

            lblBack = new Label("lblBack");
            lblBack.Font = Graphics.FontManager.LoadFont("PMDCP", 20);
            lblBack.AutoSize = true;
            lblBack.Location = new Point(0, 330);
            lblBack.Text = "Return to Login Screen";
            lblBack.BackColor = Color.Blue;
            lblBack.Click += new EventHandler<MouseButtonEventArgs>(lblBack_Click);

            lblProgramming = new Label("lblProgramming");
            lblProgramming.Font = Graphics.FontManager.LoadFont("PMDCP", 25);
            lblProgramming.AutoSize = true;
            lblProgramming.Location = new Point(0, 80);
            lblProgramming.Text = "Everything:";
            lblProgramming.BackColor = Color.Silver;

            lblPikablu = new Label("lblPikablu");
            lblPikablu.Font = Graphics.FontManager.LoadFont("PMDCP", 20);
            lblPikablu.AutoSize = true;
            lblPikablu.Location = new Point(120, 85);
            lblPikablu.Text = "Visit http://mdcp.wikia.com for a full list!";
            lblPikablu.BackColor = Color.Yellow;

            this.AddWidget(lblTeam);
            this.AddWidget(lblBack);
            this.AddWidget(lblProgramming);
            this.AddWidget(lblPikablu);
            this.LoadComplete();
        }

        void lblBack_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            this.Close();
            WindowSwitcher.ShowMainMenu();
        }
    }
}
