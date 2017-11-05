using System;

namespace nQueens
{
    class Pair : IEquatable<Pair>
    {
        private Point p1;
        private Point p2;

        public Pair(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public override bool Equals(object obj)
        {
            var pair = obj as Pair;
            if (pair == null)
                return false;


            return base.Equals(obj);
        }

        public bool Equals(Pair other)
        {
            return (other.p1.Equals(this.p1) && other.p2.Equals(this.p2)) ||
                (other.p1.Equals(this.p2) && other.p2.Equals(this.p1));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
