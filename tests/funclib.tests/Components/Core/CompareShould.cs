using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class CompareShould
    {
        [Test]
        public void Compare_should_return_zero_when_two_collection_are_equal()
        {
            var expected = 0;
            var actual = compare(new Vector().Invoke(1, 2, 3), new Vector().Invoke(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compare_should_return_negative_one_when_y_has_more_items_than_x()
        {
            var expected = -1;
            var actual = compare(new Vector().Invoke(1, 2, 3), new Vector().Invoke(0, 1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compare_should_return_one_when_x_has_more_items_than_y()
        {
            var expected = 1;
            var actual = compare(new Vector().Invoke(1, 2, 3), new Vector().Invoke(2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compare_should_return_one_when_y_is_null()
        {
            var expected = 1;
            var actual = compare(new Vector().Invoke(1, 2, 3), null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compare_should_return_negative_one_when_x_is_null()
        {
            var expected = -1;
            var actual = compare(null, new Vector().Invoke(0, 1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Compare_should_return_correct_value_when_comparing_strings()
        {
            var expected = -1;
            var actual = compare("abc", "def");

            Assert.AreEqual(expected, actual);
        }
    }
}
