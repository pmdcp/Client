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

using SdlDotNet.Widgets;
using System.Drawing;

namespace Client.Logic.Windows
{
    class winChangePassword : Core.WindowCore
    {
        Label lblBack;
        Label lblName;
        Label lblPassword;
        Label lblNewPassword;
        Label lblRetypePassword;
        Label lblChangePassword;
        TextBox txtName;
        TextBox txtPassword;
        TextBox txtNewPassword;
        TextBox txtRetypePassword;

        public winChangePassword()
            : base("winChangePassword")
        {
            this.Windowed = true;
            this.ShowInWindowSwitcher = false;
            this.TitleBar.Text = "Change Password";
            this.TitleBar.CloseButton.Visible = false;
            this.Size = new Size(280, 360);
            //this.BackgroundImage = Skins.SkinManager.LoadGui("Change Password");
            this.Location = new Point(DrawingSupport.GetCenter(SdlDotNet.Graphics.Video.Screen.Size, this.Size).X, 5);

            lblBack = new Label("lblBack");
            lblBack.Font = Graphics.FontManager.LoadFont("PMDCP", 32);
            lblBack.Text = "Back to Account Settings";
            lblBack.Location = new Point(45, 300);
            lblBack.AutoSize = true;
            lblBack.ForeColor = Color.Black;
            lblBack.Click += new EventHandler<MouseButtonEventArgs>(lblBack_Click);

            lblName = new Label("lblName");
            lblName.Font = Graphics.FontManager.LoadFont("PMDCP", 18);
            lblName.Location = new Point(60, 57);
            lblName.AutoSize = true;
            lblName.ForeColor = Color.Black;
            lblName.Text = "Enter your Account Name";

            lblPassword = new Label("lblPassword");
            lblPassword.Font = Graphics.FontManager.LoadFont("PMDCP", 18);
            lblPassword.Location = new Point(60, 103);
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.Black;
            lblPassword.Text = "Enter your current Password";

            lblNewPassword = new Label("lblNewPassword");
            lblNewPassword.Font = Graphics.FontManager.LoadFont("PMDCP", 18);
            lblNewPassword.Location = new Point(60, 149);
            lblNewPassword.AutoSize = true;
            lblNewPassword.ForeColor = Color.Black;
            lblNewPassword.Text = "Enter your new Password";

            lblRetypePassword = new Label("lblRetypePassword");
            lblRetypePassword.Font = Graphics.FontManager.LoadFont("PMDCP", 18);
            lblRetypePassword.Location = new Point(60, 195);
            lblRetypePassword.AutoSize = true;
            lblRetypePassword.ForeColor = Color.Black;
            lblRetypePassword.Text = "Reenter your new Password";

            lblChangePassword = new Label("lblChangePassword");
            lblChangePassword.Font = Graphics.FontManager.LoadFont("PMDCP", 18);
            lblChangePassword.Location = new Point(70, 241);
            lblChangePassword.AutoSize = true;
            lblChangePassword.ForeColor = Color.Black;
            lblChangePassword.Text = "Change your Password!";
            lblChangePassword.Click += new EventHandler<MouseButtonEventArgs>(lblChangePassword_Click);

            txtName = new TextBox("txtName");
            txtName.Size = new System.Drawing.Size(165, 16);
            txtName.Location = new Point(60, 78);

            txtPassword = new TextBox("txtPassword");
            txtPassword.Size = new System.Drawing.Size(165, 16);
            txtPassword.Location = new Point(60, 124);

            txtNewPassword = new TextBox("txtNewPassword");
            txtNewPassword.Size = new System.Drawing.Size(165, 16);
            txtNewPassword.Location = new Point(60, 170);

            txtRetypePassword = new TextBox("txtRetypePassword");
            txtRetypePassword.Size = new System.Drawing.Size(165, 16);
            txtRetypePassword.Location = new Point(60, 216);

            this.AddWidget(lblBack);
            this.AddWidget(lblName);
            this.AddWidget(lblPassword);
            this.AddWidget(lblNewPassword);
            this.AddWidget(lblRetypePassword);
            this.AddWidget(lblChangePassword);
            this.AddWidget(txtName);
            this.AddWidget(txtPassword);
            this.AddWidget(txtNewPassword);
            this.AddWidget(txtRetypePassword);

            this.LoadComplete();
        }

        void lblBack_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            this.Close();
            WindowSwitcher.ShowAccountSettings();
        }

        void lblChangePassword_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtNewPassword.Text) && !string.IsNullOrEmpty(txtRetypePassword.Text))
            {
                if (txtNewPassword.Text == txtRetypePassword.Text)
                {
                    Network.Messenger.SendPasswordChange(txtName.Text, txtPassword.Text, txtNewPassword.Text);
                }
            }
        }
    }
}
