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


namespace Client.Logic.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class that handles any exceptions that occur in the program.
    /// </summary>
    public class ExceptionHandler
    {
        #region Methods

        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="ex">The exception.</param>
        public static void OnException(Exception ex)
        {
            ErrorBox.ShowDialog("Unhandled Exception", ex.Message, ex.ToString());
        }

        #endregion Methods
    }
}