using FluentAssertions;
using NUnit.Framework;
using System;
using Chess;
using Chess.Enum;
using Chess.Figures;

namespace Test
{
    public class QueenTests
    {
        [TestCase(7, 2, 0, 2, TestName = "CanMoveTo_WhenQueenMoveUp_ShouldReturnTrue")]
        [TestCase(0, 2, 7, 2, TestName = "CanMoveTo_WhenQueenMoveDown_ShouldReturnTrue")]
        [TestCase(4, 5, 4, 0, TestName = "CanMoveTo_WhenQueenMoveLeft_ShouldReturnTrue")]
        [TestCase(4, 0, 4, 5, TestName = "CanMoveTo_WhenQueenMoveRight_ShouldReturnTrue")]
        [TestCase(4, 4, 7, 1, TestName = "CanMoveTo_WhenQueenMoveDiagonallyLeftDown_ShouldReturnTrue")]
        [TestCase(4, 4, 7, 7, TestName = "CanMoveTo_WhenQueenMoveDiagonallyRightDown_ShouldReturnTrue")]
        [TestCase(4, 4, 0, 0, TestName = "CanMoveTo_WhenQueenMoveDiagonallyLeftUp_ShouldReturnTrue")]
        [TestCase(4, 4, 1, 7, TestName = "CanMoveTo_WhenQueenMoveDiagonallyRightUp_ShouldReturnTrue")]
        public void Test_CanMoveTo(int x1, int y1, int x2, int y2)
        {
            // Act
            var queen = new Queen(Color.White);

            var result = queen.CanMoveTo(x1, y1, x2, y2);

            // Assert
            result.Should().BeTrue();
        }
    }
}