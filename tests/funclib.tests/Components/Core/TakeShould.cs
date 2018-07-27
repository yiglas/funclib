using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class TakeShould
    {
        [Test]
        public void Take_should_return_a_lazy_sequence_of_items_from_a_list()
        {
            var expected = list(1, 2, 3);
            var actual = take(3, list(1, 2, 3, 4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_lazy_sequence_of_items_from_a_vector()
        {
            var expected = vector(1, 2, 3);
            var actual = take(3, vector(1, 2, 3, 4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_lazy_sequence_of_items_even_if_number_is_larger()
        {
            var expected = list(1, 2);
            var actual = take(3, list(1, 2));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_empty_lazy_sequence_when_passed_null()
        {
            var expected = list();
            var actual = take(3, null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_empty_lazy_sequence_when_number_is_zero()
        {
            var expected = list();
            var actual = take(0, list());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_empty_lazy_sequence_when_number_is_less_than_zero()
        {
            var expected = list();
            var actual = take(-1, list());

            Assert.AreEqual(expected, actual);
        }
    }
}
