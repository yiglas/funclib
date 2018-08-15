using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class MergeWithShould
    {
        [Test]
        public void MergeWith_should_merge_two_maps_with_a_function()
        {
            var expected = funclib.Core.HashMap(":a", 10, ":b", 100, ":c", 0);
            var actual = funclib.Core.MergeWith(new Plus(), funclib.Core.HashMap(":a", 1, ":b", 2), funclib.Core.HashMap(":a", 9, ":b", 98, ":c", 0));

            Assert.AreEqual(expected, actual);
        }
    }
}
