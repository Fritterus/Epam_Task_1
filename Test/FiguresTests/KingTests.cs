using FluentAssertions;
using NUnit.Framework;
using System;
using Chess;
using Chess.Enum;
using Chess.Figures;

namespace Test
{
    public class KingTests
    {
        [Test]
        public void CanMoveTo_WhenCoordinateIsCorrect_ShouldReturnTrue()
        {
            // Act
            var king = new King(Color.White);

            var result = king.CanMoveTo(7, 2, 6, 2);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void CanMoveTo_WhenCoordinateIsNotCorrect_ShouldReturnFalse()
        {
            // Act
            var king = new King(Color.White);

            var result = king.CanMoveTo(7, 2, 5, 2);

            // Assert
            result.Should().BeFalse();
        }

    }
}