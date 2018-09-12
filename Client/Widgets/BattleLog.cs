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

namespace Client.Logic.Widgets
{
    class BattleLog : BorderedPanel
    {
        Label lblLog;
        public Timer tmrHide;

        public BattleLog(string name)
            : base(name)
        {
            lblLog = new Label("lblLog");
            lblLog.BackColor = Color.Transparent;
            lblLog.Size = new Size(this.Size.Width, this.Size.Height);
            lblLog.Font = Graphics.FontManager.LoadFont("PMDCP", 16);
            lblLog.Location = new Point(0, -4);

            this.Resized += new EventHandler(BattleLog_Resized);

            tmrHide = new Timer("tmrHide");
            tmrHide.Interval = 5000;
            tmrHide.Elapsed += new EventHandler(tmrHide_Elapsed);
            tmrHide.Start();

            this.AddWidget(tmrHide);
            this.WidgetPanel.AddWidget(lblLog);
        }

        void tmrHide_Elapsed(object sender, EventArgs e)
        {
            this.Visible = false;
            tmrHide.Stop();
        }

        void BattleLog_Resized(object sender, EventArgs e)
        {
            lblLog.Size = new Size(this.Size.Width, this.Size.Height);
        }

        public void AddLog(string message, Color color)
        {
            Logic.Logs.BattleLog.AddLog(message, color);
            string[] messageArray = Logic.Logs.BattleLog.Messages.ToArray();
            Color[] colorArray = Logic.Logs.BattleLog.MessageColor.ToArray();

            lblLog.Text = "";
            for (int i = Math.Max(messageArray.Length - Logic.Logs.BattleLog.MaxShownMessages, 0); i < messageArray.Length; i++)
            {
                lblLog.AppendText(messageArray[i], new CharRenderOptions(colorArray[i]));
                lblLog.AppendText("\n");
            }
        }
    }
}
