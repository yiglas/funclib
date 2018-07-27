using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class MapShould
    {
        [Test]
        public void Map_should_apply_function_to_each_item_passed()
        {
            var expected = list(2, 3, 4, 5, 6);
            var actual = map(Inc, vector(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Map_should_run_until_one_of_the_collections_is_out()
        {
            var expected = list(2, 4, 6);
            var actual = map(Plus, vector(1, 2, 3), iterate(Inc, 1));
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Assoc_should_not_mutate_give_map()
        {
            var expected = hashMap(":x", 1, ":y", 2, ":z", 3);
            var actual = assoc(expected, ":x", 1, ":y", 2, ":z", 3);

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(expected == actual);
        }
    }
}
