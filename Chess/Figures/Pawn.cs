using System;
using System.Collections.Generic;
using System.Text;
using Chess.Enum;

namespace Chess.Figures
{
    class Pawn : Figure
    {
        public Pawn (Color color)
        {
            Color = color;
            Type = FigureType.Pawn;
        }


        public override bool CanMoveTo(int x1, int y1, int x2, int y2)
        {
            if ((x2 - x1) == 1 && (y2 == y1) && Color == Color.Black)
            {
                return true;
            }
            if ((x2 - x1) == -1 && (y2 == y1) && Color == Color.White)
            {
                return true;
            }
            return false;
        }

        public override bool CanMoveTo(Point point1, Point point2)
        {
            //if (Math.Abs(X - point.X) == 2 && Math.Abs(Y - point.Y) == 1) return true;
            //if (Math.Abs(X - point.X) == 1 && Math.Abs(Y - point.Y) == 2) return true;
            return false;
        }

        public bool CanAttack(int x1, int y1, int x2, int y2)
        {
            if (Color == Color.White && (x2 - x1) == -1 && Math.Abs(y2 - y1) == 1)
            {
                return true;
            }
            if (Color == Color.Black && (x2 - x1) == 1 && Math.Abs(y2 - y1) == 1)
            {
                return true;
            }
            return false;

        }

        public bool CanAttack(Point point1, Point point2)
        {
            if (Color == Color.White && (point2.X - point1.X) == -1 && Math.Abs(point2.Y - point1.Y) == 1)
            {
                return true;
            }
            if (Color == Color.Black && (point2.X - point1.X) == 1 && Math.Abs(point2.Y - point1.Y) == 1)
            {
                return true;
            }
            return false;

        }



        public override IEnumerable<Point> Way(int x1, int y1, int x2, int y2)
        {
            yield return new Point(x1, y1);
            yield return new Point(x2, y2);
        }

        public override IEnumerable<Point> Way(Point point1, Point point2)
        {
            yield return new Point(point1.X, point1.Y);
            yield return new Point(point2.X, point2.Y);
        }
    }
}
