using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funcx.core;

namespace funcx.tests.Core
{
    public class InterposeShould
    {
        [Test]
        public void Interpose_should_insert_seperator_between_collection()
        {
            var actual = interpose(", ", new string[] { "one", "two", "three" }).ToArray();

            Assert.AreEqual(actual.Length, 5);
        }
    }
}
