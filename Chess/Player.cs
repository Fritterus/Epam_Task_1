using System;
using Chess.Enum;
using Chess.Interfaces;

namespace Chess
{
    /// <summary>
    /// Class describing player
    /// </summary>
    internal class Player : IPlayer
    {
        /// <summary>
        /// Private field color
        /// </summary>
        private Color _color;

        /// <summary>
        /// Property player color
        /// </summary>
        public Color Color => _color;

        /// <summary>
        /// Constructor initializes player color
        /// </summary>
        /// <param name="color">Player color</param>
        public Player (Color color)
        {
            _color = color;
        }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   _color == player._color &&
                   Color == player.Color;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_color, Color);
        }

        public override string ToString()
        {
            return string.Format($"Player Color: {Color}");
        }
    }
}
