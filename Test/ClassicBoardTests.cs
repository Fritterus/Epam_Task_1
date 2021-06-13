using FluentAssertions;
using NUnit.Framework;
using System;
using Chess;
using Chess.Enum;

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
        public void Test1()
        {
            // Act
            Action result = () => _board.Turn(0, 0, 0, 0);


            // Assert
            result.Should()
                .Throw<Exception>()
                .WithMessage("Can't move to the same place");
        }

        public void Test2()
        {
            // Act
            Action result = () => _board.Turn(0, 0, 0, 0);


            // Assert
            result.Should()
                .Throw<Exception>()
                .WithMessage("Can't move to the same place");
        }

    }
}