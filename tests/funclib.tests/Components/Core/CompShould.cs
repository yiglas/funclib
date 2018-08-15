using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class CompShould
    {
        [Test]
        public void Comp_should_compose_multiple_functions_into_one()
        {
            var negativeQuotient = funclib.Core.Comp(funclib.Core.minus, funclib.Core.divide);

            var expected = -2;
            var actual = funclib.Core.Invoke(negativeQuotient, 8, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Comp_should_return_identity_when_no_function_passed()
        {
            var actual = funclib.Core.Comp();

            Assert.IsInstanceOf<funclib.Components.Core.Identity>(actual);
        }

        [Test]
        public void Comp_should_return_the_object_passed_to_it()
        {
            var actual = funclib.Core.Comp(funclib.Core.and);

            Assert.IsInstanceOf<funclib.Components.Core.And>(actual);
        }

        [Test]
        public void Comp_should_return_a_function_that_takes_no_parameters()
        {
            var expected = true;
            var actual = funclib.Core.Comp(funclib.Core.boolean, funclib.Core.and);

            Assert.AreEqual(expected, funclib.Core.Invoke(actual));
        }

        [Test]
        public void Comp_should_return_a_function_that_take_one_parameter()
        {
            var expected = false;
            var actual = funclib.Core.Comp(funclib.Core.boolean, funclib.Core.and);

            Assert.AreEqual(expected, funclib.Core.Invoke(actual, false));
        }

        [Test]
        public void Comp_should_allow_more_than_two_functions_as_parameters()
        {
            var expected = funclib.Core.List(-5, -7, -9, -11);

            var actual = funclib.Core.Map(funclib.Core.Comp(funclib.Core.minus, funclib.Core.Partial(funclib.Core.plus, 3), funclib.Core.Partial(funclib.Core.multiply, 2)), funclib.Core.Vector(1, 2, 3, 4));
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Comp_should_return_a_function_that_take_three_parameter()
        {
            var expected = true;
            var actual = funclib.Core.Comp(funclib.Core.boolean, funclib.Core.and);

            Assert.AreEqual(expected, funclib.Core.Invoke(actual, true, true, true));
        }
    }
}
