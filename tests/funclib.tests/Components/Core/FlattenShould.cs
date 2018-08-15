using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class FlattenShould
    {
        [Test]
        public void Flatten_should_flatten_nested_vectors()
        {
            var expected = funclib.Core.List(1, 2, 3);
            var actual = funclib.Core.ToArray(funclib.Core.Flatten(funclib.Core.Vector(1, funclib.Core.Vector(2, 3))));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Flatten_should_flatten_a_list_of_iterators()
        {
            var v1 = funclib.Core.List(funclib.Core.Take(10, funclib.Core.Range()), funclib.Core.Take(2, funclib.Core.Range()), funclib.Core.Take(5, funclib.Core.Range()));
            var actual = funclib.Core.Flatten(v1);

            Assert.AreEqual(17, funclib.Core.Count(actual));
        }

        [Test]
        public void Flatten_should_flatten_a_list_of_arrays()
        {
            //var v1 = new object[] { funclib.Core.Seq(new object[] { 1, 2 }), funclib.Core.Seq(new object[] { 1 }), funclib.Core.Seq(new object[] { 1 }), funclib.Core.Seq(new object[] { 1, 2 }) };
            var v1 = funclib.Core.List(funclib.Core.List(1, 2), funclib.Core.List(1), funclib.Core.List(1), funclib.Core.List(1, 2));
            var actual = funclib.Core.Flatten(v1);

            Assert.AreEqual(6, funclib.Core.Count(actual));
        }
    }
}
