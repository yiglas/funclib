using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class NthNextShould
    {
        [Test]
        public void NthNext_should_return_the_items_after_passed_number()
        {
            var expected = funclib.Core.List(3, 4, 5, 6, 7, 8, 9);
            var actual = funclib.Core.NthNext(funclib.Core.Range(10), 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NthNext_should_return_a_null_if_an_empty_collection_is_passed()
        {
            var actual = funclib.Core.NthNext(funclib.Core.Vector(), 3);

            Assert.IsNull(actual);
        }
    }
}
