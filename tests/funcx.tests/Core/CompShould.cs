using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class CompShould
    {
        [Test]
        public void Comp_should_compose_multiple_functions_into_one()
        {
            var negativeQuotient = (Comp.Function)new Comp().Invoke(new Minus(), new Divide());

            var expected = -2;
            var actual = negativeQuotient.Invoke(8, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Comp_should_return_identity_when_no_function_passed()
        {
            var actual = new Comp().Invoke();

            Assert.IsInstanceOf<Identity>(actual);
        }

        [Test]
        public void Comp_should_return_the_object_passed_to_it()
        {
            var actual = new Comp().Invoke(new And());

            Assert.IsInstanceOf<And>(actual);
        }

        [Test]
        public void Comp_should_return_a_function_that_takes_no_parameters()
        {
            var expected = true;
            var actual = (Comp.Function)new Comp().Invoke(new FunctionalLibrary.Core.Boolean(), new And());

            Assert.AreEqual(expected, actual.Invoke());
        }

        [Test]
        public void Comp_should_return_a_function_that_take_one_parameter()
        {
            var expected = false;
            var actual = (Comp.Function)new Comp().Invoke(new FunctionalLibrary.Core.Boolean(), new And());

            Assert.AreEqual(expected, actual.Invoke(false));
        }

        [Test]
        public void Comp_should_allow_more_than_two_functions_as_parameters()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(-5, -7, -9, -11);
            var actual = new Map().Invoke(new Comp().Invoke(new Minus(), new Partial().Invoke(new Plus(), 3), new Partial().Invoke(new Multiply(), 2)), new Vector().Invoke(1, 2, 3, 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Comp_should_return_a_function_that_take_three_parameter()
        {
            var expected = true;
            var actual = (Comp.Function)new Comp().Invoke(new FunctionalLibrary.Core.Boolean(), new And());

            Assert.AreEqual(expected, actual.Invoke(true, true, true));
        }
    }
}
