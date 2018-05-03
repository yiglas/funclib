using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using _ = funcx.core;

namespace funcx.tests
{
    public class CoreShould
    {
        [Test]
        public void Core_should_all_underscore()
        {
            var actual = _.inc(0);

            Assert.AreEqual(1, actual);
        }
    }
}
