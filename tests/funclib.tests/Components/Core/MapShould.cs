using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class MapShould
    {
        [Test]
        public void Map_should_apply_function_to_each_item_passed()
        {
            var expected = list(2, 3, 4, 5, 6);
            var actual = map(new Inc(), vector(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }
    }
}
