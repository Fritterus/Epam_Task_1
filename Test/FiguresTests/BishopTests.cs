using FluentAssertions;
using NUnit.Framework;
using System;
using Chess;
using Chess.Enum;
using Chess.Figures;

namespace Test
{
    public class BishopTests
    {
        [TestCase(4, 4, 7, 1, TestName = "CanMoveTo_WhenBishopMoveDiagonallyLeftDown_ShouldReturnTrue")]
        [TestCase(4, 4, 7, 7, TestName = "CanMoveTo_WhenBishopMoveDiagonallyRightDown_ShouldReturnTrue")]
        [TestCase(4, 4, 0, 0, TestName = "CanMoveTo_WhenBishopMoveDiagonallyLeftUp_ShouldReturnTrue")]
        [TestCase(4, 4, 1, 7, TestName = "CanMoveTo_WhenBishopMoveDiagonallyRightUp_ShouldReturnTrue")]
        public void Test_CanMoveTo(int x1, int y1, int x2, int y2)
        {
            // Act
            var bishop = new Bishop(Color.White);

            var result = bishop.CanMoveTo(x1, y1, x2, y2);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void CanMoveTo_WhenCoordinateIsNotCorrect_ShouldReturnFalse()
        {
            // Act
            var bishop = new Bishop(Color.White);

            var result = bishop.CanMoveTo(7, 2, 6, 4);

            // Assert
            result.Should().BeFalse();
        }

    }
}