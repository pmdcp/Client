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

namespace Client.Logic.Graphics
{
    class DrawingSupport
    {
        /// <summary>
        /// Gets the center point of two objects
        /// </summary>
        /// <param name="parentSize">The size of the parent object</param>
        /// <param name="childSize">The size of the child object</param>
        /// <returns>The center point of two objects</returns>
        public static Point GetCenter(Size parentSize, Size childSize) {
            return new Point((parentSize.Width / 2) - (childSize.Width / 2), (parentSize.Height / 2) - (childSize.Height / 2));
        }

        /// <summary>
        /// Gets the center X value of two objects
        /// </summary>
        /// <param name="parentWidth">The width of the parent object</param>
        /// <param name="childWidth">The width of the child object</param>
        /// <returns>The center X value of two objects</returns>
        public static int GetCenterX(int parentWidth, int childWidth) {
            return (parentWidth / 2) - (childWidth / 2);
        }

        /// <summary>
        /// Gets the center Y value of two objects
        /// </summary>
        /// <param name="parentHeight">The height of the parent object</param>
        /// <param name="childHeight">The height of the child object</param>
        /// <returns>The center Y value of two objects</returns>
        public static int GetCenterY(int parentHeight, int childHeight) {
            return (parentHeight / 2) - (childHeight / 2);
        }

        /// <summary>
        /// Checks if a point intersects with the specified rectangle
        /// </summary>
        /// <param name="pointToTest">The point to test</param>
        /// <param name="bounds">The rectangle used to determine if the point is inside</param>
        /// <returns>True if the point is inside the rectangle boundaries; otherwise, false</returns>
        public static bool PointInBounds(Point pointToTest, Rectangle bounds) {
            if (pointToTest.X >= bounds.X && pointToTest.Y >= bounds.Y && pointToTest.X - bounds.Location.X <= bounds.Width && pointToTest.Y - bounds.Location.Y <= bounds.Height) {
                return true;
            } else {
                return false;
            }
        }
    }
}
