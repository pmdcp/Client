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
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Client.Logic.Menus.Core;

    using PMDCP.Core;

    class ShowBackgroundSegment : ISegment
    {
        #region Fields

        string file;
        ListPair<string, string> parameters;
        StoryState storyState;

        #endregion Fields

        #region Constructors

        public ShowBackgroundSegment(string file) {
            Load(file);
        }

        public ShowBackgroundSegment() {
        }

        #endregion Constructors

        #region Properties

        public Enums.StoryAction Action {
            get { return Enums.StoryAction.ShowBackground; }
        }

        public string File {
            get { return file; }
            set { file = value; }
        }


        public ListPair<string, string> Parameters
        {
            get { return parameters; }
        }

        public bool UsesSpeechMenu {
            get { return false; }
        }

        #endregion Properties

        #region Methods

        public void Load(string file) {
            this.file = file;
        }

        public void LoadFromSegmentData(ListPair<string, string> parameters)
        {
            this.parameters = parameters;
            this.file = parameters.GetValue("File");
        }

        public void Process(StoryState state) {
            if (Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.StoryBackground != null) {
                Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.StoryBackground.Dispose();
            }
            Logic.Graphics.Renderers.Screen.ScreenRenderer.RenderOptions.StoryBackground = Logic.Graphics.SurfaceManager.LoadSurface(IO.Paths.StoryDataPath + "Backgrounds/" + file);
        }

        #endregion Methods
    }
}