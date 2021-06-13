using System;
using System.Collections.Generic;
using System.Text;
using Chess.Enum;

namespace Chess.Figures
{
    internal class King : Figure
    {
        public King(Color color)
        {
            Color = color;
            Type = FigureType.King;
        }

        public override bool CanMoveTo(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x2 - x1) <= 1 && Math.Abs(y2 - y1) <= 1) return true;
            return false;
        }

        public override bool CanMoveTo(Point point1, Point point2)
        {
            if (Math.Abs(point2.X - point1.X) <= 1 && Math.Abs(point2.Y - point1.Y) <= 1) return true;
            return false;
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
