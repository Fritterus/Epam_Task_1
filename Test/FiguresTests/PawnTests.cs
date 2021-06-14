using FluentAssertions;
using NUnit.Framework;
using System;
using Chess;
using Chess.Enum;
using Chess.Figures;

namespace Test
{
    public class PawnTests
    {
        [Test]
        public void CanMoveTo_WhenPawnMoveForward_ShouldReturnTrue()
        {
            // Act
            var pawn = new Pawn(Color.White);

            var result = pawn.CanMoveTo(5, 2, 4, 2);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void CanMoveTo_WhenPawnJumpFromStartPosition_ShouldReturnTrue()
        {
            // Act
            var pawn = new Pawn(Color.White);

            var result = pawn.CanJumpTo(6, 2, 4, 2);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void CanMoveTo_WhenPawnJumpFromNonStartPosition_ShouldReturnFalse()
        {
            // Act
            var pawn = new Pawn(Color.White);

            var result = pawn.CanJumpTo(5, 2, 3, 2);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void CanMoveTo_WhenPawnMoveBack_ShouldReturnFalse()
        {
            // Act
            var pawn = new Pawn(Color.White);

            var result = pawn.CanMoveTo(5, 2, 6, 2);

            // Assert
            result.Should().BeFalse();
        }

    }
}