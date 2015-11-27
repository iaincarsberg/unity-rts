using UnityEngine;
using System.Collections;

namespace Game.Maths
{
    public struct FixedPointVector2
    {
        private static FixedPointVector2 _up = new FixedPointVector2(FixedPoint.Zero, FixedPoint.One);
        private static FixedPointVector2 _down = new FixedPointVector2(FixedPoint.Zero, FixedPoint.NegativeOne);
        private static FixedPointVector2 _left = new FixedPointVector2(FixedPoint.NegativeOne, FixedPoint.Zero);
        private static FixedPointVector2 _right = new FixedPointVector2(FixedPoint.One, FixedPoint.Zero);
        private static FixedPointVector2 _one = new FixedPointVector2(FixedPoint.One, FixedPoint.One);
        private static FixedPointVector2 _zero = new FixedPointVector2(FixedPoint.Zero, FixedPoint.Zero);

        public static FixedPointVector2 up
        {
            get
            {
                return _up;
            }
        }
        public static FixedPointVector2 down
        {
            get
            {
                return _down;
            }
        }
        public static FixedPointVector2 left
        {
            get
            {
                return _left;
            }
        }
        public static FixedPointVector2 right
        {
            get
            {
                return _right;
            }
        }
        public static FixedPointVector2 one
        {
            get
            {
                return _one;
            }
        }
        public static FixedPointVector2 zero
        {
            get
            {
                return _zero;
            }
        }

        public FixedPoint x { get; private set; }
        public FixedPoint y { get; private set; }

        public FixedPointVector2(float x, float y)
        {
            this.x = new FixedPoint(x);
            this.y = new FixedPoint(y);
        }

        public FixedPointVector2(FixedPoint x, FixedPoint y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
