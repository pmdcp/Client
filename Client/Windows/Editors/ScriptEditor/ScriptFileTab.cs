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
using System.Windows.Forms;

namespace Client.Logic.Windows.Editors.ScriptEditor
{
    class ScriptFileTab
    {
        Alsing.Windows.Forms.SyntaxBoxControl syntaxBox;
        string file;

        public string File {
            get {
                return file;
            }
        }

        public Alsing.Windows.Forms.SyntaxBoxControl SyntaxBox {
            get { return syntaxBox; }
        }

        public ScriptFileTab() {
            Load();
        }

        private delegate void LoadDelegate();
        private void Load() {
            if (Windows.Editors.EditorManager.ScriptEditor.InvokeRequired) {
                Windows.Editors.EditorManager.ScriptEditor.Invoke(new LoadDelegate(Load));
            } else {
                syntaxBox = new Alsing.Windows.Forms.SyntaxBoxControl();
                syntaxBox.AllowDrop = false;
                syntaxBox.Location = new System.Drawing.Point(0, 0);
                syntaxBox.Dock = System.Windows.Forms.DockStyle.Fill;
            }
        }

        public void AddToTabPage(TabPage tabPage) {
            tabPage.Controls.Add(syntaxBox);
            tabPage.Tag = this;
        }

        public void SetDocumentFile(string file) {
            this.file = file;
        }

        private delegate void SetDocumentDelegate(string text);
        public void SetDocumentText(string text) {
            if (Windows.Editors.EditorManager.ScriptEditor.InvokeRequired) {
                Windows.Editors.EditorManager.ScriptEditor.Invoke(new SetDocumentDelegate(SetDocumentText), text);
            } else {
                syntaxBox.Document.SyntaxFile = IO.Paths.StartupPath + "Script/CSharp.syn";
                syntaxBox.Document.Text = text;
                syntaxBox.Document.ReParse();
            }
        }
    }
}
