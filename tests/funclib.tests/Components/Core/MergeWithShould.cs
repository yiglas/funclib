using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class MergeWithShould
    {
        [Test]
        public void MergeWith_should_merge_two_maps_with_a_function()
        {
            var expected = hashMap(":a", 10, ":b", 100, ":c", 0);
            var actual = new MergeWith().Invoke(new Plus(), hashMap(":a", 1, ":b", 2), hashMap(":a", 9, ":b", 98, ":c", 0));

            Assert.AreEqual(expected, actual);
        }
    }
}
