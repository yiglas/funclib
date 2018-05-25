using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using funcx.Core;
using System.Collections;

namespace funcx.tests.Core
{
    public class AndShould
    {
        [Test]
        public void And_should_allow_passing_object()
        {
            var and = new And();

            Assert.AreEqual(true, and.Invoke(true, true));
            Assert.AreEqual(false, and.Invoke(true, false));
            Assert.AreEqual(false, and.Invoke(false, false));
            Assert.AreEqual(typeof(ArrayList), and.Invoke(new ArrayList(), new ArrayList()).GetType());
            Assert.AreEqual(1, and.Invoke(0, 1));
            Assert.AreEqual(false, and.Invoke(false, null));
            Assert.AreEqual(null, and.Invoke(null, false));
        }

        [Test]
        public void And_should_allow_passing_functions()
        {
            var and = new And();

            var testNotNull = new Function<bool>(() => true);
            var testNull = new Function<bool?>(() => null);

            Assert.AreEqual(true, and.Invoke(testNotNull, null));
            Assert.AreEqual(null, and.Invoke(testNull, true));
        }

    }
}
