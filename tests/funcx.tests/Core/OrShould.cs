using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class OrShould
    {
        [Test]
        public void Or_should_allow_passing_object()
        {
            var or = new Or();

            Assert.AreEqual(true, or.Invoke(true, false, false));
            Assert.AreEqual(true, or.Invoke(true, true, true));
            Assert.AreEqual(false, or.Invoke(false, false, false));
            Assert.AreEqual(null, or.Invoke(null, null));
            Assert.AreEqual(null, or.Invoke(false, null, null));
            Assert.AreEqual(true, or.Invoke(true, null));
            Assert.AreEqual(42, or.Invoke(false, 42, 999));
            Assert.AreEqual(42, or.Invoke(42, 9999));
        }
    }
}
