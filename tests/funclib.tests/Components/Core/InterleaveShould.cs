using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class InterleaveShould
    {
        [Test]
        public void Interleave_should_combine_two_lists()
        {
            var expected = list(":a", 1, ":b", 2, ":c", 3);
            var actual = interleave(vector(":a", ":b", ":c"), vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interleave_should_work_with_a_repeated_collection()
        {
            var expected = list("a", 1, "a", 2, "a", 3);
            var actual = interleave(repeat("a"), vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interleave_should_work_with_apply()
        {
            var expected = list(0.1, 0, 0.2, 1, 0.3, 2);
            var actual = apply(new Interleave(), new object[] { vector(0.1, 0.2, 0.3), range() });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interleave_should_return_an_empty_list_passing_no_parameters()
        {
            var expected = funclib.Collections.List.EMPTY;
            var actual = interleave();

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Interleave_should_return_a_lazy_seq()
        {
            var actual = interleave("test");

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Interleave_should_return_a_repeating_collection_with_more_than_two_collections()
        {
            var expected = list('A', ' ', 'a', 'B', ' ', 'b', 'C', ' ', 'c');
            var actual = toArray(interleave(vector('A', 'B', 'C'), repeat(3, ' '), vector('a', 'b', 'c')));

            Assert.AreEqual(expected, actual);
        }

    }
}
