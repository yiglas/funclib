using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class SortShould
    {
        [Test]
        public void Sort_should_sort_ascending()
        {
            var expected = list(1, 2, 3, 4);
            var actual = new Sort().Invoke(new Vector().Invoke(3, 1, 2, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_should_sort_using_a_function()
        {
            var expected = list(10, 5, 2);
            var actual = new Sort().Invoke(new IsGreaterThan(), new Values().Invoke(arrayMap(":foo", 5, ":bar", 2, ":baz", 10)));

            Assert.AreEqual(expected, actual);
        }
    }
}
