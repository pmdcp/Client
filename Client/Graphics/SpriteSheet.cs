﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using PMDCP.Core;

using SdlDotNet.Graphics;
using System.IO;
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
    #region Enumerations

    public enum FrameType
    {
        Idle = 0,
        Walk,
        Attack,
        AttackArm,
        AltAttack,
        SpAttack,
        SpAttackCharge,
        SpAttackShoot,
        Hurt,
        Sleep
    }

    #endregion Enumerations

    class FrameTypeHelper
    {
        public static bool IsFrameTypeDirectionless(FrameType frameType)
        {
            switch (frameType)
            {
                case FrameType.Sleep:
                    return true;
                default:
                    return false;
            }
        }
    }

    class FrameData
    {
        #region Fields

        int frameWidth;
        int frameHeight;


        Dictionary<FrameType, Dictionary<Enums.Direction, int>> frameCount;

        #endregion Fields

        #region Properties


        public int FrameWidth
        {
            get { return frameWidth; }
        }


        public int FrameHeight
        {
            get { return frameHeight; }
        }

        #endregion Properties

        public FrameData()
        {
            frameCount = new Dictionary<FrameType, Dictionary<Enums.Direction, int>>();
        }

        #region Methods

        public void SetFrameSize(int frameWidth, int frameHeight)
        {
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
        }

        public void SetFrameSize(int animWidth, int animHeight, int frames)
        {
            frameWidth = animWidth / frames;

            frameHeight = animHeight;
        }

        public void SetFrameCount(FrameType type, Enums.Direction dir, int count)
        {
            if (frameCount.ContainsKey(type) == false)
            {
                frameCount.Add(type, new Dictionary<Enums.Direction, int>());
            }
            if (frameCount[type].ContainsKey(dir) == false)
            {
                frameCount[type].Add(dir, count);
            }
            else
            {
                frameCount[type][dir] = count;
            }
        }

        public int GetFrameCount(FrameType type, Enums.Direction dir)
        {
            Dictionary<Enums.Direction, int> dirs = null;
            if (frameCount.TryGetValue(type, out dirs))
            {
                int value = 0;
                if (dirs.TryGetValue(dir, out value))
                {
                    return value;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        #endregion Methods
    }

    class SpriteSheet : ICacheable
    {
        #region Fields

        FrameData frameData;
        int num;
        Surface sheet;
        int sizeInBytes;
        string form;

        #endregion Fields

        #region Constructors

        public SpriteSheet(int num, string form)
        {
            this.num = num;
            this.form = form;

            frameData = new FrameData();
        }

        #endregion Constructors

        #region Properties

        public int BytesUsed
        {
            get { return sizeInBytes; }
        }

        public FrameData FrameData
        {
            get { return frameData; }
        }

        public int Num
        {
            get { return num; }
        }

        public string Form
        {
            get { return form; }
        }

        Dictionary<FrameType, Dictionary<Enums.Direction, Surface>> animations;

        #endregion Properties

        #region Methods

        public void LoadSpriteX(SpriteXLoader loader, string overrideForm)
        {
            frameData = new FrameData();
            animations = new Dictionary<FrameType, Dictionary<Enums.Direction, Surface>>();

            loader.Load(this, frameData, overrideForm);

            sizeInBytes = 5 * 1000;
        }

        public Rectangle GetFrameBounds(FrameType frameType, Enums.Direction direction, int frameNum)
        {
            Rectangle rec = new Rectangle();
            rec.X = frameNum * frameData.FrameWidth;
            rec.Y = 0;
            rec.Width = frameData.FrameWidth;
            rec.Height = frameData.FrameHeight;

            return rec;
        }

        public void LoadFromData(BinaryReader reader, int totalByteSize)
        {
            frameData = new FrameData();
            animations = new Dictionary<FrameType, Dictionary<Enums.Direction, Surface>>();

            foreach (FrameType frameType in Enum.GetValues(typeof(FrameType)))
            {
                if (FrameTypeHelper.IsFrameTypeDirectionless(frameType) == false)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Enums.Direction dir = GraphicsManager.GetAnimIntDir(i);
                        int frameCount = reader.ReadInt32();
                        frameData.SetFrameCount(frameType, dir, frameCount);
                        int size = reader.ReadInt32();
                        if (size > 0)
                        {
                            byte[] imgData = reader.ReadBytes(size);
                            using (MemoryStream stream = new MemoryStream(imgData))
                            {
                                Bitmap bitmap = (Bitmap)Image.FromStream(stream);
                                Surface sheetSurface = new Surface(bitmap);
                                sheetSurface.Transparent = true;

                                AddSheet(frameType, dir, sheetSurface);

                                frameData.SetFrameSize(sheetSurface.Width, sheetSurface.Height, frameCount);
                            }
                        }
                    }
                }
                else
                {
                    int frameCount = reader.ReadInt32();
                    frameData.SetFrameCount(frameType, Enums.Direction.Down, frameCount);
                    int size = reader.ReadInt32();
                    if (size > 0)
                    {
                        byte[] imgData = reader.ReadBytes(size);

                        using (MemoryStream stream = new MemoryStream(imgData))
                        {
                            Bitmap bitmap = (Bitmap)Image.FromStream(stream);
                            Surface sheetSurface = new Surface(bitmap);
                            sheetSurface.Transparent = true;

                            AddSheet(frameType, Enums.Direction.Down, sheetSurface);

                            frameData.SetFrameSize(sheetSurface.Width, sheetSurface.Height, frameCount);
                        }
                    }
                }
            }

            sizeInBytes = totalByteSize;
        }


        public Surface GetSheet(FrameType type, Enums.Direction dir)
        {
            if (FrameTypeHelper.IsFrameTypeDirectionless(type))
            {
                dir = Enums.Direction.Down;
            }
            return animations[type][dir];
        }

        public void AddSheet(FrameType type, Enums.Direction dir, Surface surface)
        {
            if (!animations.ContainsKey(type))
            {
                animations.Add(type, new Dictionary<Enums.Direction, Surface>());
            }
            if (animations[type].ContainsKey(dir) == false)
            {
                animations[type].Add(dir, surface);
            }
            else
            {
                animations[type][dir] = surface;
            }
        }

        #endregion Methods
    }
}