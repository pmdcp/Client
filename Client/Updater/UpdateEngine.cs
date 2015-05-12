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

using PMDCP.Updater;
using PMDCP.Updater.Linker;
using PMDCP.Net;

namespace Client.Logic.Updater
{
    class UpdateEngine
    {
        UpdateClient updater;
        IUpdateCheckResult lastCheckResult;

        public readonly string UpdateURL = IO.Options.UpdateAddress;

        public UpdateClient Updater {
            get { return updater; }
        }

        public IUpdateCheckResult LastCheckResult {
            get { return lastCheckResult; }
        }

        public UpdateEngine(string packageListKey) {
            updater = new UpdateClient(packageListKey, System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\");//System.Windows.Forms.Application.StartupPath + "\\");
        }

        public bool CheckForUpdates() {
            //if (NetTools.IsConnected()) {
            // Load the installed package list
            updater.LoadInstalledPackageList();
            updater.InstallationComplete += new EventHandler(updater_InstallationComplete);
            lastCheckResult = updater.CheckForUpdates(UpdateURL);
            return (lastCheckResult.PackagesToUpdate.Count != 0);
            //} else {
            //    return false;
            //}
        }

        public void PerformUpdate(IUpdateCheckResult result) {
            if (result.PackagesToUpdate.Count != 0) {
                updater.PerformUpdate(result);
            }
        }

        void updater_InstallationComplete(object sender, EventArgs e) {
            //System.Windows.Forms.MessageBox.Show("Update complete!");
            //Environment.Exit(0);
        }
    }
}
