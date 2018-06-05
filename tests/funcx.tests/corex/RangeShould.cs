using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class RangeShould
    {
        [Test]
        public void Range_should_return_a_lazy_seq()
        {
            var actual = take(10, range()).ToArray();

            Assert.AreEqual(10, actual.Length);
        }

        [Test]
        public void Range_should_return_the_number_of_items_passed_in()
        {
            var actual = range(10);

            Assert.AreEqual(10, actual.Count());
        }

        [Test]
        public void Range_should_return_the_min_max_and_all_the_numbers_between()
        {
            var actual = range(-5, 5);

            Assert.AreEqual(10, actual.Count());
        }

        [Test]
        public void Range_should_return_the_min_max_and_all_the_numbers_between_by_step()
        {
            var actual = range(-100, 100, 10);

            Assert.AreEqual(20, actual.Count());
        }
    }
}
