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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Client.Logic.Network;
using PMDCP.Sockets;

namespace Client.Logic.Windows.Editors.ScriptEditor
{
    partial class frmScriptEditor : Form
    {
        public frmScriptEditor() {
            InitializeComponent();

        }

        private delegate void AddDocumentTabDelegate(ScriptFileTab tab);
        public void AddDocumentTab(ScriptFileTab tab) {
            if (InvokeRequired) {
                Invoke(new AddDocumentTabDelegate(AddDocumentTab), tab);
            } else {
                TabPage page = new TabPage(tab.File);
                tab.AddToTabPage(page);
                tabControl1.TabPages.Add(page);
            }

        }

        private void button1_Click(object sender, EventArgs e) {
            Messenger.SendPacket(TcpPacket.CreatePacket("requesteditscriptfile", (string)comboBox1.SelectedItem));
        }

        private delegate void SetFileListDelegate(List<string> files);
        public void SetFileList(List<String> files) {
            if (InvokeRequired) {
                Invoke(new SetFileListDelegate(SetFileList), files);
            } else {
                comboBox1.Items.Clear();
                for (int i = 0; i < files.Count; i++) {
                    comboBox1.Items.Add(files[i]);
                }
            }
        }

        private delegate void SetClassesListDelegate(List<string> files);
        public void SetClassesList(List<string> files) {
            if (InvokeRequired) {
                Invoke(new SetClassesListDelegate(SetClassesList), files);
            } else {
                comboBox2.Items.Clear();
                for (int i = 0; i < files.Count; i++) {
                    comboBox2.Items.Add(files[i]);
                }
            }
        }

        private delegate void SetMethodsListDelegate(List<string> files);
        public void SetMethodsList(List<string> files) {
            if (InvokeRequired) {
                Invoke(new SetMethodsListDelegate(SetMethodsList), files);
            } else {
                comboBox3.Items.Clear();
                for (int i = 0; i < files.Count; i++) {
                    comboBox3.Items.Add(files[i]);
                }
            }
        }

        private delegate void SetErrorsListDelegate(List<string> errors);
        public void SetErrorsList(List<string> errors) {
            if (InvokeRequired) {
                Invoke(new SetErrorsListDelegate(SetErrorsList), errors);
            } else {
                listBox1.Items.Clear();
                for (int i = 0; i < errors.Count; i++) {
                    listBox1.Items.Add(errors[i]);
                }
            }
        }

        private delegate void SetScriptParameterInfoDelegate(string info);
        public void SetScriptParameterInfo(string info) {
            if (InvokeRequired) {
                Invoke(new SetScriptParameterInfoDelegate(SetScriptParameterInfo), info);
            } else {
                lblParameters.Text = "Parameters: " + info;
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e) {
            ScriptFileTab tab = tabControl1.SelectedTab.Tag as ScriptFileTab;
            if (tab != null) {
                Messenger.SendPacket(TcpPacket.CreatePacket("savescript", tab.File.Replace(".cs", ""),
                    tab.SyntaxBox.Document.Text.Replace(TcpPacket.SEP_CHAR, '/')));
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e) {
            Messenger.SendPacket(TcpPacket.CreatePacket("reloadscripts"));
        }

        private void finalizeScriptToolStripMenuItem_Click(object sender, EventArgs e) {
            Messenger.SendPacket(TcpPacket.CreatePacket("finalizescript"));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            Messenger.SendPacket(TcpPacket.CreatePacket("getscriptmethods", (string)comboBox2.SelectedItem));
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
            Messenger.SendPacket(TcpPacket.CreatePacket("getscriptparam", (string)comboBox3.Items[0], (string)comboBox3.SelectedItem, numericUpDown1.Value.ToString()));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            Messenger.SendPacket(TcpPacket.CreatePacket("getscriptparam", (string)comboBox3.Items[0], (string)comboBox3.SelectedItem, numericUpDown1.Value.ToString()));
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e) {
            Messenger.SendPacket(TcpPacket.CreatePacket("addnewclass", toolStripTextBox1.Text));
        }

        private void listBox1_MouseLeave(object sender, EventArgs e) {
            listBox1.Hide();
            pnlOptions.Show();
            panel2.Size = new Size(968, 42);
        }

        private void button2_Click(object sender, EventArgs e) {
            pnlOptions.Hide();
            listBox1.Show();
            panel2.Size = new Size(968, 186);
        }

        private void frmScriptEditor_FormClosing(object sender, FormClosingEventArgs e) {
            Messenger.SendPacket(TcpPacket.CreatePacket("scripteditexit"));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void lblParameters_Click(object sender, EventArgs e)
        {

        }


    }
}
