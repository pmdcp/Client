using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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


namespace Client.Logic.Exceptions
{
    /// <summary>
    /// </summary>
    public partial class ErrorBox : Form
    {
        #region Fields

        bool errorShown;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorBox"/> class.
        /// </summary>
        public ErrorBox()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Shows the dialog box
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public static DialogResult ShowDialog(string caption, string message, string details)
        {
            ErrorBox error = new ErrorBox();
            error.lblError.Text = message;
            error.Text = caption;
            error.txtDetails.Text = details;

            try
            {
                Network.Messenger.SendPacket(PMDCP.Sockets.TcpPacket.CreatePacket("clienterror", details));
            }
            catch { }

            return error.ShowDialog();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (errorShown == false)
            {
                this.Size = new Size(499, 292);
                btnDetails.Text = "Details ^";
                errorShown = true;
            }
            else
            {
                this.Size = new Size(499, 193);
                btnDetails.Text = "Details v";
                errorShown = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion Methods
    }
}