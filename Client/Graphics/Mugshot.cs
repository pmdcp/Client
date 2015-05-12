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
using PMDCP.Core;
using SdlDotNet.Graphics;

namespace Client.Logic.Graphics
{
    class Mugshot : ICacheable
    {
         #region Fields

        int num;
        List<Surface> sheet;
        int sizeInBytes;
        string form;
        int frameCount;

        #endregion Fields

        #region Constructors

        public Mugshot(int num, string form)
        {
            this.num = num;
            this.form = form;
            sheet = new List<Surface>();
        }

        #endregion Constructors



        #region Properties

        public int Num {
            get { return num; }
        }

        public int FrameCount
        {
            get { return frameCount; }
        }

        #endregion Properties

        public int BytesUsed {
            get { return sizeInBytes; }
        }

        public Surface GetEmote(int index)
        {
            if (index >= 0 && index < sheet.Count)
            {
                return sheet[index];
            }
            return null;
        }

        public void LoadFromData(byte[] data)
        {
            Surface sheetSurface = new Surface(data);
            for (int i = 0; i < sheetSurface.Width; i += sheetSurface.Height)
            {
                Surface emote = new Surface(sheetSurface.Height, sheetSurface.Height);
                emote.Blit(sheetSurface, new System.Drawing.Point(), new System.Drawing.Rectangle(i, 0, sheetSurface.Height, sheetSurface.Height));
                sheet.Add(emote);
            }

            this.sizeInBytes = data.Length;
        }
    }
}
