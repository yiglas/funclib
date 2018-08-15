using funclib.Components.Core;
using funclib.Components.Core.Generic;
using funclib.Exceptions;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class FNullShould
    {
        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_one_parameter_for_one_arg()
        {
            var hello = new Function<object, object>(x => funclib.Core.Str("Hello", " ", x));
            var defaults = (FNull.Function)funclib.Core.FNull(hello, "David");

            object obj = null;

            Assert.AreEqual("Hello John", defaults.Invoke("John"));
            Assert.AreEqual("Hello David", defaults.Invoke(null));
            Assert.AreEqual("Hello David", defaults.Invoke(obj));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_one_parameter_for_two_arg()
        {
            var hello = new Function<object, object, object>((x, y) => funclib.Core.Str("Hello", " ", x, " ", y));
            var defaults = (FNull.Function)funclib.Core.FNull(hello, "David");

            Assert.AreEqual("Hello John Smith", defaults.Invoke("John", "Smith"));
            Assert.AreEqual("Hello David Smith", defaults.Invoke(null, "Smith"));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_one_parameter_for_three_arg()
        {
            var hello = new Function<object, object, object, object>((x, y, z) => funclib.Core.Str("Hello", " ", x, " ", y, " ", z));
            var defaults = (FNull.Function)funclib.Core.FNull(hello, "David");

            Assert.AreEqual("Hello John Black Smith", defaults.Invoke("John", "Black", "Smith"));
            Assert.AreEqual("Hello David Black Smith", defaults.Invoke(null, "Black", "Smith"));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_one_parameter_for_X_arg()
        {
            var hello = new FunctionParams<object, object, object, object, object>((x, y, z, rest) => funclib.Core.Apply(new Str(), "Hello", " ", x, " ", y, " ", z, " ", rest));
            var defaults = (FNull.Function)funclib.Core.FNull(hello, "David");

            Assert.AreEqual("Hello John Black Smith 123", defaults.Invoke("John", "Black", "Smith", 1, 2, 3));
            Assert.AreEqual("Hello David Black Smith 123", defaults.Invoke(null, "Black", "Smith", 1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
        }


        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_two_parameter_for_two_arg()
        {
            var hello = new Function<object, object, object>((x, y) => funclib.Core.Str("Hello", " ", x, " ", y));
            var defaults = (FNull.Function)funclib.Core.FNull(hello, "David", "Daniel");

            Assert.AreEqual("Hello John Smith", defaults.Invoke("John", "Smith"));
            Assert.AreEqual("Hello David Smith", defaults.Invoke(null, "Smith"));
            Assert.AreEqual("Hello David Daniel", defaults.Invoke(null, null));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_two_parameter_for_three_arg()
        {
            var hello = new Function<object, object, object, object>((x, y, z) => funclib.Core.Str("Hello", " ", x, " ", y, " ", z));
            var defaults = (FNull.Function)funclib.Core.FNull(hello, "David", "Daniel");

            Assert.AreEqual("Hello John Black Smith", defaults.Invoke("John", "Black", "Smith"));
            Assert.AreEqual("Hello David Black Smith", defaults.Invoke(null, "Black", "Smith"));
            Assert.AreEqual("Hello David Daniel Smith", defaults.Invoke(null, null, "Smith"));
            Assert.AreEqual("Hello John Daniel Smith", defaults.Invoke("John", null, "Smith"));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_two_parameter_for_X_arg()
        {
            var hello = new FunctionParams<object, object, object, object, object>((x, y, z, rest) => funclib.Core.Apply(new Str(), "Hello", " ", x, " ", y, " ", z, " ", rest));
            var defaults = (FNull.Function)funclib.Core.FNull(hello, "David", "Daniel");

            Assert.AreEqual("Hello John Black Smith 123", defaults.Invoke("John", "Black", "Smith", 1, 2, 3));
            Assert.AreEqual("Hello David Black Smith 123", defaults.Invoke(null, "Black", "Smith", 1, 2, 3));
            Assert.AreEqual("Hello David Daniel Smith 123", defaults.Invoke(null, null, "Smith", 1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_three_parameter_for_three_arg()
        {
            var hello = new Function<object, object, object, object>((x, y, z) => funclib.Core.Str("Hello", " ", x, " ", y, " ", z));
            var defaults = (FNull.Function)funclib.Core.FNull(hello, "David", "Daniel", "Johnson");

            Assert.AreEqual("Hello John Black Smith", defaults.Invoke("John", "Black", "Smith"));
            Assert.AreEqual("Hello David Black Smith", defaults.Invoke(null, "Black", "Smith"));
            Assert.AreEqual("Hello David Daniel Johnson", defaults.Invoke(null, null, null));
            Assert.AreEqual("Hello John Daniel Smith", defaults.Invoke("John", null, "Smith"));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_three_parameter_for_X_arg()
        {
            var hello = new FunctionParams<object, object, object, object, object>((x, y, z, rest) => funclib.Core.Apply(new Str(), "Hello", " ", x, " ", y, " ", z, " ", rest));
            var defaults = (FNull.Function)funclib.Core.FNull(hello, "David", "Daniel", "Johnson");

            Assert.AreEqual("Hello John Black Smith 123", defaults.Invoke("John", "Black", "Smith", 1, 2, 3));
            Assert.AreEqual("Hello David Black Smith 123", defaults.Invoke(null, "Black", "Smith", 1, 2, 3));
            Assert.AreEqual("Hello David Daniel Johnson 123", defaults.Invoke(null, null, null, 1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
        }

    }
}
