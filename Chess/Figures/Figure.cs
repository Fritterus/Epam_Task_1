using System;
using System.Collections.Generic;
using System.Text;
using Chess.Enum;
using Chess.Interfaces;

namespace Chess.Figures
{

    abstract class Figure
    {
        public FigureType Type { get; protected set; }
        public Color Color { get; protected set; }

        public abstract bool CanMoveTo(int x1, int y1, int x2, int y2);
        public abstract bool CanMoveTo(Point point1, Point point2);
        public abstract IEnumerable<Point> Way(int x1, int y1, int x2, int y2);
        public abstract IEnumerable<Point> Way(Point point1, Point point2);
    }

}
