using Chess.Enum;

namespace Chess.Interfaces
{
    /// <summary>
    /// Interface describing player
    /// </summary>
    interface IPlayer
    {
        /// <summary>
        /// Property describing player color
        /// </summary>
        public Color Color { get; } 
    }
}
