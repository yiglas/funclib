using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class IncShould
    {
        [Test]
        public void Inc_should_inc_passed_in_number()
        {
            var actual = inc(0); // ++2

            Assert.AreEqual(1, actual);
        }
    }
}
