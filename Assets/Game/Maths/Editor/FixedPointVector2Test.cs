using System;
using NUnit.Framework;

using Game.Maths;

namespace Game.Maths 
{
    public class FixedPointVector2Test
    {
        public class Constructor
        {
            /*
            [Test]
            public void WithZeroFloats_ZeroInts()
            {
                FixedPointVector2 v = new FixedPointVector2(0.0f, 0.0f);
                Assert.AreEqual(0, v.x.integer);
                Assert.AreEqual(_zeroFractionalMaxValue, v.x.fractional);
                Assert.AreEqual(0, v.y.integer);
                Assert.AreEqual(_zeroFractionalMaxValue, v.y.fractional);
            }
            
            [Test]
            public void WithPointFiveFloats_ZeroIntegerHalfMaxFractional()
            {
                FixedPointVector2 v = new FixedPointVector2(0.5f, 0.5f);
                Assert.AreEqual(0, v.x.integer);
                Assert.AreEqual(_halfFractionalMaxValue, v.x.fractional);
                Assert.AreEqual(0, v.y.integer);
                Assert.AreEqual(_halfFractionalMaxValue, v.y.fractional);
            }

            [Test]
            public void WithTenPointSevenFive_TenIntThreeQuarterFractional()
            {
                FixedPointVector2 v = new FixedPointVector2(10.75f, 10.75f);
                Assert.AreEqual(10, v.x.integer);
                Assert.AreEqual(_threeQuarterFractionalMaxValue, v.x.fractional);
                Assert.AreEqual(10, v.y.integer);
                Assert.AreEqual(_threeQuarterFractionalMaxValue, v.y.fractional);
            }

            [Test]
            public void WithTenPointTwoFive_TenIntQuarterFractional()
            {
                FixedPointVector2 v = new FixedPointVector2(10.25f, 10.25f);
                Assert.AreEqual(10, v.x.integer);
                Assert.AreEqual(_quarterFractionalMaxValue, v.x.fractional);
                Assert.AreEqual(10, v.y.integer);
                Assert.AreEqual(_quarterFractionalMaxValue, v.y.fractional);
            }

            [Test]
            public void WithMinusTenPointFive_MinusTenAndHalf()
            {
                FixedPointVector2 v = new FixedPointVector2(-10.5f, -10.5f);
                Assert.AreEqual(-10, v.x.integer);
                Assert.AreEqual(_halfFractionalMaxValue, v.x.fractional);
                Assert.AreEqual(-10, v.y.integer);
                Assert.AreEqual(_halfFractionalMaxValue, v.y.fractional);
            }
            */
        }

        public class StaticVariables
        {
            [Test]
            public void UpIsCorrect()
            {
                FixedPointVector2 up = FixedPointVector2.up;
                Assert.AreEqual(0, up.x.Value);
                Assert.AreEqual(4096, up.y.Value);
            }

            [Test]
            public void DownIsCorrect()
            {
                FixedPointVector2 down = FixedPointVector2.down;
                Assert.AreEqual(0, down.x.Value);
                Assert.AreEqual(-4096, down.y.Value);
            }

            [Test]
            public void LeftIsCorrect()
            {
                FixedPointVector2 left = FixedPointVector2.left;
                Assert.AreEqual(-4096, left.x.Value);
                Assert.AreEqual(0, left.y.Value);
            }

            [Test]
            public void RightIsCorrect()
            {
                FixedPointVector2 right = FixedPointVector2.right;
                Assert.AreEqual(4096, right.x.Value);
                Assert.AreEqual(0, right.y.Value);
            }

            [Test]
            public void OneIsCorrect()
            {
                FixedPointVector2 one = FixedPointVector2.one;
                Assert.AreEqual(4096, one.x.Value);
                Assert.AreEqual(4096, one.y.Value);
            }

            [Test]
            public void ZeroIsCorrect()
            {
                FixedPointVector2 zero = FixedPointVector2.zero;
                Assert.AreEqual(0, zero.x.Value);
                Assert.AreEqual(0, zero.y.Value);
            }
        }
    }
}