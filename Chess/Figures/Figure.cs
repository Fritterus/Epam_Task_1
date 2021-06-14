using System;
using System.Collections.Generic;
using Chess.Enum;

namespace Chess.Figures
{
    /// <summary>
    /// Abstract class describing chess figure
    /// </summary>
    internal abstract class Figure
    {
        /// <summary>
        /// Property describing figure type
        /// </summary>
        public FigureType Type { get; protected set; }
        /// <summary>
        /// Property describing figure color
        /// </summary>
        public Color Color { get; protected set; }

        /// <summary>
        /// Abstract method discribing rule of move for chess figure
        /// </summary>
        /// <param name="x1">Start X-coordinate </param>
        /// <param name="y1">Start Y-coordinate</param>
        /// <param name="x2">End X-coordinate</param>
        /// <param name="y2">End Y-coordinate</param>
        /// <returns>True, if coordinates correspond chess figure's move, otherwise - false</returns>
        public abstract bool CanMoveTo(int x1, int y1, int x2, int y2);

        /// <summary>
        /// Abstract method discribing rule of move for chess figure
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">End coordinate</param>
        /// <returns>True, if coordinates correspond chess figure's move, otherwise - false</returns>
        public abstract bool CanMoveTo(Point point1, Point point2);

        public abstract IEnumerable<Point> Way(int x1, int y1, int x2, int y2);
        public abstract IEnumerable<Point> Way(Point point1, Point point2);

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

        public override string ToString()
        {
            return string.Format($"Figure Type: {Type} \n Figure Color: {Color}");
        }
    }

}
