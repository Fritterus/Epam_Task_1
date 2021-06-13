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
        [Test]
        public void CanMoveTo_WhenCoordinateIsCorrect_ShouldReturnTrue()
        {
            // Act
            var bishop = new Bishop(Color.White);

            var result = bishop.CanMoveTo(7, 2, 5, 4);

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