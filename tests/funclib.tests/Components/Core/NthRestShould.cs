using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class NthRestShould
    {
        [Test]
        public void NthRest_should_skip_the_first_x()
        {
            var expected = funclib.Core.List(5, 6, 7, 8, 9);
            var actual = funclib.Core.NthRest(funclib.Core.Range(10), 5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NthRest_should_return_empty_collection_if_empty_collection_is_passed()
        {
            var expected = funclib.Core.Vector();
            var actual = funclib.Core.NthRest(funclib.Core.Vector(), 3);

            Assert.AreEqual(expected, actual);
        }
    }
}
