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

        public Figure Figure { get; set; }
        
    }
}
