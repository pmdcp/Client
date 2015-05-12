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
using Client.Logic.Graphics.Renderers.Sprites;
using System.Drawing;

namespace Client.Logic.Players
{
    class PlayerPet : ISprite
    {
        public Logic.Graphics.SpriteSheet SpriteSheet {
            get;
            set;
        }

        public int Slot { get; set; }

        public int IdleTimer { get; set; }
        public int IdleFrame { get; set; }
        public int LastWalkTime { get; set; }
        public int WalkingFrame { get; set; }

        public int Sprite {
            get;
            set;
        }

        public int Form { get; set; }
        public Enums.Coloration Shiny { get; set; }
        public Enums.Sex Sex { get; set; }

        public Enums.Direction Direction {
            get;
            set;
        }

        public bool Attacking {
            get;
            set;
        }

        public System.Drawing.Point Offset {
            get;
            set;
        }

        public System.Drawing.Point Location {
            get;
            set;
        }

        public int AttackTimer {
            get;
            set;
        }

        public int TotalAttackTime { get; set; }

        public int X {
            get { return Location.X; }
            set { Location = new Point(value, Location.Y); }
        }

        public int Y {
            get { return Location.Y; }
            set { Location = new Point(Location.X, value); }
        }

        public Enums.MovementSpeed MovementSpeed {
            get;
            set;
        }

        public Enums.StatusAilment StatusAilment {
            get;
            set;
        }

        public List<int> VolatileStatus
        {
            get;
            set;
        }

        public bool Leaving { get; set; }

        public bool ScreenActive { get; set; }

        public int SleepTimer {
            get;
            set;
        }

        public int SleepFrame {
            get;
            set;
        }

        public IPlayer Player {
            get;
            set;
        }

        public int LastPlayerX { get; set; }
        public int LastPlayerY { get; set; }

        public Graphics.Renderers.Sprites.SpeechBubble CurrentSpeech { get; set; }

        public Graphics.Renderers.Sprites.Emoticon CurrentEmote { get; set; }

        public PlayerPet(int slot, IPlayer player) {
            this.Slot = slot;
            this.Player = player;

            LastPlayerX = player.X;
            LastPlayerY = player.Y;

            VolatileStatus = new List<int>();
        }

        public void Update() {
            if (Player.X != LastPlayerX) {
                MovementSpeed = Player.MovementSpeed;
                if (GetHorizDistanceFromPlayer() >= Slot) {
                    X = GetXBehindPlayer(Slot);
                    LastPlayerX = Player.X;
                }
            }
            if (Player.Y != LastPlayerY) {
                MovementSpeed = Player.MovementSpeed;
                if (GetVertDistanceFromPlayer() >= Slot) {
                    Y = GetYBehindPlayer(Slot);
                    LastPlayerY = Player.Y;
                }
            }
            if (Direction != Player.Direction) {
                Offset = new Point(0, 0);
                Direction = Player.Direction;
            }
        }

        public int GetHorizDistanceFromPlayer() {
            return Player.X - X;
        }

        public int GetXBehindPlayer(int distance) {
            switch (Player.Direction) {
                case Enums.Direction.Left:
                    Offset = new Point(Constants.TILE_WIDTH, Offset.Y);
                    return Player.X + distance;
                case Enums.Direction.Right:
                    Offset = new Point(Constants.TILE_WIDTH * -1, Offset.Y);
                    return Player.X - distance;
                case Enums.Direction.Up:
                case Enums.Direction.Down:
                    return Player.X;
                default:
                    return Player.X;
            }
        }

        public int GetVertDistanceFromPlayer() {
            return System.Math.Abs(Player.Y - Y);
        }

        public int GetYBehindPlayer(int distance) {
            switch (Player.Direction) {
                case Enums.Direction.Down:
                    Offset = new Point(Offset.X, Constants.TILE_HEIGHT);
                    return Player.Y - distance;
                case Enums.Direction.Up:
                      Offset = new Point(Offset.X, Constants.TILE_HEIGHT * -1);
                    return Player.Y + distance;
                case Enums.Direction.Right:
                case Enums.Direction.Left:
                    return Player.Y;
                default:
                    return Player.Y;
            }
        }

    }
}
