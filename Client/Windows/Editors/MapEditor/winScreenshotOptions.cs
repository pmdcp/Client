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

namespace Client.Logic.Windows.Editors.MapEditor
{
    class winScreenshotOptions : Window
    {
        CheckBox chkCaptureRegion;
        CheckBox chkCaptureAttributes;
        CheckBox chkCaptureMapGrid;
        Button btnTakeScreenshot;
        Button btnCancel;
        Label lblSaved;
        Timer tmrHideInfo;

        public winScreenshotOptions()
            : base("winScreenshotOptions")
        {
            this.Windowed = true;
            this.ShowInWindowSwitcher = false;
            this.TitleBar.Text = "Screenshot Options";
            this.TitleBar.Font = Graphics.FontManager.LoadFont("tahoma", 12);
            this.TitleBar.CloseButton.Visible = false;
            this.AlwaysOnTop = true;
            this.BackColor = Color.White;
            this.BorderStyle = SdlDotNet.Widgets.BorderStyle.FixedSingle;
            this.BorderWidth = 2;
            this.BorderColor = Color.Black;
            this.Size = new Size(200, 150);
            this.Location = DrawingSupport.GetCenter(SdlDotNet.Graphics.Video.Screen.Size, this.Size);

            chkCaptureRegion = new CheckBox("chkCaptureRegion");
            chkCaptureRegion.BackColor = Color.Transparent;
            chkCaptureRegion.Location = new Point(5, 5);
            chkCaptureRegion.Font = Graphics.FontManager.LoadFont("tahoma", 12);
            chkCaptureRegion.Size = new Size(200, 15);
            chkCaptureRegion.Text = "Only capture visible area";

            chkCaptureAttributes = new CheckBox("chkCaptureAttributes");
            chkCaptureAttributes.BackColor = Color.Transparent;
            chkCaptureAttributes.Location = new Point(5, 20);
            chkCaptureAttributes.Font = Graphics.FontManager.LoadFont("tahoma", 12);
            chkCaptureAttributes.Size = new Size(200, 15);
            chkCaptureAttributes.Text = "Capture Attributes";
            chkCaptureAttributes.Checked = true;

            chkCaptureMapGrid = new CheckBox("chkCaptureMapGrid");
            chkCaptureMapGrid.BackColor = Color.Transparent;
            chkCaptureMapGrid.Location = new Point(5, 35);
            chkCaptureMapGrid.Font = Graphics.FontManager.LoadFont("tahoma", 12);
            chkCaptureMapGrid.Size = new Size(200, 15);
            chkCaptureMapGrid.Text = "Capture Map Grid";
            chkCaptureMapGrid.Checked = true;

            btnTakeScreenshot = new Button("btnTakeScreenshot");
            btnTakeScreenshot.Size = new Size(70, 20);
            btnTakeScreenshot.Location = new Point(5, 70);
            btnTakeScreenshot.Font = Graphics.FontManager.LoadFont("tahoma", 12);
            btnTakeScreenshot.Text = "Save!";
            btnTakeScreenshot.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(btnTakeScreenshot_Click);

            btnCancel = new Button("btnCancel");
            btnCancel.Size = new Size(70, 20);
            btnCancel.Location = new Point(80, 70);
            btnCancel.Font = Graphics.FontManager.LoadFont("tahoma", 12);
            btnCancel.Text = "Cancel";
            btnCancel.Click += new EventHandler<SdlDotNet.Widgets.MouseButtonEventArgs>(btnCancel_Click);

            lblSaved = new Label("lblSaved");
            lblSaved.AutoSize = true;
            lblSaved.Font = Graphics.FontManager.LoadFont("tahoma", 12);
            lblSaved.Location = new Point(5, btnTakeScreenshot.Y + btnTakeScreenshot.Height + 5);
            lblSaved.Text = "Saved!";
            lblSaved.Visible = false;

            tmrHideInfo = new Timer("tmrHideInfo");
            tmrHideInfo.Interval = 2000;
            tmrHideInfo.Elapsed += new EventHandler(tmrHideInfo_Elapsed);

            this.AddWidget(chkCaptureRegion);
            this.AddWidget(chkCaptureAttributes);
            this.AddWidget(chkCaptureMapGrid);
            this.AddWidget(btnTakeScreenshot);
            this.AddWidget(btnCancel);
            this.AddWidget(lblSaved);
            this.AddWidget(tmrHideInfo);

            this.LoadComplete();
        }

        void tmrHideInfo_Elapsed(object sender, EventArgs e)
        {
            tmrHideInfo.Stop();
            lblSaved.Visible = false;
        }

        void chkCaptureRegion_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
        }

        void btnCancel_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            this.Close();
        }

        void btnTakeScreenshot_Click(object sender, SdlDotNet.Widgets.MouseButtonEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Portable Network Graphic File|*.png|GIF File|*.gif|JPEG File|*.jpg|Bitmap File|*.bmp|Icon File|*.ico";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == SdlDotNet.Widgets.DialogResult.OK)
            {
                if (WindowSwitcher.GameWindow.MapViewer.ActiveMap != null && WindowSwitcher.GameWindow.MapViewer.ActiveMap.Loaded)
                {
                    SdlDotNet.Graphics.Surface surf = WindowSwitcher.GameWindow.MapViewer.CaptureMapImage(chkCaptureRegion.Checked, chkCaptureAttributes.Checked, chkCaptureMapGrid.Checked);
                    Graphics.SurfaceManager.SaveSurface(surf, sfd.FileName);
                    tmrHideInfo.Start();
                    lblSaved.Visible = true;
                }
            }
        }
    }
}
