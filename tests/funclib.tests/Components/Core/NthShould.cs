using NUnit.Framework;
using System;

namespace funclib.Tests.Components.Core
{
    public class NthShould
    {
        [Test]
        public void Nth_should_use_zero_based_indexing()
        {
            var seq = funclib.Core.Vector("a", "b", "c", "d");
            var expected = "a";
            var actual = funclib.Core.Nth(seq, 0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Nth_should_find_char_in_string()
        {
            var expected = 't';
            var actual = funclib.Core.Nth("test", 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Nth_should_throw_IndexOutOfRangeException_for_string()
        {
            Assert.Throws<IndexOutOfRangeException>(() => funclib.Core.Nth("test", 10));
        }

        [Test]
        public void Nth_should_find_item_in_array()
        {
            var expected = 1;
            var actual = funclib.Core.Nth(new object[] { 1, 2, 3, 4}, 0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Nth_should_throw_IndexOutOfRangeException_for_array()
        {
            Assert.Throws<IndexOutOfRangeException>(() => funclib.Core.Nth(new object[] { 1, 2, 3, 4 }, 10));
        }

        [Test]
        public void Nth_should_find_item_in_list()
        {
            var expected = 2;
            var actual = funclib.Core.Nth(funclib.Core.List(1, 2, 3, 4), 1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Nth_should_throw_IndexOutOfRangeException_for_list()
        {
            Assert.Throws<IndexOutOfRangeException>(() => funclib.Core.Nth(funclib.Core.List(1, 2, 3, 4), 10));
        }

        [Test]
        public void Nth_should_not_throw_IndexOutOfRangeException_when_notFound_value_is_passed()
        {
            var expected = -1;
            var actual = funclib.Core.Nth(funclib.Core.List(1, 2, 3, 4), 10, -1);

            Assert.AreEqual(expected, actual);
        }
    }
}
