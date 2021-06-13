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
    }
}
