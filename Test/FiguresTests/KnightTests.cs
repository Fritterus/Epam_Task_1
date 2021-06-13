using FluentAssertions;
using NUnit.Framework;
using System;
using Chess;
using Chess.Enum;
using Chess.Figures;

namespace Test
{
    public class KnightTests
    {
        [Test]
        public void CanMoveTo_WhenCoordinateIsCorrect_ShouldReturnTrue()
        {
            // Act
            var knight = new Knight(Color.White);

            var result = knight.CanMoveTo(7, 2, 5, 3);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void CanMoveTo_WhenCoordinateIsNotCorrect_ShouldReturnFalse()
        {
            // Act
            var knight = new Knight(Color.White);

            var result = knight.CanMoveTo(7, 2, 5, 4);

            // Assert
            result.Should().BeFalse();
        }

    }
}