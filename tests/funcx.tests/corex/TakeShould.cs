using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class TakeShould
    {
        [Test]
        public void Take_should_return_the_count_from_lazy_list()
        {
            var actual = take(5, iterate(inc, 1)).ToArray();

            Assert.AreEqual(5, actual.Count());
        }

        [Test]
        public void Take_should_return_an_empty_enumerable_if_null_is_passed()
        {
            var actual = take(1, null);

            Assert.IsEmpty(actual);
        }
    }
}
