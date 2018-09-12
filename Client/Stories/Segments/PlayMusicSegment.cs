using System;
using System.Collections.Generic;
using System.Text;

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
    class PlayMusicSegment : ISegment
    {
        #region Fields

        bool honorSettings;
        bool loop;
        StoryState storyState;
        string file;
        ListPair<string, string> parameters;

        #endregion Fields

        #region Constructors

        public PlayMusicSegment(string file, bool honorSettings, bool loop)
        {
            Load(file, honorSettings, loop);
        }

        public PlayMusicSegment()
        {
        }

        #endregion Constructors

        #region Properties

        public Enums.StoryAction Action
        {
            get { return Enums.StoryAction.PlayMusic; }
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

        public bool HonorSettings
        {
            get { return honorSettings; }
            set { honorSettings = value; }
        }

        public bool Loop
        {
            get { return loop; }
            set { loop = value; }
        }

        public bool UsesSpeechMenu
        {
            get { return false; }
        }

        #endregion Properties

        #region Methods

        public void Load(string file, bool honorSettings, bool loop)
        {
            this.file = file;
            this.honorSettings = honorSettings;
            this.loop = loop;
        }

        public void LoadFromSegmentData(ListPair<string, string> parameters)
        {
            this.parameters = parameters;
            Load(parameters.GetValue("File"), parameters.GetValue("HonorSettings").ToBool(), parameters.GetValue("Loop").ToBool());
        }

        public void Process(StoryState state)
        {
            storyState = state;
            string fileToPlay = null;
            if (file == "%mapmusic%")
            {
                fileToPlay = Maps.MapHelper.ActiveMap.Music;
            }
            else
            {
                fileToPlay = file;
            }
            if (!string.IsNullOrEmpty(fileToPlay))
            {
                Music.Music.AudioPlayer.PlayMusic(fileToPlay, loop ? -1 : 1, !honorSettings, true);
            }
        }

        #endregion Methods
    }
}