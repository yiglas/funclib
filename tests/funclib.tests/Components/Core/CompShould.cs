using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class CompShould
    {
        [Test]
        public void Comp_should_compose_multiple_functions_into_one()
        {
            var negativeQuotient = (Comp.Function)comp(new Minus(), new Divide());

            var expected = -2;
            var actual = negativeQuotient.Invoke(8, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Comp_should_return_identity_when_no_function_passed()
        {
            var actual = comp();

            Assert.IsInstanceOf<Identity>(actual);
        }

        [Test]
        public void Comp_should_return_the_object_passed_to_it()
        {
            var actual = comp(new And());

            Assert.IsInstanceOf<And>(actual);
        }

        [Test]
        public void Comp_should_return_a_function_that_takes_no_parameters()
        {
            var expected = true;
            var actual = (Comp.Function)comp(new funclib.Components.Core.Boolean(), new And());

            Assert.AreEqual(expected, actual.Invoke());
        }

        [Test]
        public void Comp_should_return_a_function_that_take_one_parameter()
        {
            var expected = false;
            var actual = (Comp.Function)comp(new funclib.Components.Core.Boolean(), new And());

            Assert.AreEqual(expected, actual.Invoke(false));
        }

        [Test]
        public void Comp_should_allow_more_than_two_functions_as_parameters()
        {
            var expected = list(-5, -7, -9, -11);
            var actual = map(comp(new Minus(), new Partial().Invoke(new Plus(), 3), new Partial().Invoke(new Multiply(), 2)), new Vector().Invoke(1, 2, 3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Comp_should_return_a_function_that_take_three_parameter()
        {
            var expected = true;
            var actual = (Comp.Function)comp(new funclib.Components.Core.Boolean(), new And());

            Assert.AreEqual(expected, actual.Invoke(true, true, true));
        }
    }
}
