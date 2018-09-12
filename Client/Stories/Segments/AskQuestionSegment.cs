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
    class AskQuestionSegment : ISegment
    {
        #region Fields

        private int segmentOnNo;
        private ListPair<string, string> parameters;
        private string question;
        private int segmentOnYes;
        private int mugshot;
        StoryState storyState;
        string[] options;

        #endregion Fields

        #region Constructors

        public AskQuestionSegment(string text, int speaker, int segmentOnYes, int segmentOnNo, string[] options)
        {
            Load(text, segmentOnYes, segmentOnNo, speaker, options);
        }

        public AskQuestionSegment()
        {
        }

        #endregion Constructors

        #region Properties

        public Enums.StoryAction Action
        {
            get { return Enums.StoryAction.AskQuestion; }
        }

        public int SegmentOnNo
        {
            get { return segmentOnNo; }
            set { segmentOnNo = value; }
        }

        public ListPair<string, string> Parameters
        {
            get { return parameters; }
        }

        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        public int SegmentOnYes
        {
            get { return segmentOnYes; }
            set { segmentOnYes = value; }
        }

        public int Mugshot
        {
            get { return mugshot; }
            set { mugshot = value; }
        }

        public bool UsesSpeechMenu
        {
            get { return false; }
        }

        #endregion Properties

        #region Methods

        public void Load(string question, int segmentOnYes, int segmentOnNo, int mugshot, string[] options)
        {
            this.question = question;
            this.segmentOnYes = segmentOnYes;
            this.segmentOnNo = segmentOnNo;
            this.mugshot = mugshot;
            this.options = options;
        }

        public void LoadFromSegmentData(ListPair<string, string> parameters)
        {
            this.parameters = parameters;
            //this code never gets reached
            //if (parameters.Count > 4) {
            //    string[] choices = new string[data[4].ToInt()];
            //    int n = 5;
            //    for (int i = 0; i < choices.Length; i++) {
            //        choices[i] = data[n];

            //        n += 1;
            //    }
            //    Load(parameters.GetValue("Question"), parameters.GetValue("SegmentOnYes").ToInt(-1), parameters.GetValue("SegmentOnNo").ToInt(-1), parameters.GetValue("Mugshot").ToInt(-1), choices);
            //} else {
            Load(parameters.GetValue("Question"), parameters.GetValue("SegmentOnYes").ToInt(-1), parameters.GetValue("SegmentOnNo").ToInt(-1), parameters.GetValue("Mugshot").ToInt(-1), new string[] { "Yes", "No" });
            //}
        }

        public void Process(StoryState state)
        {
            Menus.MenuSwitcher.ShowBlankMenu();
            Components.SpokenTextMenu textMenu;
            IMenu menuToFind = Windows.WindowSwitcher.GameWindow.MenuManager.FindMenu("story-spokenTextMenu");
            if (menuToFind != null)
            {
                textMenu = (Components.SpokenTextMenu)menuToFind;
            }
            else
            {
                textMenu = new Components.SpokenTextMenu("story-spokenTextMenu", Windows.WindowSwitcher.GameWindow.MapViewer.Size);
            }
            textMenu.DisplayText(StoryProcessor.ReplaceVariables(question), mugshot);
            Windows.WindowSwitcher.GameWindow.MenuManager.AddMenu(textMenu, true);

            Components.OptionSelectionMenu optionMenu = new Components.OptionSelectionMenu("story-optionSelectionMenu", Windows.WindowSwitcher.GameWindow.MapViewer.Size, options);
            optionMenu.OptionSelected += new Components.OptionSelectionMenu.OptionSelectedDelegate(optionMenu_OptionSelected);
            Windows.WindowSwitcher.GameWindow.MenuManager.AddMenu(optionMenu, true);

            Windows.WindowSwitcher.GameWindow.MenuManager.SetActiveMenu(optionMenu);
            Windows.WindowSwitcher.GameWindow.MenuManager.BlockInput = true;

            storyState = state;

            state.Pause();

            optionMenu.OptionSelected -= new Components.OptionSelectionMenu.OptionSelectedDelegate(optionMenu_OptionSelected);
            Windows.WindowSwitcher.GameWindow.MenuManager.RemoveMenu(optionMenu);

            //if (state.NextSegment == null || !state.NextSegment.UsesSpeechMenu) {
            Windows.WindowSwitcher.GameWindow.MenuManager.RemoveMenu(textMenu);
            //}
        }

        void optionMenu_OptionSelected(string option)
        {
            bool segmentSet = false;
            if (option == "Yes")
            {
                if (segmentOnYes > -1)
                {
                    storyState.CurrentSegment = segmentOnYes - 2;
                    segmentSet = true;
                }
            }
            else if (option == "No")
            {
                if (segmentOnNo > -1)
                {
                    storyState.CurrentSegment = segmentOnNo - 2;
                    segmentSet = true;
                }
            }
            if (!segmentSet)
            {
                Network.Messenger.SendPacket(PMDCP.Sockets.TcpPacket.CreatePacket("questionresult", option));
            }
            storyState.Unpause();
        }

        #endregion Methods
    }
}