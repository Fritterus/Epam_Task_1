using System;
using System.Collections.Generic;
using System.Text;
using Chess.Enum;

namespace Chess.Figures
{
    internal class Bishop : Figure
    {
        public Bishop(Color color)
        {
            Color = color;
            Type = FigureType.Bishop;
        }

        public override bool CanMoveTo(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x2 - x1) == Math.Abs(y2 - y1)) return true;
            return false;
        }

        public override bool CanMoveTo(Point point1, Point point2)
        {
            if (Math.Abs(point2.X - point1.X) == Math.Abs(point2.Y - point1.Y)) return true;
            return false;
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
    }
}
