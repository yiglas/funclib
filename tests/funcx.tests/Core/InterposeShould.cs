using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Core
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
