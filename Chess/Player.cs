using System;
using System.Collections.Generic;
using System.Text;
using Chess.Enum;
using Chess.Interfaces;

namespace Chess
{
    internal class Player : IPlayer
    {
        private Color _color;

        public Color Color => _color;

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
