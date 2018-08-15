using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SetShould
    {
        [Test]
        public void Set_should_return_a_hashset()
        {
            var actual = funclib.Core.Set(funclib.Core.Vector(1, 1, 2, 3, 2, 4, 5, 5));

            Assert.IsInstanceOf<funclib.Collections.HashSet>(actual);
        }

        [Test]
        public void Set_should_return_a_distinct_list_of_items_from_a_list()
        {
            var expected = funclib.Core.HashSet(1, 2, 3, 4, 5);
            var actual = funclib.Core.Set(funclib.Core.List(1, 1, 2, 3, 2, 4, 5, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Set_should_return_an_empty_set_if_passed_null()
        {
            var expected = funclib.Core.HashSet();
            var actual = funclib.Core.Set(null);

            Assert.AreEqual(expected, actual);
        }
    }
}
