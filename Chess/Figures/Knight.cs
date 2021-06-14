using System;
using System.Collections.Generic;
using Chess.Enum;

namespace Chess.Figures
{
    /// <summary>
    /// Class describing behavior knight figure
    /// </summary>
    internal class Knight : Figure
    {
        /// <summary>
        /// Constructor initializes color and type figure for knight figure
        /// </summary>
        /// <param name="color">Figure color</param>
        public Knight(Color color)
        {
            Color = color;
            Type = FigureType.Knight;
        }

        /// <summary>
        /// Method discribing rule of move for knight
        /// </summary>
        /// <param name="x1">Start X-coordinate </param>
        /// <param name="y1">Start Y-coordinate</param>
        /// <param name="x2">End X-coordinate</param>
        /// <param name="y2">End Y-coordinate</param>
        /// <returns>True, if coordinates correspond knight's move, otherwise - false</returns>
        public override bool CanMoveTo(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x2 - x1) == 2 && Math.Abs(y2 - y1) == 1) return true;
            if (Math.Abs(x2 - x1) == 1 && Math.Abs(y2 - y1) == 2) return true;
            return false;
        }

        /// <summary>
        /// Method discribing rule of move for knight
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">End coordinate</param>
        /// <returns>True, if coordinates correspond knight's move, otherwise - false</returns>
        public override bool CanMoveTo(Point point1, Point point2)
        {
            if (Math.Abs(point2.X - point1.X) == 2 && Math.Abs(point2.Y - point1.Y) == 1) return true;
            if (Math.Abs(point2.X - point1.X) == 1 && Math.Abs(point2.Y - point1.Y) == 2) return true;
            return false;
        }

        /// <summary>
        /// Method for finding path of knight
        /// </summary>
        /// <param name="x1">Start X-coordinate </param>
        /// <param name="y1">Start Y-coordinate</param>
        /// <param name="x2">End X-coordinate</param>
        /// <param name="y2">End Y-coordinate</param>
        /// <returns>Collection of object of type Point(x, y)</returns>
        public override IEnumerable<Point> Way(int x1, int y1, int x2, int y2)
        {

            yield return new Point(x1, y1);
            yield return new Point(x2, y2);
        }

        /// <summary>
        /// Method for finding path of knight
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">End coordinate</param>
        /// <returns>Collection of object of type Point(x, y)</returns>
        public override IEnumerable<Point> Way(Point point1, Point point2)
        {
            yield return new Point(point1.X, point1.Y);
            yield return new Point(point2.X, point2.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is Knight knight &&
                   base.Equals(obj) &&
                   Type == knight.Type &&
                   Color == knight.Color;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Type, Color);
        }
    }
}
