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

namespace Client.Logic.Algorithms.Pathfinder
{
    class PathfinderResult
    {
        private List<Enums.Direction> path;
        private int tileCount;
        private bool isPath;

        public List<Enums.Direction> Path
        {
            get { return path; }
        }

        public int TileCount
        {
            get { return tileCount; }
        }

        public bool IsPath
        {
            get { return isPath; }
        }

        int currentItem = 0;

        public Enums.Direction GetNextItem()
        {
            currentItem++;
            return path[currentItem - 1];
        }

        internal PathfinderResult(List<Enums.Direction> path, bool isPath)
        {
            this.path = path;
            tileCount = path.Count;
            this.isPath = isPath;
        }
    }
}
