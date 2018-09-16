﻿// This file is part of Mystery Dungeon eXtended.

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

namespace Client.Logic.Algorithms.Pathfinder
{
    class AStarPathfinder : IPathfinder
    {
        Point[] mMovements;
        PathfinderSquare[,] mSquares;

        int maxX;
        int maxY;

        Maps.Map map;

        public AStarPathfinder(Maps.Map map)
        {
            this.map = map;

            maxX = map.MaxX;
            maxY = map.MaxY;

            InitMovements();
            InitSquares();
        }

        private void InitMovements()
        {
            mMovements = new Point[]
            {
                new Point(0, -1),
                new Point(1, 0),
                new Point(0, 1),
                new Point(-1, 0)
            };
        }

        private void InitSquares()
        {
            mSquares = new PathfinderSquare[maxX + 1, maxY + 1];

            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    mSquares[x, y] = new PathfinderSquare();
                    mSquares[x, y].TileType = map.Tile[x, y].Type;
                    mSquares[x, y].DistanceSteps = 10000;
                    mSquares[x, y].IsPath = false;
                }
            }
        }

        public PathfinderResult FindPath(int startX, int startY, int endX, int endY)
        {
            if (ValidCoordinates(startX, startY) == false || ValidCoordinates(endX, endY) == false)
            {
                return new PathfinderResult(new List<Enums.Direction>(), false);
            }

            int tempStartX = startX;
            int tempStartY = startY;

            startX = endX;
            startY = endY;
            endX = tempStartX;
            endY = tempStartY;

            string findPathID = Globals.Tick.ToString();

            mSquares[startX, startY].DistanceSteps = 0;
            mSquares[startX, startY].SessionID = findPathID;


            while (true)
            {
                bool madeProgress = false;

                foreach (Point mainPoint in AllSquares())
                {
                    int x = mainPoint.X;
                    int y = mainPoint.Y;
                    if (mSquares[x, y].SessionID != findPathID)
                    {
                        mSquares[x, y].DistanceSteps = 10000;
                        mSquares[x, y].IsPath = false;
                        mSquares[x, y].SessionID = findPathID;
                    }
                    if (IsSquareOpen(x, y))
                    {
                        int passHere = mSquares[x, y].DistanceSteps;

                        foreach (Point movePoint in ValidMoves(x, y))
                        {
                            int newX = movePoint.X;
                            int newY = movePoint.Y;
                            int newPass = passHere + 1;

                            if (mSquares[newX, newY].DistanceSteps > newPass)
                            {
                                mSquares[newX, newY].DistanceSteps = newPass;
                                madeProgress = true;
                            }
                        }
                    }
                }
                if (!madeProgress)
                {
                    break;
                }
            }

            // Create the actual path
            int pointX = endX;
            int pointY = endY;

            int lastPointX = endX;
            int lastPointY = endY;

            List<Enums.Direction> pathList = new List<Enums.Direction>();
            while (true)
            {
                Point lowestPoint = Point.Empty;
                int lowest = 10000;

                foreach (Point movePoint in ValidMoves(pointX, pointY))
                {
                    int count = mSquares[movePoint.X, movePoint.Y].DistanceSteps;
                    if (count < lowest)
                    {
                        lowest = count;
                        lowestPoint.X = movePoint.X;
                        lowestPoint.Y = movePoint.Y;
                    }
                }
                if (lowest != 10000)
                {
                    // Mark the square as part of the path if it is the lowest
                    // number. Set the current position as the square with
                    // that number of steps.
                    mSquares[lowestPoint.X, lowestPoint.Y].IsPath = true;
                    pointX = lowestPoint.X;
                    pointY = lowestPoint.Y;
                    if (lastPointX > pointX)
                    {
                        pathList.Add(Enums.Direction.Left);
                    }
                    else if (lastPointX < pointX)
                    {
                        pathList.Add(Enums.Direction.Right);
                    }
                    else if (lastPointY > pointY)
                    {
                        pathList.Add(Enums.Direction.Up);
                    }
                    else if (lastPointY < pointY)
                    {
                        pathList.Add(Enums.Direction.Down);
                    }
                    lastPointX = pointX;
                    lastPointY = pointY;
                }
                else
                {
                    break;
                }
                if (pointX == startX && pointY == startY)
                {
                    // We went from monster to hero, so we're finished.
                    break;
                }
            }
            if (pathList.Count > 0)
            {
                //pathList.Reverse();
                return new PathfinderResult(pathList, true);
            }
            else
            {
                return new PathfinderResult(pathList, false);
            }
        }

        private bool IsSquareOpen(int x, int y)
        {
            if (GameProcessor.IsBlocked(map, x, y))
            {
                return false;
            }
            else
            {
                return true;
            }
            // First check the tile types
            switch (mSquares[x, y].TileType)
            {
                case Enums.TileType.Walkable:
                case Enums.TileType.Item:
                    // Do nothing since it's walkable
                    break;
                default:
                    return false;
            }
            /// Check other npcs on the map
            //for (int i = 0; i < Globals.MAX_MAP_NPCS; i++) {
            //    if (mMap.ActiveNpc[i].X == x && mMap.ActiveNpc[i].Y == y) {
            //        return false;
            //    }
            //}
            ///// Check for players
            //for (int i = 0; i < Program.ClassMan.mPlayers.mMaxPlayers; i++) {
            //    if (Program.ClassMan.mTcp.IsPlaying(i) && Program.ClassMan.mPlayers[i].mMap == mMapNum
            //        && Program.ClassMan.mPlayers[i].mX == x && Program.ClassMan.mPlayers[i].mY == y) {
            //        return false;
            //    }
            //}
            return true;
        }

        private IEnumerable<Point> ValidMoves(int x, int y)
        {
            // Return each valid square we can move to.
            foreach (Point movePoint in mMovements)
            {
                int newX = x + movePoint.X;
                int newY = y + movePoint.Y;

                if (ValidCoordinates(newX, newY) &&
                    IsSquareOpen(newX, newY))
                {
                    yield return new Point(newX, newY);
                }
            }
        }

        private bool ValidCoordinates(int x, int y)
        {
            // Our coordinates are constrained between 0 and 14.
            if (x < 0)
            {
                return false;
            }
            if (y < 0)
            {
                return false;
            }
            if (x > maxX)
            {
                return false;
            }
            if (y > maxY)
            {
                return false;
            }
            return true;
        }

        private IEnumerable<Point> AllSquares()
        {
            // Return every point on the board in order.
            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    yield return new Point(x, y);
                }
            }
        }
    }
}
