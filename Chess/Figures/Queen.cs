using System.Collections.Generic;
using Chess.Enum;

namespace Chess.Figures
{
    internal class Queen : Figure
    {
        private readonly Bishop _bishop;
        private readonly Rook _rook;
        public Queen(Color color)
        {
            Color = color;
            Type = FigureType.Queen;
            _bishop = new Bishop(Color);
            _rook = new Rook(Color);
        }

        public override bool CanMoveTo(int x1, int y1, int x2, int y2)
        {
            return _bishop.CanMoveTo(x1, y1, x2, y2) || _rook.CanMoveTo(x1, y1, x2, y2);
        }

        public override bool CanMoveTo(Point point1, Point point2)
        {
            return _bishop.CanMoveTo(point1.X, point1.Y, point2.X, point2.Y) || _rook.CanMoveTo(point1.X, point1.Y, point2.X, point2.Y);
        }

        public override IEnumerable<Point> Way(int x1, int y1, int x2, int y2)
        {
            var points = new List<Point>();
            points.AddRange(_bishop.Way(x1, y1, x2, y2));
            points.AddRange(_rook.Way(x1, y1, x2, y2));
            return points;
        }

        public override IEnumerable<Point> Way(Point point1, Point point2)
        {
            var points = new List<Point>();
            points.AddRange(_bishop.Way(point1.X, point1.Y, point2.X, point2.Y));
            points.AddRange(_rook.Way(point1.X, point1.Y, point2.X, point2.Y));
            return points;
        }

    }
}
