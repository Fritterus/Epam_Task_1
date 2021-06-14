namespace Chess.Interfaces
{
    /// <summary>
    /// Interface describing chessboard
    /// </summary>
    interface IBoard
    {
        /// <summary>
        /// Method describing turn on the board
        /// </summary>
        /// <param name="x1">Start X-coordinate </param>
        /// <param name="y1">Start Y-coordinate</param>
        /// <param name="x2">End X-coordinate</param>
        /// <param name="y2">End Y-coordinate</param>
        public void Turn(int x1, int y1, int x2, int y2);

        /// <summary>
        /// Method describing turn on the board
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">End coordinate</param>
        public void Turn(Point point1, Point point2);
    }
}
