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
using System.Drawing;

namespace Client.Logic.Graphics.Renderers.Sprites
{
    interface ISprite
    {
        //Enums.Size Size { get; set; }
        int Sprite { get; set; }
        int Form { get; set; }
        Enums.Sex Sex { get; set; }
        Enums.Coloration Shiny { get; set; }
        Enums.Direction Direction { get; set; }
        bool Attacking { get; set; }
        Point Offset { get; set; }
        Point Location { get; set; }
        int AttackTimer { get; set; }
        int TotalAttackTime { get; set; }
        int X { get; set; }
        int Y { get; set; }
        Enums.MovementSpeed MovementSpeed { get; set; }
        int LastWalkTime { get; set; }
        int WalkingFrame { get; set; }
        //bool Confused { get; set; }
        Enums.StatusAilment StatusAilment { get; set; }
        List<int> VolatileStatus { get; set; }
        int SleepTimer { get; set; }
        int SleepFrame { get; set; }
        bool Leaving { get; set; }
        bool ScreenActive { get; set; }



        int IdleTimer { get; set; }
        int IdleFrame { get; set; }

        SpriteSheet SpriteSheet { get; set; }

        SpeechBubble CurrentSpeech { get; set; }

        Emoticon CurrentEmote { get; set; }

        //int WalkAnimationFrame { get; set; }
        //int WalkAnimationTimer { get; set; }
        //int AttackAnimationFrame { get; set; }
        //int AttackAnimationTimer { get; set; }
    }
}
