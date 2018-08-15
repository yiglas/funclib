using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class DropLastShould
    {
        [Test]
        public void DropLast_should_return_a_lazy_seq()
        {
            var actual = funclib.Core.DropLast(funclib.Core.Vector(1, 2, 3, 4, 5));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void DropLast_should_return_all_items_when_passed_a_negative_number()
        {
            var expected = funclib.Core.List(1, 2, 3, 4, 5);
            var actual = funclib.Core.ToArray(funclib.Core.DropLast(-1, funclib.Core.Vector(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropLast_should_return_all_items_when_passed_zero_as_number()
        {
            var expected = funclib.Core.List(1, 2, 3, 4, 5);
            var actual = funclib.Core.ToArray(funclib.Core.DropLast(0, funclib.Core.Vector(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropLast_should_return_all_but_last_item_when_only_passed_a_collection()
        {
            var expected = funclib.Core.List(1, 2, 3, 4);
            var actual = funclib.Core.ToArray(funclib.Core.DropLast(funclib.Core.Vector(1, 2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DropLast_should_work_with_map_structures()
        {
            var expected = funclib.Core.List(new funclib.Collections.KeyValuePair(":a", 1), new funclib.Collections.KeyValuePair(":b", 2));
            var actual = funclib.Core.ToArray(funclib.Core.DropLast(2, funclib.Core.ArrayMap(":a", 1, ":b", 2, ":c", 3, ":d", 4)));

            Assert.AreEqual(expected, actual);
        }
    }
}
