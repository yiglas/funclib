using NUnit.Framework;
using System;
using System.Text;
using funclib.Components.Core;
using list = funclib.Collections.List;
using vec = funclib.Collections.Vector;

namespace funclib.Tests.Components.Core
{
    public class TakeShould
    {
        [Test]
        public void Take_should_return_a_lazy_sequence_of_items_from_a_list()
        {
            var expected = list.Create(1, 2, 3);
            var actual = new Take().Invoke(3, list.Create(1, 2, 3, 4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_lazy_sequence_of_items_from_a_vector()
        {
            var expected = vec.Create(1, 2, 3);
            var actual = new Take().Invoke(3, vec.Create(1, 2, 3, 4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_lazy_sequence_of_items_even_if_number_is_larger()
        {
            var expected = list.Create(1, 2);
            var actual = new Take().Invoke(3, list.Create(1, 2));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_empty_lazy_sequence_when_passed_null()
        {
            var expected = list.EMPTY;
            var actual = new Take().Invoke(3, null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_empty_lazy_sequence_when_number_is_zero()
        {
            var expected = list.EMPTY;
            var actual = new Take().Invoke(0, list.EMPTY);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_empty_lazy_sequence_when_number_is_less_than_zero()
        {
            var expected = list.EMPTY;
            var actual = new Take().Invoke(-1, list.EMPTY);

            Assert.AreEqual(expected, actual);
        }
    }
}
