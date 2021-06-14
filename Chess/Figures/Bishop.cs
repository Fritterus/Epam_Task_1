using System;
using System.Collections.Generic;
using Chess.Enum;

namespace Chess.Figures
{
    /// <summary>
    /// Class describing behavior bishop figure
    /// </summary>
    internal class Bishop : Figure
    {
        /// <summary>
        /// Constructor initializes color and type figure for bishop figure
        /// </summary>
        /// <param name="color">Figure color</param>
        public Bishop(Color color)
        {
            Color = color;
            Type = FigureType.Bishop;
        }

        /// <summary>
        /// Method discribing rule of move for bishop
        /// </summary>
        /// <param name="x1">Start X-coordinate </param>
        /// <param name="y1">Start Y-coordinate</param>
        /// <param name="x2">End X-coordinate</param>
        /// <param name="y2">End Y-coordinate</param>
        /// <returns>True, if coordinates correspond bishop's move, otherwise - false</returns>
        public override bool CanMoveTo(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x2 - x1) == Math.Abs(y2 - y1)) return true;
            return false;
        }

        /// <summary>
        /// Method discribing rule of move for bishop
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">End coordinate</param>
        /// <returns>True, if coordinates correspond bishop's move, otherwise - false</returns>
        public override bool CanMoveTo(Point point1, Point point2)
        {
            if (Math.Abs(point2.X - point1.X) == Math.Abs(point2.Y - point1.Y)) return true;
            return false;
        }

        /// <summary>
        /// Method for finding path of bishop
        /// </summary>
        /// <param name="x1">Start X-coordinate </param>
        /// <param name="y1">Start Y-coordinate</param>
        /// <param name="x2">End X-coordinate</param>
        /// <param name="y2">End Y-coordinate</param>
        /// <returns>Collection of object of type Point(x, y)</returns>
        public override IEnumerable<Point> Way(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1 && y2 > y1)
            {
                while (x1 != x2 && y1 != y2)
                {
                    yield return new Point(x1, y1);
                    x1--;
                    y1++;
                }
            }
            if (x2 < x1 && y2 < y1)
            {
                while (x1 != x2 && y1 != y2)
                {
                    yield return new Point(x1, y1);
                    x1--;
                    y1--;
                }
            }
            if (x2 > x1 && y2 < y1)
            {
                while (x1 != x2 && y1 != y2)
                {
                    yield return new Point(x1, y1);
                    x1++;
                    y1--;
                }
            }
            if (x2 > x1 && y2 > y1)
            {
                while (x1 != x2 && y1 != y2)
                {
                    yield return new Point(x1, y1);
                    x1++;
                    y1++;
                }
            }

        }

        /// <summary>
        /// Method for finding path of bishop
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">End coordinate</param>
        /// <returns>Collection of object of type Point(x, y)</returns>
        public override IEnumerable<Point> Way(Point point1, Point point2)
        {
            int x1 = point1.X;
            int y1 = point1.Y;

            if (point2.X < x1 && point2.Y > y1)
            {
                while (x1 != point2.X && y1 != point2.Y)
                {
                    yield return new Point(x1, y1);
                    x1--;
                    y1++;
                }
            }
            if (point2.X < x1 && point2.Y < y1)
            {
                while (x1 != point2.X && y1 != point2.Y)
                {
                    yield return new Point(x1, y1);
                    x1--;
                    y1--;
                }
            }
            if (point2.X > x1 && point2.Y < y1)
            {
                while (x1 != point2.X && y1 != point2.Y)
                {
                    yield return new Point(x1, y1);
                    x1++;
                    y1--;
                }
            }
            if (point2.X > x1 && point2.Y > y1)
            {
                while (x1 != point2.X && y1 != point2.Y)
                {
                    yield return new Point(x1, y1);
                    x1++;
                    y1++;
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Bishop bishop &&
                   Type == bishop.Type &&
                   Color == bishop.Color;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Color);
        }    
    }
}
