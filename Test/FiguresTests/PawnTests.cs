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
        public void CanMoveTo_WhenCoordinateIsNotCorrect_ShouldReturnFalse()
        {
            // Act
            var pawn = new Pawn(Color.White);

            var result = pawn.CanMoveTo(5, 2, 6, 2);

            // Assert
            result.Should().BeFalse();
        }

    }
}