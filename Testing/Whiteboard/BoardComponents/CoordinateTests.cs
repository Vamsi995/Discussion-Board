﻿/**
 * Owned By: Parul Sangwan
 * Created By: Parul Sangwan
 * Date Created: 11/25/2021
 * Date Modified: 11/28/2021
**/

using System;
using NUnit.Framework;
using Whiteboard;

namespace Testing.Whiteboard
{
    [TestFixture]
    internal class CoordinateTests
    {
        [SetUp]
        public void SetUp()
        {
            _random = new Random();
        }

        private Random _random;

        [Test]
        public void Equals_CompareValues_ReturnsTrueThenFalse()
        {
            Coordinate a = new(1, 2);
            Assert.IsTrue(a.Equals(new Coordinate((float) 1.001, (float) 1.999)));
            Assert.IsFalse(a.Equals(new Coordinate((float) 1.3, 2)));
        }

        [Test]
        public void Clone_CreateClone_ReturnsClone()
        {
            Coordinate a = new(1, 2);
            Assert.IsFalse(ReferenceEquals(a, a.Clone()));
            Assert.IsTrue(a.Equals(a.Clone()));
        }

        [Test]
        public void IsLessThan_ComparisonWithLesser_ReturnsFalse()
        {
            Coordinate a = new(1, 2);
            Coordinate b = new(_random.Next(-5, 10), _random.Next(-10, 1));
            Assert.IsFalse(a.IsLessThan(a.Clone()));
            Assert.IsFalse(a.IsLessThan(b));
        }

        [Test]
        public void IsLessThan_ComparisonWithGreater_ReturnsTrue()
        {
            Coordinate a = new(1, 2);
            Coordinate b = new(_random.Next(2, 10), _random.Next(3, 10));
            Assert.IsTrue(a.IsLessThan(b));
        }

        [Test]
        public void Subtract_SubtractTwoNumbers_ReturnResultant()
        {
            Coordinate a = new(_random.Next(-5, 10), _random.Next(-5, 10));
            Coordinate b = new(_random.Next(-5, 10), _random.Next(-5, 10));
            Coordinate result = new(a.R - b.R, a.C - b.C);
            a.Subtract(b);
            Assert.IsTrue(result.Equals(a));
        }

        [Test]
        public void Add_AddTwoNumbers_ReturnsResultant()
        {
            Coordinate a = new(_random.Next(-5, 10), _random.Next(-5, 10));
            Coordinate b = new(_random.Next(-5, 10), _random.Next(-5, 10));
            Coordinate result = new(a.R + b.R, a.C + b.C);
            a.Add(b);
            Assert.IsTrue(result.Equals(a));
        }

        [Test]
        public void Operators_TestAllOperatorOverloads_ReturnsResultant()
        {
            // Coordinates to perform operation on
            Coordinate a = new(_random.Next(-5, 10), _random.Next(-5, 10));
            Coordinate b = new(_random.Next(-5, 10), _random.Next(-5, 10));

            // Testing + overload operator
            var c = a + b;
            Coordinate result = new(a.R + b.R, a.C + b.C);
            Assert.IsTrue(c.Equals(result));

            // Testing - overload operator
            c = a - b;
            result = new Coordinate(a.R - b.R, a.C - b.C);
            Assert.IsTrue(c.Equals(result));
            result = new Coordinate(c.R / 2, c.C / 2);

            // Testing division overload operator
            c /= 2;
            Assert.IsTrue(c.Equals(result));
            var e = Assert.Throws<Exception>(delegate
            {
                var a = c / 0;
            });
            Assert.That(e.Message, Is.EqualTo("Division of coordinate by 0."));
        }
    }
}