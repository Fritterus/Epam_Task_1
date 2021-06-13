using FluentAssertions;
using NUnit.Framework;
using System;
using Chess;
using Chess.Enum;
using Chess.Figures;

namespace Test
{
    public class ClassicBoardTests
    {
        private ClassicBoard _board;

        [SetUp]
        public void SetUp()
        {
            _board = new ClassicBoard(new Player(Color.Black), new Player(Color.White));
        }

        [Test]
        public void Turn_WhenFigureMoveToSamePlace_ShouldReturnException()
        {
            // Act
            Action result = () => _board.Turn(6, 3, 6, 3);

            // Assert
            result.Should()
                  .Throw<Exception>()
                  .WithMessage("Can't move to the same place");
        }

        [Test]
        public void Turn_WhenFigureAttackAlliedFigure_ShouldReturnException()
        {
            // Act
            Action result = () => _board.Turn(7, 2, 6, 1);


            // Assert
            result.Should()
                  .Throw<Exception>()
                  .WithMessage("Can't attack allied figure");
        }

        [Test]
        public void Turn_WhenPlayerMovesEnemyFigure_ShouldReturnException()
        {
            // Act
            Action result = () => _board.Turn(0, 1, 2, 2);

            // Assert
            result.Should()
                  .Throw<Exception>()
                  .WithMessage("Can't move enemy figures");
        }

        [Test]
        public void Turn_WhenFigureCantMoveLikeThat_ShouldReturnException()
        {
            // Act
            Action result = () => _board.Turn(7, 1, 5, 1);

            // Assert
            result.Should()
                  .Throw<Exception>()
                  .WithMessage("This figure can't move like that");
        }

        [Test]
        public void Turn_WhenFigureAttack_ShouldEnemyFigureDisappear()
        {
            // Arrange
            _board.Turn(6, 0, 5, 0);
            _board.Turn(1, 1, 2, 1);
            _board.Turn(5, 0, 4, 0);
            _board.Turn(2, 1, 3, 1);

            // Act
            _board.Turn(4, 0, 3, 1);

            // Assert
            _board.GetSpace(new Point(3, 1)).Figure.Color.Should().BeEquivalentTo(Color.White);
            _board.GetSpace(new Point(4, 0)).Figure.Should().BeNull();

        }

    }
}