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
    using System.Windows.Forms;

    /// <summary>
    /// Provides misc. methods
    /// </summary>
    public class Tools
    {
        #region Methods

        /// <summary>
        /// Displays a messagebox.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="text">The text.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        public static void MessageBox(string caption, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            System.Windows.Forms.MessageBox.Show(text, caption, buttons, icon);
        }

        /// <summary>
        /// Displays a messagebox.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        public static void MessageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox(Constants.GameName, text, buttons, icon);
        }

        /// <summary>
        /// Displays a messagebox.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="buttons">The buttons.</param>
        public static void MessageBox(string text, MessageBoxButtons buttons)
        {
            MessageBox(Constants.GameName, text, buttons, MessageBoxIcon.None);
        }

        /// <summary>
        /// Displays a messagebox.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void MessageBox(string text)
        {
            MessageBox(Constants.GameName, text, MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        
        /// <summary>
        /// Crops a surface from the specified surface.
        /// </summary>
        /// <param name="surfaceToCrop">The surface to crop.</param>
        /// <param name="cropRectangle">The rectangle bounds to crop.</param>
        /// <returns>The cropped surface.</returns>
        public static SdlDotNet.Graphics.Surface CropImage(SdlDotNet.Graphics.Surface surfaceToCrop, System.Drawing.Rectangle cropRectangle) {
            SdlDotNet.Graphics.Surface returnSurf = new SdlDotNet.Graphics.Surface(cropRectangle.Size);
            returnSurf.Transparent = surfaceToCrop.Transparent;
            //returnSurf.Fill(System.Drawing.Color.Transparent);
            //returnSurf.TransparentColor = surfaceToCrop.TransparentColor;
            returnSurf.Blit(surfaceToCrop, new System.Drawing.Point(0, 0), cropRectangle);
            return returnSurf;
        }
        
        /// <summary>
        /// Combines two surfaces together.
        /// </summary>
        /// <param name="bottomImage">The surface that will be used as the background.</param>
        /// <param name="topImage">The surface that will be used as the foreground.</param>
        /// <returns>The combined surface.</returns>
        public static SdlDotNet.Graphics.Surface CombineImage(SdlDotNet.Graphics.Surface bottomImage, SdlDotNet.Graphics.Surface topImage) {
            SdlDotNet.Graphics.Surface returnSurf = new SdlDotNet.Graphics.Surface(new System.Drawing.Size(System.Math.Max(bottomImage.Width, topImage.Width), System.Math.Max(bottomImage.Height, topImage.Height)));
            returnSurf.Blit(bottomImage, new System.Drawing.Point(0, 0));
            returnSurf.Blit(topImage, new System.Drawing.Point(0, 0));
            return returnSurf;
        }
        
        #endregion Methods
    }
}