﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class DivideShould
    {
        [Test]
        public void Divide_should_divide_one_by_passed_in_number()
        {
            var expected = 1 / 2;
            var actual = divide(2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Divide_should_throw_an_exception_if_not_passed_a_number()
        {
            Assert.Throws<InvalidCastException>(() => divide(""));
        }

        [Test]
        public void Divide_should_divide_passed_in_numbers()
        {
            var expected = 1;
            var actual = divide(2, 2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Divide_should_divide_all_passing_mulitple_items()
        {
            var expected = 3;
            var actual = divide(6, 2, 1);

            Assert.AreEqual(expected, actual);
        }
    }
}
