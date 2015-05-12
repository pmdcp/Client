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
using System.Threading;

namespace Client.Logic.Sdl
{
    class SdlLoader
    {
        public static void InitializeSdl()
        {
            SdlDotNet.Graphics.Video.SetVideoMode(850, 640, 32, false, false, false);
            SdlDotNet.Graphics.Video.WindowIcon();
            SdlDotNet.Graphics.Video.WindowCaption = Constants.GameName;
            SdlDotNet.Input.Keyboard.EnableKeyRepeat(5, 5);

            SdlDotNet.Core.Events.Tick += new EventHandler<SdlDotNet.Core.TickEventArgs>(SdlEventHandler.SdlDotNet_Core_Events_Tick);
            SdlDotNet.Core.Events.Quit += new EventHandler<SdlDotNet.Core.QuitEventArgs>(SdlEventHandler.SdlDotNet_Core_Events_Quit);
            SdlDotNet.Core.Events.KeyboardDown += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(SdlEventHandler.SdlDotNet_Core_Events_KeyboardDown);
            SdlDotNet.Core.Events.KeyboardUp += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(SdlEventHandler.SdlDotNet_Core_Events_KeyboardUp);
            SdlDotNet.Core.Events.MouseMotion += new EventHandler<SdlDotNet.Input.MouseMotionEventArgs>(SdlEventHandler.SdlDotNet_Core_Events_MouseMotion);
            SdlDotNet.Core.Events.MouseButtonDown += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(SdlEventHandler.SdlDotNet_Core_Events_MouseButtonDown);
            SdlDotNet.Core.Events.MouseButtonUp += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(SdlEventHandler.SdlDotNet_Core_Events_MouseButtonUp);

            SdlDotNet.Core.Events.TargetFps = Constants.FRAME_RATE;

            SdlDotNet.Widgets.WindowManager.SetMainThread();

            // Create and run the loading thread
            Thread loadThread = new Thread(new ThreadStart(Loader.LoadData));
            loadThread.IsBackground = true;
            loadThread.Name = "PMDCP Load Thread";
            loadThread.Priority = ThreadPriority.Normal;
            loadThread.Start();

            SdlDotNet.Core.Events.Run();

            IO.Options.SaveXml();
        }

    }
}
