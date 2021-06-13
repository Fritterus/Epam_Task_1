using FluentAssertions;
using NUnit.Framework;
using System;
using Chess;
using Chess.Enum;
using Chess.Figures;

namespace Test.FiguresTests
{
    public class RookTests
    {
        [TestCase(7, 2, 0, 2, TestName = "CanMoveTo_WhenRookMoveUp_ShouldReturnTrue")]
        [TestCase(0, 2, 7, 2, TestName = "CanMoveTo_WhenRookMoveDown_ShouldReturnTrue")]
        [TestCase(4, 5, 4, 0, TestName = "CanMoveTo_WhenRookMoveLeft_ShouldReturnTrue")]
        [TestCase(4, 0, 4, 5, TestName = "CanMoveTo_WhenRookMoveRight_ShouldReturnTrue")]
        public void Test_CanMoveTo(int x1, int y1, int x2, int y2)
        {
            // Act
            var rook = new Rook(Color.Black);

            var result = rook.CanMoveTo(x1, y1, x2, y2);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void CanMoveTo_WhenCoordinateIsNotCorrect_ShouldReturnFalse()
        {
            // Act
            var rook = new Rook(Color.Black);

            var result = rook.CanMoveTo(0, 0, 4, 4);

            // Assert
            result.Should().BeFalse();
        }
    }
}
