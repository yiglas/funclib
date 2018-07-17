using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class MergeWithShould
    {
        [Test]
        public void MergeWith_should_merge_two_maps_with_a_function()
        {
            var expected = new HashMap().Invoke(":a", 10, ":b", 100, ":c", 0);
            var actual = new MergeWith().Invoke(new Plus(), new HashMap().Invoke(":a", 1, ":b", 2), new HashMap().Invoke(":a", 9, ":b", 98, ":c", 0));

            Assert.AreEqual(expected, actual);
        }
    }
}
