using System;

namespace Chess
{
    /// <summary>
    /// Struct describing coordinates
    /// </summary>
    internal struct Point
    {
        /// <summary>
        /// Property X-coordinate
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Property Y-coordinate
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Constructor initializes coordinates x and y
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
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
