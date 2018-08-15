using funclib.Components.Core.Generic;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ConstantlyShould
    {
        [Test]
        public void Constantly_should_return_a_function_that_takes_any_number_of_parameters()
        {
            var actual = funclib.Core.Constantly(10);

            Assert.IsInstanceOf<IFunctionParams>(actual);
        }

        [Test]
        public void Constantly_should_return_x_when_invoked()
        {
            var expected = 10;
            var actual = ((IFunctionParams<object, object>)funclib.Core.Constantly(10)).Invoke(1, 2, 3);

            Assert.AreEqual(expected, actual);
        }
    }
}
