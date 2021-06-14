using System;
using System.Collections.Generic;
using Chess.Figures;

namespace Chess
{
    /// <summary>
    /// Class describing chessboard space(square)
    /// </summary>
    internal class Space
    {
        /// <summary>
        /// Property X-coordinate for chessboard space(square)
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Property Y-coordinate for chessboard space(square)
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Constructor initializes coordinates x and y for chessboard space
        /// </summary>
        /// <param name="x">x-coordinate chessboard space</param>
        /// <param name="y">y-coordinate chessboard space</param>
        public Space(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Property figure
        /// </summary>
        public Figure Figure { get; set; }

        /// <summary>
        /// Method discribing rule of move for current figure 
        /// </summary>
        /// <param name="point">Target coordinate</param>
        /// <returns>True, if current figure can move on target coordinate, otherwise - false</returns>
        public bool CanFigureMoveTo (Point point)
        {
            return Figure.CanMoveTo(X, Y, point.X, point.Y);
        }

        /// <summary>
        /// Method for finding path of current figure
        /// </summary>
        /// <param name="point">Target coordinate</param>
        /// <returns>Collection of object of type Point(x, y)</returns>
        public IEnumerable<Point> GetFigureWay (Point point)
        {
            return Figure.Way(X, Y, point.X, point.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is Space space &&
                   X == space.X &&
                   Y == space.Y &&
                   EqualityComparer<Figure>.Default.Equals(Figure, space.Figure);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Figure);
        }

        public override string ToString()
        {
            return string.Format($"Coordinate X = {X} \n Coordinate Y = {Y}");
        }
    }
}
