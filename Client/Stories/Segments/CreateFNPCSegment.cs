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
    class CreateFNPCSegment : ISegment
    {
        #region Fields

        string id;
        string parentMapID;
        StoryState storyState;
        int x;
        int y;
        int sprite;
        int form;
        Enums.Coloration shiny;
        Enums.Sex gender;
        ListPair<string, string> parameters;

        #endregion Fields

        #region Constructors

        public CreateFNPCSegment(string id, string parentMapID, int x, int y, int sprite, int form, Enums.Coloration shiny, Enums.Sex gender)
        {
            Load(id, parentMapID, x, y, sprite, form, shiny, gender);
        }

        public CreateFNPCSegment()
        {
        }

        #endregion Constructors

        #region Properties

        public Enums.StoryAction Action
        {
            get { return Enums.StoryAction.CreateFNPC; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public ListPair<string, string> Parameters
        {
            get { return parameters; }
        }

        public string ParentMapID
        {
            get { return parentMapID; }
            set { parentMapID = value; }
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

        public int Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public int Form
        {
            get { return form; }
            set { form = value; }
        }

        public Enums.Sex Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public Enums.Coloration Shiny
        {
            get { return shiny; }
            set { shiny = value; }
        }

        public bool UsesSpeechMenu
        {
            get { return false; }
        }

        #endregion Properties

        #region Methods

        public void Load(string id, string parentMapID, int x, int y, int sprite, int form, Enums.Coloration shiny, Enums.Sex gender)
        {
            this.id = id;
            this.parentMapID = parentMapID;
            this.x = x;
            this.y = y;
            this.sprite = sprite;
            this.form = form;
            this.shiny = shiny;
            this.gender = gender;

            if (this.parentMapID == "s-2")
            {
                this.parentMapID = "-2";
            }
        }

        public void LoadFromSegmentData(ListPair<string, string> parameters)
        {
            this.parameters = parameters;
            Load(parameters.GetValue("ID"), parameters.GetValue("ParentMapID"),
                parameters.GetValue("X").ToInt(), parameters.GetValue("Y").ToInt(),
                parameters.GetValue("Sprite").ToInt(), 0, Enums.Coloration.Normal, Enums.Sex.Genderless);
        }

        public void Process(StoryState state)
        {
            storyState = state;
            FNPCs.FNPC fnpc = new FNPCs.FNPC();
            fnpc.MapID = parentMapID;
            fnpc.X = x;
            fnpc.Y = y;
            fnpc.Sprite = sprite;
            fnpc.Form = form;
            fnpc.Shiny = shiny;
            fnpc.Sex = gender;
            fnpc.ID = id;

            state.FNPCs.Add(fnpc);
        }

        #endregion Methods
    }
}