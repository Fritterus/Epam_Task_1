using System;
using System.Collections.Generic;
using Chess.Enum;

namespace Chess.Figures
{
    /// <summary>
    /// Class describing behavior queen figure
    /// </summary>
    internal class Queen : Figure
    {
        private readonly Bishop _bishop;
        private readonly Rook _rook;

        /// <summary>
        /// Constructor initializes color and type figure for queen figure
        /// </summary>
        /// <param name="color">Figure color</param>
        public Queen(Color color)
        {
            Color = color;
            Type = FigureType.Queen;
            _bishop = new Bishop(Color);
            _rook = new Rook(Color);
        }

        /// <summary>
        /// Method discribing rule of move for queen
        /// </summary>
        /// <param name="x1">Start X-coordinate </param>
        /// <param name="y1">Start Y-coordinate</param>
        /// <param name="x2">End X-coordinate</param>
        /// <param name="y2">End Y-coordinate</param>
        /// <returns>True, if coordinates correspond queen's move, otherwise - false</returns>
        public override bool CanMoveTo(int x1, int y1, int x2, int y2)
        {
            return _bishop.CanMoveTo(x1, y1, x2, y2) || _rook.CanMoveTo(x1, y1, x2, y2);
        }

        /// <summary>
        /// Method discribing rule of move for queen
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">End coordinate</param>
        /// <returns>True, if coordinates correspond queen's move, otherwise - false</returns>
        public override bool CanMoveTo(Point point1, Point point2)
        {
            return _bishop.CanMoveTo(point1.X, point1.Y, point2.X, point2.Y) || _rook.CanMoveTo(point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Method for finding path of queen
        /// </summary>
        /// <param name="x1">Start X-coordinate </param>
        /// <param name="y1">Start Y-coordinate</param>
        /// <param name="x2">End X-coordinate</param>
        /// <param name="y2">End Y-coordinate</param>
        /// <returns>Collection of object of type Point(x, y)</returns>
        public override IEnumerable<Point> Way(int x1, int y1, int x2, int y2)
        {
            var points = new List<Point>();
            points.AddRange(_bishop.Way(x1, y1, x2, y2));
            points.AddRange(_rook.Way(x1, y1, x2, y2));
            return points;
        }

        /// <summary>
        /// Method for finding path of queen
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">End coordinate</param>
        /// <returns>Collection of object of type Point(x, y)</returns>
        public override IEnumerable<Point> Way(Point point1, Point point2)
        {
            var points = new List<Point>();
            points.AddRange(_bishop.Way(point1.X, point1.Y, point2.X, point2.Y));
            points.AddRange(_rook.Way(point1.X, point1.Y, point2.X, point2.Y));
            return points;
        }

        public override bool Equals(object obj)
        {
            return obj is Queen queen &&
                   base.Equals(obj) &&
                   Type == queen.Type &&
                   Color == queen.Color &&
                   EqualityComparer<Bishop>.Default.Equals(_bishop, queen._bishop) &&
                   EqualityComparer<Rook>.Default.Equals(_rook, queen._rook);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Type, Color, _bishop, _rook);
        }

    }
}
