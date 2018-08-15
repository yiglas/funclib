using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SplitAtShould
    {
        [Test]
        public void SplitAt_should_split_a_vector_at_the_given_number()
        {
            var expected = funclib.Core.Vector(funclib.Core.List(1, 2), funclib.Core.List(3, 4, 5));
            var actual = funclib.Core.SplitAt(2, funclib.Core.Vector(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SplitAt_should_return_empty_list_if_list_greater_then_count_of_coll()
        {
            var expected = funclib.Core.Vector(funclib.Core.List(1, 2), funclib.Core.List());
            var actual = funclib.Core.SplitAt(3, funclib.Core.Vector(1, 2));

            Assert.AreEqual(expected, actual);
        }
    }
}
