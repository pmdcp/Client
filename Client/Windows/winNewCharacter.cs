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

namespace Client.Logic.Windows
{
    class winNewCharacter : Core.WindowCore
    {
        Label lblName;
        TextBox txtName;
        Label lblCreateChar;
        Label lblBack;
        RadioButton optMale;
        RadioButton optFemale;
        int charSlot;

        public winNewCharacter(int charSlot)
            : base("winNewCharacter")
        {
            this.charSlot = charSlot;

            this.Windowed = true;
            this.ShowInWindowSwitcher = false;
            this.TitleBar.Text = "New Character";
            this.TitleBar.CloseButton.Visible = false;
            //this.BackgroundImage = Skins.SkinManager.LoadGui("New Character"); - We should have a better GUI for this.
            //this.Size = this.BackgroundImage.Size;
            this.Size = new Size(400, 200);
            this.Location = new Point(DrawingSupport.GetCenter(SdlDotNet.Graphics.Video.Screen.Size, this.Size).X, 5);

            lblName = new Label("lblName");
            lblName.Font = Graphics.FontManager.LoadFont("PMDCP", 18);
            lblName.Location = new Point(40, 40);
            lblName.AutoSize = true;
            lblName.Text = "Name:";

            txtName = new TextBox("txtName");
            txtName.Size = new System.Drawing.Size(177, 16);
            txtName.Location = new Point(40, 70);

            lblCreateChar = new Label("lblCreateChar");
            lblCreateChar.Font = Graphics.FontManager.LoadFont("PMDCP", 18);
            lblCreateChar.Location = new Point(40, 130);
            lblCreateChar.AutoSize = true;
            lblCreateChar.Text = "Create Character";
            lblCreateChar.Click += new EventHandler<MouseButtonEventArgs>(lblCreateChar_Click);

            lblBack = new Label("btnBack");
            lblBack.Font = Graphics.FontManager.LoadFont("PMDCP", 18);
            lblBack.Location = new Point(147, 130);
            lblBack.AutoSize = true;
            lblBack.Text = "Back to Login Screen";
            lblBack.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(lblBack_Click);

            optMale = new RadioButton("optMale");
            optMale.BackColor = Color.Transparent;
            optMale.Font = Graphics.FontManager.LoadFont("tahoma", 12);
            optMale.Location = new Point(240, 50);
            optMale.Size = new System.Drawing.Size(95, 17);
            optMale.Text = "Male";
            optMale.Checked = true;

            optFemale = new RadioButton("optFemale");
            optFemale.BackColor = Color.Transparent;
            optFemale.Font = Graphics.FontManager.LoadFont("tahoma", 12);
            optFemale.Location = new Point(240, 70);
            optFemale.Size = new System.Drawing.Size(95, 17);
            optFemale.Text = "Female";
            optFemale.Checked = false;

            this.AddWidget(lblName);
            this.AddWidget(txtName);
            this.AddWidget(lblCreateChar);
            this.AddWidget(lblBack);
            this.AddWidget(optMale);
            this.AddWidget(optFemale);
            this.LoadComplete();
        }

        void lblBack_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            this.Close();
            Messenger.SendCharListRequest();
        }

        //This is made not to decide rather the player is male or female, but only for sending the new name.
        void lblCreateChar_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            string name = txtName.Text;
            Enums.Sex sex = Enums.Sex.Male;
            if (optFemale.Checked) sex = Enums.Sex.Female;
            winLoading loading = new winLoading();
            loading.Show();
            loading.UpdateLoadText("Sending Character...");
            Messenger.SendNewChar(name, sex, charSlot);
            this.Close();
        }
    }
}
