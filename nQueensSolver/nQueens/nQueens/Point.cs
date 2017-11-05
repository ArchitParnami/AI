/*
 * Author: Archit Parnami
 */

namespace nQueens
{
    class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            var p = obj as Point;
            if (p == null)
                return false;

            return (this.X == p.X && this.Y == p.Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
