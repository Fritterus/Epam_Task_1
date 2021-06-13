using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    internal struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point (int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return string.Format($"Coordinate X = {X} \n Coordinate Y = {Y}");
        }
    }
}
