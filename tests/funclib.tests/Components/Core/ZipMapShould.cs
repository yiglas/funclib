using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ZipMapShould
    {
        [Test]
        public void ZipMap_should_zip_two_list_together()
        {
            var expected = arrayMap(":a", 1, ":b", 2, ":c", 3);
            var actual = new ZipMap().Invoke(new Vector().Invoke(":a", ":b", ":c"), new Vector().Invoke(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ZipMap_should_zip_two_list_together_with_one_being_infinit()
        {
            var expected = arrayMap(":a", 0, ":b", 1, ":c", 2);
            var actual = new ZipMap().Invoke(new Vector().Invoke(":a", ":b", ":c"), new Range().Invoke());

            Assert.AreEqual(expected, actual);
        }
    }
}
