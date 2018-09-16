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


namespace Client.Logic.Windows.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    using Client.Logic.Graphics;

    using SdlEvents = SdlDotNet.Core.Events;
    using SdlGfx = SdlDotNet.Graphics;
    using SdlVideo = SdlDotNet.Graphics.Video;
    using Gfx = Client.Logic.Graphics;

    /// <summary>
    /// The actual screen where the game is drawn onto.
    /// </summary>
    public class GameScreen
    {
        #region Fields

        internal FadeCallback fadeCallback;
        internal bool fadeOut;
        internal byte fadeSpeed;
        internal bool isFading;

        int lastTick = 0;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GameScreen"/> class.
        /// </summary>
        public GameScreen()
        {
        }

        #endregion Constructors

        #region Delegates

        internal delegate void FadeCallback();

        #endregion Delegates

        #region Properties

        //internal Gui.TaskBar.TaskBar TaskBar {
        //    get { return tskTaskBar; }
        //}

        #endregion Properties

        #region Methods

        internal void InitControls()
        {
            // Load the debug label
            //lblInfo = new Client.Logic.Gui.Label(FontManager.MainFont);
            //lblInfo.ForeColor = Color.Black;
            //lblInfo.Backcolor = Color.Transparent;
            //lblInfo.AntiAlias = false;

            //btnDebug = new Client.Logic.Gui.Button(Logic.Graphics.FontManager.LoadFont("PMDCP", 32));
            //btnDebug.Size = new Size(150, 40);
            //btnDebug.Location = new Point(0, 50);
            //btnDebug.Text = "Show Debug Window";
            //btnDebug.OnClick += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(btnDebug_OnClick);
            //btnDebug.HoverColor = Color.SteelBlue;
            //btnDebug.BorderWidth = 1;
            //btnDebug.BorderColor = Color.Black;
            //btnDebug.Backcolor = SystemColors.Control;
            //btnDebug.AddEvents();

            //tskTaskBar = new Client.Logic.Gui.TaskBar.TaskBar();
            //tskTaskBar.Location = new Point(0, SdlVideo.Screen.Height - 20);
        }

        void DebugWindow_OnWindowClosed(object sender, EventArgs e)
        {
            //btnDebug.Text = "Show Debug Window";
        }

        void SdlEvents_Tick(object sender, SdlDotNet.Core.TickEventArgs e)
        {
            //if (SdlDotNet.Graphics.Video.IsActive == false)
            //    return;
            //if (TickStabalizer.CanUpdate(e)) {
            //if (Gfx.GuiManager.ScreenBackground != null) {
            //    SdlVideo.Screen.Blit(Gfx.GuiManager.ScreenBackground);
            //} else {
            //    SdlVideo.Screen.Fill(Color.SteelBlue);
            //}

            // Version info
            //if (Globals.GameLoaded) {
            //    if (lblInfo != null) {
            //        if (SdlDotNet.Core.Timer.TicksElapsed > lastTick + 1000) {
            //            lblInfo.Text = "Version: PMDCP 7 [Alpha-Debug]\tFPS: " + e.Fps.ToString();
            //            lastTick = SdlDotNet.Core.Timer.TicksElapsed;
            //        }
            //        lblInfo.Update(SdlDotNet.Graphics.Video.Screen, e);
            //    }
            //}
            //if (Globals.InDebugMode && Globals.GameLoaded) {
            //    if (btnDebug != null) {
            //        btnDebug.Update(SdlDotNet.Graphics.Video.Screen, e);
            //    }
            //}

            //SdlDotNet.Widgets.WindowManager.DrawWindows(e);

            //if (Globals.GameLoaded) {
            //    tskTaskBar.Update(SdlVideo.Screen, e);
            //}
            if (isFading)
            {
                if (fadeOut)
                {
                    if (GraphicsManager.FadeSurface.Alpha < 255)
                    {
                        GraphicsManager.FadeSurface.Alpha += (byte)fadeSpeed;
                    }
                    else
                    {
                        isFading = false;
                        fadeCallback();
                    }
                }
                else
                {
                    if (GraphicsManager.FadeSurface.Alpha > 0)
                    {
                        GraphicsManager.FadeSurface.Alpha -= (byte)fadeSpeed;
                    }
                    else
                    {
                        isFading = false;
                        fadeCallback();
                    }
                }
                SdlDotNet.Graphics.Video.Screen.Blit(GraphicsManager.FadeSurface);
            }

            //    SdlVideo.Screen.Update();
            //}
        }

        void btnDebug_OnClick(object sender, SdlDotNet.Input.MouseButtonEventArgs e)
        {
            //if (SdlDotNet.Widgets.WindowManager.IsWindowOpen(WindowSwitcher.GetWindow(WindowSwitcher.Window.Debug)) == false) {
            //    WindowManager.AddWindow(WindowSwitcher.Window.Debug);
            //    WindowSwitcher.DebugWindow.OnWindowClosed += new EventHandler(DebugWindow_OnWindowClosed);
            //    btnDebug.Text = "Close Debug Window";
            //} else {
            //    WindowSwitcher.DebugWindow.OnWindowClosed -= new EventHandler(DebugWindow_OnWindowClosed);
            //    WindowManager.RemoveWindow(WindowSwitcher.Window.Debug);
            //    btnDebug.Text = "Show Debug Window";
            //}
        }

        #endregion Methods
    }
}