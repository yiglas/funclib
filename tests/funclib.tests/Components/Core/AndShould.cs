using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using funclib.Components.Core;
using System.Collections;
using static funclib.Core;

namespace funclib.Tests.Components.Core
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
            Assert.AreEqual(0, and.Invoke(1, 0));
            Assert.AreEqual(false, and.Invoke(false, null));
            Assert.AreEqual(null, and.Invoke(null, false));
        }

        [Test]
        public void And_should_allow_passing_functions()
        {
            var and = new And();

            var testNotNull = new Function<bool>(() => true);
            var testNull = new Function<bool?>(() => null);

            Assert.IsNotNull(and.Invoke(testNotNull, null));
            Assert.AreEqual(true, and.Invoke(testNull, true));
        }

        [Test]
        public void And_should_return_true_with_nothing_is_passed()
        {
            Assert.AreEqual(true, and());
        }

        [Test]
        public void And_should_execute_the_function_and_still_return_proper_value()
        {
            int i = 0;

            var actual = and(new Function<object>(() => { i = i + 1; return null; }).Invoke(), false);

            Assert.IsNull(actual);
            Assert.AreEqual(i, 1);
        }

        [Test]
        public void And_should_not_evaluate_the_function_if_the_first_value_is_false()
        {
            int i = 0;

            var expected = false;
            var actual = and(false, new Function<object>(() => { i = i + 1; return null; }));

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(i, 0);
        }
    }
}
