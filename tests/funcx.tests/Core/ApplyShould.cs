using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Core
{
    public class ApplyShould
    {
        [Test]
        public void Apply_should_find_max()
        {
            var actaul = apply<int>(func<Func<int, int, int>>(max), new int[] { 1, 2, 3 });

            Assert.AreEqual(3, actaul);
        }
    }
}
