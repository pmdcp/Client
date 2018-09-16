using System;
using System.Collections.Generic;
using System.Text;

using Client.Logic.Menus.Core;

using PMDCP.Core;
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


namespace Client.Logic.Stories.Segments
{
    class ShowImageSegment : ISegment
    {
        #region Fields

        string imageID;
        ListPair<string, string> parameters;
        int x;
        int y;
        StoryState storyState;
        string file;

        #endregion Fields

        #region Constructors

        public ShowImageSegment(string file, string imageID, int x, int y)
        {
            Load(file, imageID, x, y);
        }

        public ShowImageSegment()
        {
        }

        #endregion Constructors

        #region Properties

        public Enums.StoryAction Action
        {
            get { return Enums.StoryAction.ShowImage; }
        }

        public string File
        {
            get { return file; }
            set { file = value; }
        }


        public ListPair<string, string> Parameters
        {
            get { return parameters; }
        }

        public string ImageID
        {
            get { return imageID; }
            set { imageID = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public bool UsesSpeechMenu
        {
            get { return false; }
        }

        #endregion Properties

        #region Methods

        public void Load(string file, string imageID, int x, int y)
        {
            this.file = file;
            this.imageID = imageID;
            this.x = x;
            this.y = y;
        }

        public void LoadFromSegmentData(ListPair<string, string> parameters)
        {
            this.parameters = parameters;
            Load(parameters.GetValue("File"), parameters.GetValue("ImageID"), parameters.GetValue("X").ToInt(), parameters.GetValue("Y").ToInt());
        }

        public void Process(StoryState state)
        {
            storyState = state;
            state.ResetWaitEvent();

            Components.ScreenImageOverlay imageOverlay = new Components.ScreenImageOverlay(file, imageID, x, y);
            imageOverlay.LoadImage();
            Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.ScreenImageOverlays.Add(imageOverlay);
        }

        #endregion Methods
    }
}