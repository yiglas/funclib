using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class ConsShould
    {
        [Test]
        public void Cons_should_prepend_one_to_a_list()
        {
            var actual = toarray(cons(1, new int[] { 2, 3, 4, 5, 6 }));

            Assert.AreEqual(1, actual[0]);
        }
    }
}
