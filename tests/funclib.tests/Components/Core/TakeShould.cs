using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class TakeShould
    {
        [Test]
        public void Take_should_return_a_lazy_sequence_of_items_from_a_list()
        {
            var expected = funclib.Core.List(1, 2, 3);
            var actual = funclib.Core.Take(3, funclib.Core.List(1, 2, 3, 4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_lazy_sequence_of_items_from_a_vector()
        {
            var expected = funclib.Core.Vector(1, 2, 3);
            var actual = funclib.Core.Take(3, funclib.Core.Vector(1, 2, 3, 4, 5, 6));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_lazy_sequence_of_items_even_if_number_is_larger()
        {
            var expected = funclib.Core.List(1, 2);
            var actual = funclib.Core.Take(3, funclib.Core.List(1, 2));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_empty_lazy_sequence_when_passed_null()
        {
            var expected = funclib.Core.List();
            var actual = funclib.Core.Take(3, null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_empty_lazy_sequence_when_number_is_zero()
        {
            var expected = funclib.Core.List();
            var actual = funclib.Core.Take(0, funclib.Core.List());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Take_should_return_a_empty_lazy_sequence_when_number_is_less_than_zero()
        {
            var expected = funclib.Core.List();
            var actual = funclib.Core.Take(-1, funclib.Core.List());

            Assert.AreEqual(expected, actual);
        }
    }
}
