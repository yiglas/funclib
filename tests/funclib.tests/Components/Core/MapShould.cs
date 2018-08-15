using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class MapShould
    {
        [Test]
        public void Map_should_apply_function_to_each_item_passed()
        {
            var expected = funclib.Core.List(2, 3, 4, 5, 6);
            var actual = funclib.Core.Map(funclib.Core.inc, funclib.Core.Vector(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Map_should_run_until_one_of_the_collections_is_out()
        {
            var expected = funclib.Core.List(2, 4, 6);
            var actual = funclib.Core.Map(funclib.Core.plus, funclib.Core.Vector(1, 2, 3), funclib.Core.Iterate(funclib.Core.inc, 1));
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Assoc_should_not_mutate_give_map()
        {
            var expected = funclib.Core.HashMap(":x", 1, ":y", 2, ":z", 3);
            var actual = funclib.Core.Assoc(expected, ":x", 1, ":y", 2, ":z", 3);

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(expected == actual);
        }
    }
}
