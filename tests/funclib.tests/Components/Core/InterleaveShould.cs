using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class InterleaveShould
    {
        [Test]
        public void Interleave_should_combine_two_lists()
        {
            var expected = funclib.Core.List(":a", 1, ":b", 2, ":c", 3);
            var actual = funclib.Core.Interleave(funclib.Core.Vector(":a", ":b", ":c"), funclib.Core.Vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interleave_should_work_with_a_repeated_collection()
        {
            var expected = funclib.Core.List("a", 1, "a", 2, "a", 3);
            var actual = funclib.Core.Interleave(funclib.Core.Repeat("a"), funclib.Core.Vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interleave_should_work_with_apply()
        {
            var expected = funclib.Core.List(0.1, 0, 0.2, 1, 0.3, 2);
            var actual = funclib.Core.Apply(new Interleave(), new object[] { funclib.Core.Vector(0.1, 0.2, 0.3), funclib.Core.Range() });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interleave_should_return_an_empty_list_passing_no_parameters()
        {
            var expected = funclib.Collections.List.EMPTY;
            var actual = funclib.Core.Interleave();

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Interleave_should_return_a_lazy_seq()
        {
            var actual = funclib.Core.Interleave("test");

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Interleave_should_return_a_repeating_collection_with_more_than_two_collections()
        {
            var expected = funclib.Core.List('A', ' ', 'a', 'B', ' ', 'b', 'C', ' ', 'c');
            var actual = funclib.Core.ToArray(funclib.Core.Interleave(funclib.Core.Vector('A', 'B', 'C'), funclib.Core.Repeat(3, ' '), funclib.Core.Vector('a', 'b', 'c')));

            Assert.AreEqual(expected, actual);
        }

    }
}
