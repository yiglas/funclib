using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class ConstantlyShould
    {
        [Test]
        public void Constantly_should_return_a_function_that_takes_any_number_of_parameters()
        {
            var actual = new Constantly().Invoke(10);

            Assert.IsInstanceOf<IFunctionParams>(actual);
        }

        [Test]
        public void Constantly_should_return_x_when_invoked()
        {
            var expected = 10;
            var actual = ((IFunctionParams<object, object>)new Constantly().Invoke(10)).Invoke(1, 2, 3);

            Assert.AreEqual(expected, actual);
        }
    }
}
