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


namespace Client.Logic.Emotions
{
    class EmotionHelper
    {
        #region Fields

        private static int dataLoadPercent = 0;
        private static EmotionCollection mEmotions;

        #endregion Fields

        #region Properties

        public static int DataLoadPercent
        {
            get { return dataLoadPercent; }
        }

        public static EmotionCollection Emotions
        {
            get { return mEmotions; }
        }

        #endregion Properties

        #region Methods

        public static void InitEmotionCollection()
        {
            mEmotions = new EmotionCollection(MaxInfo.MaxEmoticons);
        }

        public static void LoadEmotionsFromPacket(string[] parse)
        {
            try
            {
                int n;
                n = 1;
                for (int i = 0; i < MaxInfo.MaxEmoticons; i++)
                {
                    dataLoadPercent = System.Math.Min(Logic.MathFunctions.CalculatePercent(i, MaxInfo.MaxEmoticons), 99);
                    mEmotions[i] = new Emotion();
                    mEmotions[i].Command = parse[n + 1];
                    mEmotions[i].Pic = parse[n + 2].ToInt();
                    n += 3;
                    ((Windows.winLoading)Windows.WindowSwitcher.FindWindow("winLoading")).UpdateLoadText("Recieving Data... " + DataManager.AverageLoadPercent().ToString() + "%");
                }
                dataLoadPercent = 100;
            }
            catch (Exception ex)
            {
                Exceptions.ExceptionHandler.OnException(ex);
            }
        }

        #endregion Methods
    }
}