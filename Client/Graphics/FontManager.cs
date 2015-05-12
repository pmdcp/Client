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


namespace Client.Logic.Graphics
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	using SdlDotNet.Graphics;

	/// <summary>
	/// Class used for managing the game fonts.
	/// </summary>
	public class FontManager
	{
        #region Properties

		/// <summary>
		/// Gets or Sets the font used as the main map font
		/// </summary>
		public static Font GameFont {
			get;
			set;
		}

        public static Font GameFontSmall {
            get;
            set;
        }

		#endregion Properties

		#region Methods

		/// <summary>
		/// Initializes the textbox font.
		/// </summary>
		public static void InitFonts()
		{
			GameFont = LoadFont("PMDCP.ttf", 24);
            GameFontSmall = LoadFont("PMDCP.ttf", 16);
		}

		/// <summary>
		/// Loads a font.
		/// </summary>
		/// <param name="fontName">Filename of the font to load.</param>
		/// <param name="pointSize">Size of the font.</param>
		/// <returns></returns>
		public static Font LoadFont(string fontName, int pointSize)
		{
			if (fontName.EndsWith(".ttf") == false)
				fontName += ".ttf";
			return new Font(IO.Paths.FontPath + fontName, pointSize);
		}

		#endregion Methods
	}
}