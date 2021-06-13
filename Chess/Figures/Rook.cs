using System;
using System.Collections.Generic;
using System.Text;
using Chess.Enum;

namespace Chess.Figures
{
    internal class Rook : Figure
    {
        public Rook(Color color)
        {
            Color = color;
            Type = FigureType.Rook;
        }

        public override bool CanMoveTo(int x1, int y1, int x2, int y2)
        {
            if (Math.Sign(x2 - x1) == 0 || Math.Sign(y2 - y1) == 0) return true;
            return false;
        }

        public override bool CanMoveTo(Point point1, Point point2)
        {
            if (Math.Sign(point2.X - point1.X) == 0 || Math.Sign(point2.Y - point1.Y) == 0) return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Rook rook &&
                   base.Equals(obj) &&
                   Type == rook.Type &&
                   Color == rook.Color;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Type, Color);
        }

        public override IEnumerable<Point> Way(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1 && y2 == y1)
            {
                while (x1 != x2)
                {
                    yield return new Point(x1, y1);
                    x1--;
                }
            }
            if (x2 > x1 && y2 == y1)
            {
                while (x1 != x2)
                {
                    yield return new Point(x1, y1);
                    x1++;
                }
            }
            if (x2 == x1 && y2 > y1)
            {
                while (y1 != y2)
                {
                    yield return new Point(x1, y1);
                    y1++;
                }
            }
            if (x2 == x1 && y2 < y1)
            {
                while (y1 != y2)
                {
                    yield return new Point(x1, y1);
                    y1--;
                }
            }
        }

        public override IEnumerable<Point> Way(Point point1, Point point2)
        {
            int x1 = point1.X;
            int y1 = point1.Y;

            if (point2.X < x1 && point2.Y == y1)
            {
                while (x1 != point2.X)
                {
                    yield return new Point(x1, y1);
                    x1--;
                }
            }
            if (point2.X > x1 && point2.Y == y1)
            {
                while (x1 != point2.X)
                {
                    yield return new Point(x1, y1);
                    x1++;
                }
            }
            if (point2.X == x1 && point2.Y > y1)
            {
                while (y1 != point2.Y)
                {
                    yield return new Point(x1, y1);
                    y1++;
                }
            }
            if (point2.X == x1 && point2.Y < y1)
            {
                while (y1 != point2.Y)
                {
                    yield return new Point(x1, y1);
                    y1--;
                }
            }
        }
    }
}

