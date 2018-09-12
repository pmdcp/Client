using System;
using System.Collections.Generic;
using System.Text;

using SdlDotNet.Widgets;
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


namespace Client.Logic.Windows
{
    class WindowSwitcher
    {
        #region Enumerations

        public enum Window
        {
            None,
            Debug,
            Loading,
            MainMenu,
            Login,
            CharSelect,
            Game
        }

        #endregion Enumerations

        #region Properties

        public static Window ActiveWindow
        {
            get;
            set;
        }

        public static winGame GameWindow
        {
            get;
            set;
        }

        public static winExpKit ExpKit
        {
            get;
            set;
        }

        public static Updater.winUpdater UpdaterWindow
        {
            get;
            set;
        }

        //public static winChat ChatWindow {
        //    get;
        //    set;
        //}

        //public static winChars CharSelectWindow
        //{
        //    get; set;
        //}

        //public static winDebug DebugWindow
        //{
        //    get; set;
        //}

        //public static winGame GameWindow
        //{
        //    get; set;
        //}

        #endregion Properties

        #region Methods

        public static SdlDotNet.Widgets.Window FindWindow(string windowName)
        {
            return SdlDotNet.Widgets.WindowManager.FindWindow(windowName);
        }

        public static void AddWindow(SdlDotNet.Widgets.Window window)
        {
            SdlDotNet.Widgets.WindowManager.AddWindow(window);
        }

        public static void ShowMainMenu()
        {
            SdlDotNet.Widgets.WindowManager.AddWindow(new winMainMenu());
            SdlDotNet.Widgets.WindowManager.AddWindow(new winUpdates());
            SdlDotNet.Widgets.WindowManager.AddWindow(new winLogin());
            // Now that the menus have been shown, lets play the menu music

        }

        public static void ShowAccountSettings()
        {
            SdlDotNet.Widgets.WindowManager.AddWindow(new winAccountSettings());
            //Music.Music.AudioPlayer.PlayMusic("Temporal Tower.mp3");
        }

        #endregion Methods
    }
}