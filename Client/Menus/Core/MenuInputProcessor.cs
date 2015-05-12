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


namespace Client.Logic.Menus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SdlInput = SdlDotNet.Input;

    class MenuInputProcessor
    {
        #region Methods

        public static void OnKeyDown(SdlInput.KeyboardEventArgs e) {
            //if (e.Key == SdlInput.Key.Escape) {
            //    if (Windows.WindowSwitcher.GameWindow.MenuManager.Visible && Windows.WindowSwitcher.GameWindow.MenuManager.HasModalMenu == false) {
            //        Windows.WindowSwitcher.GameWindow.MapViewer.Focus();
            //        Windows.WindowSwitcher.GameWindow.MenuManager.Visible = false;
            //        Windows.WindowSwitcher.GameWindow.MenuManager.CloseOpenMenus();
            //    } 
            //} else if (e.Key == SdlInput.Key.F11) {
            //    Logic.Graphics.SurfaceManager.SaveSurface(SdlDotNet.Graphics.Video.Screen, IO.Paths.StartupPath + "Screenshot.png");
            //} else {
                if (Windows.WindowSwitcher.GameWindow.MenuManager.Visible) {
                    Windows.WindowSwitcher.GameWindow.MenuManager.HandleKeyDown(e);
                }
            //}
        }

        public static void OnKeyUp(SdlInput.KeyboardEventArgs e) {
            if (e.Key == SdlInput.Key.Escape) {
                if (Windows.WindowSwitcher.GameWindow.MenuManager.Visible && Windows.WindowSwitcher.GameWindow.MenuManager.HasModalMenu == false) {
                    Windows.WindowSwitcher.GameWindow.MapViewer.Focus();
                    Windows.WindowSwitcher.GameWindow.MenuManager.Visible = false;
                    Windows.WindowSwitcher.GameWindow.MenuManager.CloseOpenMenus();
                }
            } else if (e.Key == SdlInput.Key.F11) {
                if (System.IO.Directory.Exists(IO.Paths.StartupPath + "Screenshots") == false) {
                    System.IO.Directory.CreateDirectory(IO.Paths.StartupPath + "Screenshots");
                }
                int openScreenshot = -1;
                for (int i = 1; i < Int32.MaxValue; i++) {
                    if (System.IO.File.Exists(IO.Paths.StartupPath + "Screenshots/Screenshot" + i + ".png") == false) {
                        openScreenshot = i;
                        break;
                    }
                }
                if (openScreenshot > -1) {
                    Logic.Graphics.SurfaceManager.SaveSurface(SdlDotNet.Graphics.Video.Screen, IO.Paths.StartupPath + "Screenshots/Screenshot" + openScreenshot + ".png");
                    ExpKit.Modules.kitChat chat = (ExpKit.Modules.kitChat)Windows.WindowSwitcher.ExpKit.KitContainer.ModuleSwitcher.FindKitModule(Enums.ExpKitModules.Chat);
                    if (chat != null) {
                        chat.AppendChat("Screenshot #" + openScreenshot + " saved!", System.Drawing.Color.Yellow);
                    }
                }
            } else {
                if (Windows.WindowSwitcher.GameWindow.MenuManager.Visible) {
                    Windows.WindowSwitcher.GameWindow.MenuManager.HandleKeyUp(e);
                }
            }
        }

        #endregion Methods
    }
}