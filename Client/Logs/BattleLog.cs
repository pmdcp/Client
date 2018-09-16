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

namespace Client.Logic.Logs
{
    class BattleLog
    {
        public static readonly int MaxMessages = 500;
        public static readonly int MaxShownMessages = 5;

        public static Queue<String> Messages;
        public static Queue<Color> MessageColor;


        public static void Initialize()
        {
            Messages = new Queue<string>();
            MessageColor = new Queue<Color>();
        }

        public static void AddLog(string message, Color color)
        {
            if (Messages.Count == MaxMessages)
            {
                Messages.Dequeue();
                MessageColor.Dequeue();
            }
            Messages.Enqueue(message);
            MessageColor.Enqueue(color);
        }
    }
}
