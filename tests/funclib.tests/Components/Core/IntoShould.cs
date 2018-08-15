using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IntoShould
    {
        [Test]
        public void Into_should_conjoin_values_from_into_to()
        {
            var expected = funclib.Core.SortedMap(":a", 1, ":b", 2, ":c", 3);
            var actual = funclib.Core.Into(funclib.Core.SortedMap(), funclib.Core.Vector(funclib.Core.Vector(":a", 1), funclib.Core.Vector(":b", 2), funclib.Core.Vector(":c", 3)));

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.SortedMap>(actual);
        }

        [Test]
        public void Into_should_split_map_into_a_vector_of_vectors()
        {
            var expected = funclib.Core.Vector(funclib.Core.Vector(1, 2), funclib.Core.Vector(3, 4));
            var actual = funclib.Core.Into(funclib.Core.Vector(), funclib.Core.ArrayMap(1, 2, 3, 4));

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
        }

        [Test]
        public void Into_should_change_from_one_type_of_map_to_another()
        {
            var expected = funclib.Core.SortedMap(":a", 1, ":b", 2, ":c", 3);
            var actual = funclib.Core.Into(funclib.Core.SortedMap(), funclib.Core.ArrayMap(":a", 1, ":b", 2, ":c", 3));

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOf<funclib.Collections.SortedMap>(actual);
        }
    }
}
