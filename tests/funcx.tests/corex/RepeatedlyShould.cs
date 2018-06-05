using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class RepeatedlyShould
    {
        [Test]
        public void Repeatedly_should_return_a_lazy_seq()
        {
            var i = 0;
            var actual = take(5, repeatedly(() => inc(i))).ToArray();

            Assert.AreEqual(5, actual.Length);
        }
    }
}
