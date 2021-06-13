using System;
using System.Collections.Generic;
using System.Text;
using Chess.Enum;
using Chess.Interfaces;

namespace Chess.Figures
{

    internal abstract class Figure
    {
        public FigureType Type { get; protected set; }
        public Color Color { get; protected set; }

        public abstract bool CanMoveTo(int x1, int y1, int x2, int y2);
        public abstract bool CanMoveTo(Point point1, Point point2);

        public override bool Equals(object obj)
        {
            return obj is Figure figure &&
                   Type == figure.Type &&
                   Color == figure.Color;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Color);
        }

        public abstract IEnumerable<Point> Way(int x1, int y1, int x2, int y2);
        public abstract IEnumerable<Point> Way(Point point1, Point point2);

        public override string ToString()
        {
            return string.Format($"Figure Type: {Type} \n Figure Color: {Color}");
        }
    }

}
