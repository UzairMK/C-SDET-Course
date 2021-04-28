using System;

namespace SafariPark
{
    public struct IntVector2D
    {
        public int[] Vector { get; set; }

        public IntVector2D(int x, int y)
        {
            Vector = new int[] { x, y };
        }

        public int[] DominateDirection()
        {
            int x = Vector[0];
            int y = Vector[1];

            return Math.Abs(x) >= Math.Abs(y) ?
                (x > 0 ? new int[] { 1, 0 } : x < 0 ? new int[] { -1, 0 } : new int[] { 0, 0 }) :
                (y > 0 ? new int[] { 0, 1 } : y < 0 ? new int[] { 0, -1 } : new int[] { 0, 0 });
        }
    }
}
