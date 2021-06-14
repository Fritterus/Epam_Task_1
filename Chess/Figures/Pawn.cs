using System;
using System.Collections.Generic;
using Chess.Enum;

namespace Chess.Figures
{
    /// <summary>
    /// Class describing behavior pawn figure
    /// </summary>
    internal class Pawn : Figure
    {
        /// <summary>
        /// Constructor initializes color and type figure for pawn figure
        /// </summary>
        /// <param name="color">Figure color</param>
        public Pawn (Color color)
        {
            Color = color;
            Type = FigureType.Pawn;
        }

        /// <summary>
        /// Method discribing rule of move for pawn
        /// </summary>
        /// <param name="x1">Start X-coordinate </param>
        /// <param name="y1">Start Y-coordinate</param>
        /// <param name="x2">End X-coordinate</param>
        /// <param name="y2">End Y-coordinate</param>
        /// <returns>True, if coordinates correspond pawn's move, otherwise - false</returns>
        public override bool CanMoveTo(int x1, int y1, int x2, int y2)
        {
            if ((x2 - x1) == 1 && (y2 == y1) && Color == Color.Black)
            {
                return true;
            }
            if ((x2 - x1) == -1 && (y2 == y1) && Color == Color.White)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method discribing rule of move for pawn
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">End coordinate</param>
        /// <returns>True, if coordinates correspond pawn's move, otherwise - false</returns>
        public override bool CanMoveTo(Point point1, Point point2)
        {
            if ((point2.X - point1.X) == 1 && (point2.Y == point1.Y) && Color == Color.Black)
            {
                return true;
            }
            if ((point2.X - point1.X) == -1 && (point2.Y == point1.Y) && Color == Color.White)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method discribing rule of attack for pawn
        /// </summary>
        /// <param name="x1">Start X-coordinate </param>
        /// <param name="y1">Start Y-coordinate</param>
        /// <param name="x2">End X-coordinate</param>
        /// <param name="y2">End Y-coordinate</param>
        /// <returns>True, if pawn can attack, otherwise - false</returns>
        public bool CanAttack(int x1, int y1, int x2, int y2)
        {
            if (Color == Color.White && (x2 - x1) == -1 && Math.Abs(y2 - y1) == 1)
            {
                return true;
            }
            if (Color == Color.Black && (x2 - x1) == 1 && Math.Abs(y2 - y1) == 1)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Method discribing rule of attack for pawn
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">End coordinate</param>
        /// <returns>True, if pawn can attack, otherwise - false</returns>
        public bool CanAttack(Point point1, Point point2)
        {
            if (Color == Color.White && (point2.X - point1.X) == -1 && Math.Abs(point2.Y - point1.Y) == 1)
            {
                return true;
            }
            if (Color == Color.Black && (point2.X - point1.X) == 1 && Math.Abs(point2.Y - point1.Y) == 1)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Method for finding path of pawn
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
        /// Method for finding path of pawn
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
            return obj is Pawn pawn &&
                   base.Equals(obj) &&
                   Type == pawn.Type &&
                   Color == pawn.Color;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Type, Color);
        }
    }
}
