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
using SdlDotNet.Graphics;

namespace Client.Logic.Stories.Components
{
    class ScreenImageOverlay
    {
        string file;
        string imageID;
        int x;
        int y;
        Surface surface;

        public string File
        {
            get { return file; }
        }

        public string ImageID
        {
            get { return imageID; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public Surface Surface
        {
            get { return surface; }
        }

        public ScreenImageOverlay(string file, string imageID, int x, int y)
        {
            this.file = file;
            this.imageID = imageID;
            this.x = x;
            this.y = y;
        }

        public void LoadImage()
        {
            surface = Logic.Graphics.SurfaceManager.LoadSurface(IO.Paths.StoryDataPath + "Images/" + file);
        }
    }
}
