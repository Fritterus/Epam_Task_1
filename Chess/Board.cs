using System;
using Chess.Enum;
using Chess.Figures;
using Chess.Interfaces;
using System.Linq;

namespace Chess
{
    /// <summary>
    /// Class describing chessboard and chess game
    /// </summary>
    internal class ClassicBoard : IBoard
    {
        private const int _boardSize = 8; 
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private IPlayer _currentPlayer;

        public Space[,] Spaces { get; }

        public ClassicBoard(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;

            if (_player1.Color == Color.White)
            {
                _currentPlayer = player1;
            }
            else
            {
                _currentPlayer = player2;
            }

            Spaces = new Space[_boardSize, _boardSize];

            for (var i = 0; i < _boardSize; i++)
            {
                for (var j = 0; j < _boardSize; j++)
                {
                    Spaces[i, j] = new Space(i, j);
                }
            }

            InitStartPosition();

        }

        /// <summary>
        /// Method switch player after turn
        /// </summary>
        public void NextTurn()
        {
            if (_player1.Equals(_currentPlayer))
            {
                _currentPlayer = _player2;
            }
            else
            {
                _currentPlayer = _player1;
            }    
        }

        public void Turn(int x1, int y1, int x2, int y2)
        {
            Turn(new Point(x1, y1), new Point(x2, y2));
        }

        /// <summary>
        /// Method describing turn of player on the chess board 
        /// </summary>
        /// <param name="point1">Start coordinate</param>
        /// <param name="point2">Target coordinate</param>
        public void Turn(Point point1, Point point2)
        {
            //Exception, if start coordinate equal target coordinate
            if (point1.X == point2.X && point1.Y == point2.Y)
            {
                throw new Exception("Can't move to the same place");
            }

            //Exception, if player moves chess figure that is not his color
            if (!CanCurrentPlayerMoveFigure(GetFigure(point1)))
            {
                throw new Exception("Can't move enemy figures");
            }


            if (!GetSpace(point1).CanFigureMoveTo(point2))
            {
                if (GetFigure(point1) is Pawn)
                {
                    var pawn = (Pawn)GetFigure(point1);

                    if (!(GetFigure(point2).Color != _currentPlayer.Color && pawn.CanAttack(point1, point2)))
                    {
                        throw new Exception("Can't attack this figure");
                    }
                }
                else
                {
                    throw new Exception("This figure can't move like that");
                }
            }

            var figureWay = GetSpace(point1).GetFigureWay(point2).ToList();

            for (var i = 1; i < figureWay.Count - 2; i++)
            {
                //Exception, if any figure is in the path
                if (GetSpace(figureWay[i]).Figure != null)
                {
                    throw new Exception("Figure stands in the path");
                }
                
            }

            //Moves the chess figure to target coordinate, if figure on target coordinate is null 
            if (GetSpace(figureWay.Last()).Figure == null)
            {
                GetSpace(figureWay.Last()).Figure = GetSpace(figureWay.First()).Figure;
                GetSpace(figureWay.First()).Figure = null;
                NextTurn();
                return;
            }

            //Exception, if figure color on target coordinate equal current player color
            if (GetSpace(figureWay.Last()).Figure.Color == _currentPlayer.Color)
            {
                throw new Exception("Can't attack allied figure");
            }

            //Attack the figure, if figure color on target coordinate not equal current player color
            if (GetSpace(figureWay.Last()).Figure.Color != _currentPlayer.Color)
            {
                GetSpace(figureWay.Last()).Figure = GetSpace(figureWay.First()).Figure;
                GetSpace(figureWay.First()).Figure = null;
                NextTurn();
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point">Target coordinate</param>
        /// <returns>Space(square) on the current coordinates</returns>
        public Space GetSpace(Point point) => Spaces[point.X, point.Y];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point">Target coordinates</param>
        /// <returns>Figure on the current coordinates</returns>
        public Figure GetFigure(Point point) => GetSpace(point).Figure;

        /// <summary>
        /// Initialization all figures to the start position
        /// </summary>
        public void InitStartPosition()
        {
            //initialization white figures
            for (var i = 0; i < _boardSize; i++)
            {
                Spaces[6, i].Figure = new Pawn(Color.White);
            }

            Spaces[7, 0].Figure = new Rook(Color.White);
            Spaces[7, 1].Figure = new Knight(Color.White);
            Spaces[7, 2].Figure = new Bishop(Color.White);
            Spaces[7, 3].Figure = new Queen(Color.White);
            Spaces[7, 4].Figure = new King(Color.White);
            Spaces[7, 5].Figure = new Bishop(Color.White);
            Spaces[7, 6].Figure = new Knight(Color.White);
            Spaces[7, 7].Figure = new Rook(Color.White);    

            //initialization black figures
            for (var i = 0; i < _boardSize; i++)
            {
                Spaces[1, i].Figure = new Pawn(Color.Black);
            }

            Spaces[0, 0].Figure = new Rook(Color.Black);
            Spaces[0, 1].Figure = new Knight(Color.Black);
            Spaces[0, 2].Figure = new Bishop(Color.Black);
            Spaces[0, 3].Figure = new Queen(Color.Black);
            Spaces[0, 4].Figure = new King(Color.Black);
            Spaces[0, 5].Figure = new Bishop(Color.Black);
            Spaces[0, 6].Figure = new Knight(Color.Black);
            Spaces[0, 7].Figure = new Rook(Color.Black);
        }

        /// <summary>
        /// Method that allows move figures of only one color
        /// </summary>
        /// <param name="figure">Current chess figure</param>
        /// <returns>True, if current player color equal current figure color, otherwise - false</returns>
        public bool CanCurrentPlayerMoveFigure(Figure figure)
        {
            return _currentPlayer.Color == figure.Color;
        }

    }
  
}
