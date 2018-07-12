using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class InterleaveShould
    {
        [Test]
        public void Interleave_should_combine_two_lists()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(":a", 1, ":b", 2, ":c", 3);
            var actual = new Interleave().Invoke(new Vector().Invoke(":a", ":b", ":c"), new Vector().Invoke(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interleave_should_work_with_a_repeated_collection()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke("a", 1, "a", 2, "a", 3);
            var actual = new Interleave().Invoke(new Repeat().Invoke("a"), new Vector().Invoke(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interleave_should_work_with_apply()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(0.1, 0, 0.2, 1, 0.3, 2);
            var actual = new Apply().Invoke(new Interleave(), new object[] { new Vector().Invoke(0.1, 0.2, 0.3), new Range().Invoke() });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interleave_should_return_an_empty_list_passing_no_parameters()
        {
            var expected = FunctionalLibrary.Collections.List.EMPTY;
            var actual = new Interleave().Invoke();

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Interleave_should_return_a_lazy_seq()
        {
            var actual = new Interleave().Invoke("test");

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Interleave_should_return_a_repeating_collection_with_more_than_two_collections()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke('A', ' ', 'a', 'B', ' ', 'b', 'C', ' ', 'c');
            var actual = new ToArray().Invoke(new Interleave().Invoke(new Vector().Invoke('A', 'B', 'C'), new Repeat().Invoke(3, ' '), new Vector().Invoke('a', 'b', 'c')));

            Assert.AreEqual(expected, actual);
        }

    }
}
