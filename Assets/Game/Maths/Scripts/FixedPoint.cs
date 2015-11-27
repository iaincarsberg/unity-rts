using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Maths
{
    /// <summary>
    /// Implements a fixed point number, based on https://en.wikipedia.org/wiki/Q_%28number_format%29
    /// </summary>
    public struct FixedPoint
    {
        /// <summary>
        /// Q Contains the resolution of this numbers fractional.
        /// </summary>
        public static short Q = 12;

        /// <summary>
        /// Contains the maximum integer value for FixedPoint.Value, this is 524288. 
        /// 31 is used, as this is a signed int
        /// </summary>
        public static int IntegerMaxValue = (int)Math.Pow(2, 31 - Q) - 1;

        /// <summary>
        /// Contains the maximum fractional value for FixedPoint.Value, this is 4095
        /// </summary>
        public static int FractionalMaxValue = (int)Math.Pow(2, Q) - 1;

        /// <summary>
        /// Contains a Zero value
        /// </summary>
        public static FixedPoint Zero = new FixedPoint(0);

        /// <summary>
        /// Contains a One value
        /// </summary>
        public static FixedPoint One = new FixedPoint(1 << Q);

        /// <summary>
        /// Contains a -One value
        /// </summary>
        public static FixedPoint NegativeOne = new FixedPoint(-1 << Q);

        /// <summary>
        /// Contains the maximum supported FixedPoint value
        /// </summary>
        public static FixedPoint MaxinumValidFixedPoint = new FixedPoint(IntegerMaxValue << Q);

        /// <summary>
        /// Contains the minimum supported FixedPoint value
        /// </summary>
        public static FixedPoint MininumValidFixedPoint = new FixedPoint(-(IntegerMaxValue << Q) - 1);

        /// <summary>
        /// Overloads the + operator
        /// </summary>
        /// <param name="fp1"></param>
        /// <param name="fp2"></param>
        /// <returns></returns>
        public static FixedPoint operator +(FixedPoint fp1, FixedPoint fp2)
        {
            // Convert the Value into an Int32
            int value = (fp1.Value >> Q) + (fp2.Value >> Q);

            if (value > IntegerMaxValue)
            {
                return MaxinumValidFixedPoint;
            }

            if (value < -IntegerMaxValue)
            {
                return MininumValidFixedPoint;
            }

            return new FixedPoint(fp1.Value + fp2.Value);
        }

        /// <summary>
        /// Overloads the - operator
        /// </summary>
        /// <param name="fp1"></param>
        /// <param name="fp2"></param>
        /// <returns></returns>
        public static FixedPoint operator -(FixedPoint fp1, FixedPoint fp2)
        {
            // Convert the Value into an Int32
            int value = (fp1.Value >> Q) - (fp2.Value >> Q);

            if (value > IntegerMaxValue)
            {
                return MaxinumValidFixedPoint;
            }

            if (value < -IntegerMaxValue)
            {
                return MininumValidFixedPoint;
            }

            return new FixedPoint(fp1.Value - fp2.Value);
        }

        /// <summary>
        /// Overloads the * operator
        /// </summary>
        /// <param name="fp1"></param>
        /// <param name="fp2"></param>
        /// <returns></returns>
        public static FixedPoint operator *(FixedPoint fp1, FixedPoint fp2)
        {
            long temp = (long)fp1.Value * (long)fp2.Value;
            long result = temp + ((temp & 1 << (Q - 1)) << 1);
            result >>= Q;

            if (result > IntegerMaxValue << Q)
            {
                return MaxinumValidFixedPoint;
            }

            if (result < -IntegerMaxValue << Q)
            {
                return MininumValidFixedPoint;
            }

            return new FixedPoint((int)result);
        }

        /// <summary>
        /// Overloads the / operator
        /// </summary>
        /// <param name="fp1"></param>
        /// <param name="fp2"></param>
        /// <returns></returns>
        public static FixedPoint operator /(FixedPoint fp1, FixedPoint fp2)
        {
            long temp = (long)fp1.Value / (long)fp2.Value;
            long result = temp + ((temp & 1 >> (Q - 1)) >> 1);
            result <<= Q;

            if (result > IntegerMaxValue << Q)
            {
                return MaxinumValidFixedPoint;
            }

            if (result < -IntegerMaxValue << Q)
            {
                return MininumValidFixedPoint;
            }

            return new FixedPoint((int)result);
        }

        /// <summary>
        /// Contains a signed 20.12 formatted number, allows +/- 524288.999755859375
        /// http://netwinder.osuosl.org/pub/netwinder/docs/nw/fix1FAQ.html Contains details on how this number was determined
        /// </summary>
        public int Value { get; private set; }

        public FixedPoint(int value)
        {
            Value = value;
        }

        public FixedPoint(float value)
        {
            int integer = Math.Min((int)value, IntegerMaxValue);
            int fractional = (int)Math.Round(FractionalMaxValue * (float)(value - integer));

            Value = integer << Q;
            Value += Math.Min(fractional, FractionalMaxValue);
        }
    }
}
