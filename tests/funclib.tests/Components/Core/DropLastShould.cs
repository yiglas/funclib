using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class DropLastShould
    {
        [Test]
        public void DropLast_should_return_a_lazy_seq()
        {
            var actual = dropLast(new Vector().Invoke(1, 2, 3, 4, 5));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void DropLast_should_return_all_items_when_passed_a_negative_number()
        {
            var expected = new funclib.Components.Core.List().Invoke(1, 2, 3, 4, 5);
            var actual = new ToArray().Invoke(dropLast(-1, new Vector().Invoke(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropLast_should_return_all_items_when_passed_zero_as_number()
        {
            var expected = new funclib.Components.Core.List().Invoke(1, 2, 3, 4, 5);
            var actual = new ToArray().Invoke(dropLast(0, new Vector().Invoke(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropLast_should_return_all_but_last_item_when_only_passed_a_collection()
        {
            var expected = new funclib.Components.Core.List().Invoke(1, 2, 3, 4);
            var actual = new ToArray().Invoke(dropLast(new Vector().Invoke(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropLast_should_work_with_map_structures()
        {
            var expected = new funclib.Components.Core.List().Invoke(new funclib.Collections.KeyValuePair(":a", 1), new funclib.Collections.KeyValuePair(":b", 2));
            var actual = new ToArray().Invoke(dropLast(2, arrayMap(":a", 1, ":b", 2, ":c", 3, ":d", 4)));

            Assert.AreEqual(expected, actual);
        }
    }
}
