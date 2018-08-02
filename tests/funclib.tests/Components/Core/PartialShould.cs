using funclib.Components.Core;
using funclib.Components.Core.Generic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class PartialShould
    {
        [Test]
        public void Partial_should_apply_a_single_parameter_with_no_params()
        {
            var hundredTimes = partial(new Multiply(), 100);

            Assert.AreEqual(100, ((IFunction<object>)hundredTimes).Invoke());
        }

        [Test]
        public void Partial_should_apply_a_single_parameter_with_one_param()
        {
            var hundredTimes = partial(new Multiply(), 100);

            Assert.AreEqual(500, ((IFunction<object, object>)hundredTimes).Invoke(5));
        }

        [Test]
        public void Partial_should_apply_a_single_parameter_with_two_params()
        {
            var hundredTimes = partial(new Multiply(), 100);

            Assert.AreEqual(2000, ((IFunction<object, object, object>)hundredTimes).Invoke(4, 5));
        }

        [Test]
        public void Partial_should_apply_a_single_parameter_with_three_params()
        {
            var hundredTimes = partial(new Multiply(), 100);

            Assert.AreEqual(12000, ((IFunction<object, object, object, object>)hundredTimes).Invoke(4, 5, 6));
        }

        [Test]
        public void Partial_should_apply_a_single_parameter_with_four_or_more_params()
        {
            var hundredTimes = partial(new Multiply(), 100);

            Assert.AreEqual(84000, ((IFunctionParams<object, object, object, object, object>)hundredTimes).Invoke(4, 5, 6, 7));
        }

        [Test]
        public void Partial_should_apply_two_parameters_with_X_additional()
        {
            var hundredTimes = partial(new Multiply(), 100, 2);

            Assert.AreEqual(1000, ((IFunction<object, object>)hundredTimes).Invoke(5));
        }

        [Test]
        public void Partial_should_apply_three_parameters_with_X_additional()
        {
            var hundredTimes = partial(new Multiply(), 100, 2, 4);

            Assert.AreEqual(4000, ((IFunction<object, object>)hundredTimes).Invoke(5));
        }

        [Test]
        public void Partial_should_apply_four_or_more_parameters_with_X_additional()
        {
            var hundredTimes = partial(new Multiply(), 100, 2, 4, 5);

            Assert.AreEqual(20000, ((IFunction<object, object>)hundredTimes).Invoke(5));
        }
    }
}
