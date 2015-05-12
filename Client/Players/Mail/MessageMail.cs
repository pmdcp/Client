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

namespace Client.Logic.Players.Mail
{
    class MessageMail : IMail
    {
        #region Fields

        InventoryItem attachedItem;
        string recieverID;
        string senderID;
        string text;
        string title;

        Panel pnlMailInterface;

        #endregion Fields

        #region Properties

        public InventoryItem AttachedItem {
            get { return attachedItem; }
            set { attachedItem = value; }
        }

        public string RecieverID {
            get { return recieverID; }
            set { recieverID = value; }
        }

        public string SenderID {
            get { return senderID; }
            set { senderID = value; }
        }

        public string Text {
            get { return text; }
            set { text = value; }
        }

        public string Title {
            get { return title; }
            set { title = value; }
        }

        public MailType Type {
            get { return MailType.Message; }
        }

        public bool Unread {
            get;
            set;
        }

        #endregion Properties


        public SdlDotNet.Widgets.Panel MailInterfacePanel {
            get {
                CheckMailInterfacePanel();
                return pnlMailInterface;
            }
        }

        private void CheckMailInterfacePanel() {
            if (pnlMailInterface == null) {

            }
        }

        private void CreateMailInterfacePanel() {
            pnlMailInterface = new Panel("pnlMailInterface");
            pnlMailInterface.Size = new System.Drawing.Size(300, 400);


        }
    }
}
