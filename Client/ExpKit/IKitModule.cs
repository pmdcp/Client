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

namespace Client.Logic.ExpKit
{
    interface IKitModule
    {
        void Created(int index);
        /// <summary>
        /// Called when the module is switched for another module
        /// </summary>
        void SwitchOut();
        /// <summary>
        /// Called when the module is set as the active module
        /// </summary>
        void Initialize(Size containerSize);
        /// <summary>
        /// Gets the index # of the module
        /// </summary>
        int ModuleIndex { get; }
        /// <summary>
        /// Gets the friendly name of the module
        /// </summary>
        string ModuleName { get; }
        Panel ModulePanel { get; }
        bool Enabled { get; set; }
        Enums.ExpKitModules ModuleID { get; }
        event EventHandler EnabledChanged;
    }
}
