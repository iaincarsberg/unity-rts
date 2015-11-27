using System;
using NUnit.Framework;
using UnityEngine;

using Game.Maths;

namespace Game.Maths
{
    public class FixedPointTest
    {
        public static int IntegerMaxValue = 524287;

        public class Instantiation
        { 
            /// <summary>
            /// Used to test instantiation from a float
            /// </summary>
            /// <param name="value">Contains the desired value</param>
            /// <returns>Contains the stored int value</returns>
            [Test]
            [TestCase(1.0f, Result = 4096)]
            public int CheckFromFloat(float value)
            {
                FixedPoint fp = new FixedPoint(value);
                return fp.Value;
            }
        }

        public class Addition
        {
            /// <summary>
            /// TestCase's are based on FixedPointInteger.FractionalMaxValue being 4095
            /// </summary>
            /// <param name="v1">Contains fp1's instantiation value</param>
            /// <param name="v2">Contains fp2's instantiation value</param>
            /// <returns>The value of the sum of fp1 + fp2</returns>
            [Test]
            [TestCase(0, 0, Result = 0)]
            [TestCase(2048, 2048, Result = 4096)]// 0.5f + 0.5f
            [TestCase(3686, 410, Result = 4096)]// 0.9f + 0.1f
            [TestCase(3686, 3686, Result = 7372)]// 0.9f + 0.9f
            public int CheckAdditions(int v1, int v2)
            {
                FixedPoint fp1 = new FixedPoint(v1);
                FixedPoint fp2 = new FixedPoint(v2);

                FixedPoint result = fp1 + fp2;

                return result.Value;
            }

            /// <summary>
            /// Checks the overflow block is working correctly
            /// </summary>
            /// <param name="overflowAmount">How much past the safe limit is added</param>
            [Test]
            [TestCase(0)]
            [TestCase(1)]
            [TestCase(10)]
            [TestCase(100)]
            [TestCase(1000)]
            public void CheckWrapAround(int overflowAmount)
            {
                // Find the max value, by taking the largest safe 2^19 value, and bitshifting it by the Q fractional value
                int maxValue = IntegerMaxValue << 12;

                FixedPoint fp1 = new FixedPoint(maxValue);
                FixedPoint fp2 = new FixedPoint((1 << 12) + overflowAmount);

                FixedPoint result = fp1 + fp2;

                Assert.AreEqual(maxValue, result.Value);
            }
        }

        public class Subtraction
        {
            /// <summary>
            /// TestCase's are based on FixedPointInteger.FractionalMaxValue being 4095
            /// </summary>
            /// <param name="v1">Contains fp1's instantiation value</param>
            /// <param name="v2">Contains fp2's instantiation value</param>
            /// <returns>The value of the sum of fp1 - fp2</returns>
            [Test]
            [TestCase(0, 0, Result = 0)]
            [TestCase(2048, 2048, Result = 0)]// 0.5f - 0.5f
            [TestCase(3686, 410, Result = 3276)]// 0.9f + 0.1f
            [TestCase(3686, 3686, Result = 0)]// 0.9f + 0.9f
            public int CheckSubtractions(int v1, int v2)
            {
                FixedPoint fp1 = new FixedPoint(v1);
                FixedPoint fp2 = new FixedPoint(v2);

                FixedPoint result = fp1 - fp2;

                return result.Value;
            }

            /// <summary>
            /// Checks the overflow block is working correctly
            /// </summary>
            /// <param name="overflowAmount">How much past the safe limit is added</param>
            [Test]
            [TestCase(0)]
            [TestCase(1)]
            [TestCase(10)]
            [TestCase(100)]
            [TestCase(1000)]
            public void CheckWrapAround(int overflowAmount)
            {
                // Find the min value, by taking the smallest safe 2^19 value, and bitshifting it by the Q fractional value
                int minValue = -(IntegerMaxValue << 12) - 1;

                FixedPoint fp1 = new FixedPoint(minValue);
                FixedPoint fp2 = new FixedPoint((1 << 12) + overflowAmount);

                FixedPoint result = fp1 - fp2;

                Assert.AreEqual(minValue, result.Value);
            }
        }

        public class Multiplication
        { 
            /// <summary>
            /// Check multiplication works correctly
            /// </summary>
            /// <param name="v1"></param>
            /// <param name="v2"></param>
            /// <returns></returns>
            [Test]
            [TestCase(4096, 4096, Result = 4096)]// 1 * 1 = 1
            [TestCase(4096, 2048, Result = 2048)]// 1 * 0.5 = 0.5
            [TestCase(4096, -2048, Result = -2048)]// 1 * -0.5 = -0.5
            [TestCase(61440, -4096, Result = -61440)]// 1.5 * -1 = -1.5
            [TestCase(61440, 61440, Result = 921600)]// 1.5 * 1.5 = 2.25
            [TestCase(505675, 40960, Result = 5056750)]// 123.456 * 10 = 1234.56
            public int CheckMultiplications(int v1, int v2)
            {
                FixedPoint fp1 = new FixedPoint(v1);
                FixedPoint fp2 = new FixedPoint(v2);

                FixedPoint result = fp1 * fp2;

                return result.Value;
            }

            /// <summary>
            /// Checks the overflow block is working correctly
            /// </summary>
            /// <param name="overflowAmount">How much past the safe limit is added</param>
            [Test]
            [TestCase(0)]
            [TestCase(1)]
            [TestCase(10)]
            [TestCase(100)]
            [TestCase(1000)]
            public void CheckWrapAround(int overflowAmount)
            {
                // Find the max value, by taking the largest safe 2^19 value, and bitshifting it by the Q fractional value
                int maxValue = IntegerMaxValue << 12;

                FixedPoint fp1 = new FixedPoint(maxValue);
                FixedPoint fp2 = new FixedPoint((2 << 12) + overflowAmount);

                FixedPoint result = fp1 * fp2;

                Assert.AreEqual(maxValue, result.Value);
            }
        }

        public class Division
        {
            /// <summary>
            /// Check division works correctly
            /// </summary>
            /// <param name="v1"></param>
            /// <param name="v2"></param>
            /// <returns></returns>
            [Test]
            [TestCase(4096, 4096, Result = 4096)]// 1 / 1 = 1
            [TestCase(40960, 8192, Result = 20480)]// 10 / 2 = 5
            [TestCase(40960, 2048, Result = 81920)]// 10 / 0.5 = 20
            [TestCase(40960, -2048, Result = -81920)]// 10 / -0.5 = -20
            public int CheckDivisions(int v1, int v2)
            {
                FixedPoint fp1 = new FixedPoint(v1);
                FixedPoint fp2 = new FixedPoint(v2);

                FixedPoint result = fp1 / fp2;

                return result.Value;
            }
        }
    }
}