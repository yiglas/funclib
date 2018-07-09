using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class DropLastShould
    {
        [Test]
        public void DropLast_should_return_a_lazy_seq()
        {
            var actual = new DropLast().Invoke(new Vector().Invoke(1, 2, 3, 4, 5));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void DropLast_should_return_all_items_when_passed_a_negative_number()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(1, 2, 3, 4, 5);
            var actual = new ToArray().Invoke(new DropLast().Invoke(-1, new Vector().Invoke(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropLast_should_return_all_items_when_passed_zero_as_number()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(1, 2, 3, 4, 5);
            var actual = new ToArray().Invoke(new DropLast().Invoke(0, new Vector().Invoke(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropLast_should_return_all_but_last_item_when_only_passed_a_collection()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(1, 2, 3, 4);
            var actual = new ToArray().Invoke(new DropLast().Invoke(new Vector().Invoke(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropLast_should_work_with_map_structures()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(new FunctionalLibrary.Collections.KeyValuePair(":a", 1), new FunctionalLibrary.Collections.KeyValuePair(":b", 2));
            var actual = new ToArray().Invoke(new DropLast().Invoke(2, new ArrayMap().Invoke(":a", 1, ":b", 2, ":c", 3, ":d", 4)));

            Assert.AreEqual(expected, actual);
        }
    }
}
