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

namespace Client.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Graphics = Client.Logic.Graphics;

    /// <summary>
    /// Class for storing global variables.
    /// </summary>
    class Globals
    {
        #region Properties

        public static bool FoolsMode
        {
            get;
            set;
        }

        public static PMDCP.Core.Command CommandLine
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the encryption class.
        /// </summary>
        /// <value>The encryption class.</value>
        public static Security.Encryption Encryption
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the game is loaded.
        /// </summary>
        /// <value><c>true</c> if the game is loaded; otherwise, <c>false</c>.</value>
        public static bool GameLoaded
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the game screen.
        /// </summary>
        /// <value>The game screen.</value>
        public static Windows.Core.GameScreen GameScreen
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the game is running in debug mode.
        /// </summary>
        /// <value><c>true</c> if the game is running in debug mode; otherwise, <c>false</c>.</value>
        public static bool InDebugMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the games weather
        /// </summary>
        //internal static Enums.Weather GameWeather {
        //    get;
        //    set;
        //}


        static Enums.Weather activeWeather;
        /// <summary>
        /// Gets or Sets the active weather that will be displayed
        /// </summary>
        internal static Enums.Weather ActiveWeather
        {
            get { return activeWeather; }
            set
            {
                activeWeather = value;
                Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.SetWeather(value);
            }
        }

        /// <summary>
        /// Gets or Sets the games time
        /// </summary>
        internal static Enums.Time GameTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the active time that will be displayed
        /// </summary>
        internal static Enums.Time ActiveTime
        {
            get;
            set;
        }

        //internal static int CameraX {
        //    get;
        //    set;
        //}

        //internal static int CameraX2 {
        //    get;
        //    set;
        //}

        //internal static int CameraY {
        //    get;
        //    set;
        //}

        //internal static int CameraY2 {
        //    get;
        //    set;
        //}

        internal static int NewPlayerX
        {
            get;
            set;
        }

        internal static int NewPlayerY
        {
            get;
            set;
        }

        internal static int NewXOffset
        {
            get;
            set;
        }

        internal static int NewYOffset
        {
            get;
            set;
        }

        internal static int NewMapX
        {
            get;
            set;
        }

        internal static int NewMapY
        {
            get;
            set;
        }

        internal static int NewMapXOffset
        {
            get;
            set;
        }

        internal static int NewMapYOffset
        {
            get;
            set;
        }

        internal static bool GettingMap
        {
            get;
            set;
        }

        internal static bool SavingMap
        {
            get;
            set;
        }

        internal static int Tick
        {
            get;
            set;
        }

        internal static bool RefreshLock
        {
            get;
            set;
        }

        internal static bool InGame
        {
            get;
            set;
        }

        public static string ServerStatus
        {
            get;
            set;
        }

        #endregion Properties
    }
}