using System;
using System.Collections.Generic;
using System.Text;
using Chess.Figures;

namespace Chess
{
    internal class Space
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Space(int x, int y)
        {
            X = x;
            Y = y;
        }


        public bool CanFigureMoveTo (Point point)
        {
            return Figure.CanMoveTo(X, Y, point.X, point.Y);
        }

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

        public Figure Figure { get; set; }

        public override string ToString()
        {
            return string.Format($"Coordinate X = {X} \n Coordinate Y = {Y}");
        }
    }
}
