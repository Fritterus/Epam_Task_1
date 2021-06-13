using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Interfaces
{
    interface IBoard
    {
        public void Turn(int x1, int y1, int x2, int y2);
        public void Turn(Point point1, Point point2);
    }
}
