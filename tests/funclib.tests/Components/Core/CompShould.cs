using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class CompShould
    {
        [Test]
        public void Comp_should_compose_multiple_functions_into_one()
        {
            var negativeQuotient = comp(Minus, Divide);

            var expected = -2;
            var actual = invoke(negativeQuotient, 8, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Comp_should_return_identity_when_no_function_passed()
        {
            var actual = comp();

            Assert.IsInstanceOf<funclib.Components.Core.Identity>(actual);
        }

        [Test]
        public void Comp_should_return_the_object_passed_to_it()
        {
            var actual = comp(And);

            Assert.IsInstanceOf<funclib.Components.Core.And>(actual);
        }

        [Test]
        public void Comp_should_return_a_function_that_takes_no_parameters()
        {
            var expected = true;
            var actual = comp(funclib.core.Boolean, And);

            Assert.AreEqual(expected, invoke(actual));
        }

        [Test]
        public void Comp_should_return_a_function_that_take_one_parameter()
        {
            var expected = false;
            var actual = comp(funclib.core.Boolean, And);

            Assert.AreEqual(expected, invoke(actual, false));
        }

        [Test]
        public void Comp_should_allow_more_than_two_functions_as_parameters()
        {
            var expected = list(-5, -7, -9, -11);

            var actual = map(comp(Minus, partial(Plus, 3), partial(Multiply, 2)), vector(1, 2, 3, 4));
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Comp_should_return_a_function_that_take_three_parameter()
        {
            var expected = true;
            var actual = comp(funclib.core.Boolean, And);

            Assert.AreEqual(expected, invoke(actual, true, true, true));
        }
    }
}
