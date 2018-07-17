using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class ComparatorShould
    {
        [Test]
        public void Comparator_should_return_a_function_that_takes_two_parameters()
        {
            var actual = new Comparator().Invoke(new Function<object, object, object>((x, y) => (int)x > (int)y));

            Assert.IsInstanceOf<IFunction<object, object, object>>(actual);
        }

        [Test]
        public void Comparator_should_return_negative_one_if_pred_returns_true()
        {
            var expected = -1;
            var actual = (IFunction<object, object, object>)new Comparator().Invoke(new Function<object, object, object>((x, y) => (int)x > (int)y));

            Assert.AreEqual(expected, actual.Invoke(3, 2));
        }

        [Test]
        public void Comparator_should_return_one_if_pred_returns_true_with_flopped_parameters()
        {
            var expected = 1;
            var actual = (IFunction<object, object, object>)new Comparator().Invoke(new Function<object, object, object>((x, y) => (int)x > (int)y));

            Assert.AreEqual(expected, actual.Invoke(2, 3));
        }

        [Test]
        public void Comparator_should_return_zero_if_pred_returns_true_with_parameters_are_equal()
        {
            var expected = 0;
            var actual = (IFunction<object, object, object>)new Comparator().Invoke(new Function<object, object, object>((x, y) => (int)x > (int)y));

            Assert.AreEqual(expected, actual.Invoke(2, 2));
        }
    }
}
