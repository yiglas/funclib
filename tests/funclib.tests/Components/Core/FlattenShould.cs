using NUnit.Framework;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class FlattenShould
    {
        [Test]
        public void Flatten_should_flatten_nested_vectors()
        {
            var expected = list(1, 2, 3);
            var actual = toArray(flatten(vector(1, vector(2, 3))));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Flatten_should_flatten_a_list_of_iterators()
        {
            var v1 = list(take(10, range()), take(2, range()), take(5, range()));
            var actual = flatten(v1);

            Assert.AreEqual(17, count(actual));
        }

        [Test]
        public void Flatten_should_flatten_a_list_of_arrays()
        {
            //var v1 = new object[] { seq(new object[] { 1, 2 }), seq(new object[] { 1 }), seq(new object[] { 1 }), seq(new object[] { 1, 2 }) };
            var v1 = list(list(1, 2), list(1), list(1), list(1, 2));
            var actual = flatten(v1);

            Assert.AreEqual(6, count(actual));
        }
    }
}
