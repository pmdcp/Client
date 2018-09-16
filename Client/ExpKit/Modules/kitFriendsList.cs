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
using SdlDotNet.Widgets;
using System.Drawing;

namespace Client.Logic.ExpKit.Modules
{
    class kitFriendsList : Panel, IKitModule
    {
        int moduleIndex;
        bool enabled;
        Size containerSize;

        List<Label> friendNames;
        List<PictureBox> friendOnlineStatus;

        public kitFriendsList(string name)
            : base(name)
        {
            enabled = true;

            friendNames = new List<Label>();
            friendOnlineStatus = new List<PictureBox>();

            base.BackColor = Color.Transparent;
        }


        public void SwitchOut()
        {
        }

        public void Initialize(Size containerSize)
        {
            this.containerSize = containerSize;
            UpdateList(Players.PlayerManager.MyPlayer.FriendsList);
        }

        public void UpdateList(List<Players.Friend> friends)
        {
            if (friends.Count < friendNames.Count)
            {
                int widgetsToRemove = -1;
                widgetsToRemove = friendNames.Count - friends.Count;
                widgetsToRemove *= 2;
                for (int i = widgetsToRemove - 1; i >= 0; i--)
                {
                    this.RemoveWidget(ChildWidgets[(ChildWidgets.Count - 1) - i].Name);
                }
                for (int i = (widgetsToRemove / 2) - 1; i >= 0; i--)
                {
                    friendNames.RemoveAt(i);
                    friendOnlineStatus.RemoveAt(i);
                }
            }
            for (int i = 0; i < friends.Count; i++)
            {
                if (friendNames.Count <= i)
                {
                    Label lblName = new Label("lblName" + i);
                    lblName.Location = new Point(5, i * 25);
                    lblName.AutoSize = true;
                    lblName.Font = Logic.Graphics.FontManager.LoadFont("PMDCP", 16);
                    lblName.ForeColor = Color.WhiteSmoke;

                    PictureBox picOnlineStatus = new PictureBox("picOnlineStatus" + i);
                    picOnlineStatus.Size = new Size(20, 20);
                    picOnlineStatus.Location = new Point(containerSize.Width - picOnlineStatus.Width - 10, lblName.Y);
                    picOnlineStatus.BorderStyle = SdlDotNet.Widgets.BorderStyle.FixedSingle;

                    this.AddWidget(lblName);
                    this.AddWidget(picOnlineStatus);

                    friendNames.Add(lblName);
                    friendOnlineStatus.Add(picOnlineStatus);
                }
                friendNames[i].Text = friends[i].Name;
                if (friends[i].Online)
                {
                    friendOnlineStatus[i].BackColor = Color.Green;
                }
                else
                {
                    friendOnlineStatus[i].BackColor = Color.Red;
                }
            }
        }

        public int ModuleIndex
        {
            get { return moduleIndex; }
        }

        public string ModuleName
        {
            get { return "Friends List"; }
        }

        public void Created(int index)
        {
            moduleIndex = index;
        }

        public Panel ModulePanel
        {
            get { return this; }
        }


        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                if (EnabledChanged != null)
                    EnabledChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler EnabledChanged;


        public Enums.ExpKitModules ModuleID
        {
            get { return Enums.ExpKitModules.FriendsList; }
        }
    }
}
