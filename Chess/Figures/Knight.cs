using System;
using System.Collections.Generic;
using Chess.Enum;

namespace Chess.Figures
{
    internal class Knight : Figure
    {

        public Knight(Color color)
        {
            Color = color;
            Type = FigureType.Knight;
        }

        public Knight(Figure figure)
        {
            Color = figure.Color;
            Type = FigureType.Knight;
        }

        public Knight(Point point, Color color)
        {
            //X = point.X;
            //Y = point.Y;
            Color = color;
        }
        public override bool CanMoveTo(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x2 - x1) == 2 && Math.Abs(y2 - y1) == 1) return true;
            if (Math.Abs(x2 - x1) == 1 && Math.Abs(y2 - y1) == 2) return true;
            return false;
        }

        public override bool CanMoveTo(Point point1, Point point2)
        {
            if (Math.Abs(point2.X - point1.X) == 2 && Math.Abs(point2.Y - point1.Y) == 1) return true;
            if (Math.Abs(point2.X - point1.X) == 1 && Math.Abs(point2.Y - point1.Y) == 2) return true;
            return false;
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

        public override IEnumerable<Point> Way(int x1, int y1, int x2, int y2)
        {

            yield return new Point(x1, y1);
            yield return new Point(x2, y2);
        }

        public override IEnumerable<Point> Way(Point point1, Point point2)
        {
            yield return new Point(point1.X, point1.Y);
            yield return new Point(point2.X, point2.Y);
        }
    }
}
