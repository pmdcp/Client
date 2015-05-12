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

namespace Client.Logic.Stories.Segments
{
    class SegmentDataSplitter
    {
        public const char SEPERATOR_CHAR = '|';

        public static string[] SplitSegmentData(string segmentData) {
            if (segmentData.Contains(SEPERATOR_CHAR.ToString())) {
                List<string> parsed = new List<string>();
                bool startNewLine = true;
                int currentLine = -1;
                bool isInQuotes = false;
                for (int i = 0; i < segmentData.Length; i++) {
                    if (startNewLine) {
                        parsed.Add("");
                        currentLine++;
                        startNewLine = false;
                    }
                    char curChar = segmentData[i];
                    if (curChar == SEPERATOR_CHAR && isInQuotes == false) {
                        startNewLine = true;
                    } else if (curChar == '"') {
                        isInQuotes = !isInQuotes;
                    } else {
                        parsed[currentLine] += curChar;
                    }
                }
                return parsed.ToArray();
            } else {
                return new string[] { segmentData };
            }
        }
    }
}
