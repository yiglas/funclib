using funclib.Components.Core;
using funclib.Exceptions;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class FNullShould
    {
        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_one_parameter_for_one_arg()
        {
            var hello = new Function<object, object>(x => new Str().Invoke("Hello", " ", x));
            var defaults = (FNull.Function)fnull(hello, "Devin");

            object obj = null;

            Assert.AreEqual("Hello John", defaults.Invoke("John"));
            Assert.AreEqual("Hello Devin", defaults.Invoke(null));
            Assert.AreEqual("Hello Devin", defaults.Invoke(obj));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_one_parameter_for_two_arg()
        {
            var hello = new Function<object, object, object>((x, y) => new Str().Invoke("Hello", " ", x, " ", y));
            var defaults = (FNull.Function)fnull(hello, "Devin");

            Assert.AreEqual("Hello John Smith", defaults.Invoke("John", "Smith"));
            Assert.AreEqual("Hello Devin Smith", defaults.Invoke(null, "Smith"));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_one_parameter_for_three_arg()
        {
            var hello = new Function<object, object, object, object>((x, y, z) => new Str().Invoke("Hello", " ", x, " ", y, " ", z));
            var defaults = (FNull.Function)fnull(hello, "Devin");

            Assert.AreEqual("Hello John Black Smith", defaults.Invoke("John", "Black", "Smith"));
            Assert.AreEqual("Hello Devin Black Smith", defaults.Invoke(null, "Black", "Smith"));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_one_parameter_for_X_arg()
        {
            var hello = new FunctionParams<object, object, object, object, object>((x, y, z, rest) => apply(new Str(), "Hello", " ", x, " ", y, " ", z, " ", rest));
            var defaults = (FNull.Function)fnull(hello, "Devin");

            Assert.AreEqual("Hello John Black Smith 123", defaults.Invoke("John", "Black", "Smith", 1, 2, 3));
            Assert.AreEqual("Hello Devin Black Smith 123", defaults.Invoke(null, "Black", "Smith", 1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
        }


        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_two_parameter_for_two_arg()
        {
            var hello = new Function<object, object, object>((x, y) => new Str().Invoke("Hello", " ", x, " ", y));
            var defaults = (FNull.Function)fnull(hello, "Devin", "Daniel");

            Assert.AreEqual("Hello John Smith", defaults.Invoke("John", "Smith"));
            Assert.AreEqual("Hello Devin Smith", defaults.Invoke(null, "Smith"));
            Assert.AreEqual("Hello Devin Daniel", defaults.Invoke(null, null));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_two_parameter_for_three_arg()
        {
            var hello = new Function<object, object, object, object>((x, y, z) => new Str().Invoke("Hello", " ", x, " ", y, " ", z));
            var defaults = (FNull.Function)fnull(hello, "Devin", "Daniel");

            Assert.AreEqual("Hello John Black Smith", defaults.Invoke("John", "Black", "Smith"));
            Assert.AreEqual("Hello Devin Black Smith", defaults.Invoke(null, "Black", "Smith"));
            Assert.AreEqual("Hello Devin Daniel Smith", defaults.Invoke(null, null, "Smith"));
            Assert.AreEqual("Hello John Daniel Smith", defaults.Invoke("John", null, "Smith"));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_two_parameter_for_X_arg()
        {
            var hello = new FunctionParams<object, object, object, object, object>((x, y, z, rest) => apply(new Str(), "Hello", " ", x, " ", y, " ", z, " ", rest));
            var defaults = (FNull.Function)fnull(hello, "Devin", "Daniel");

            Assert.AreEqual("Hello John Black Smith 123", defaults.Invoke("John", "Black", "Smith", 1, 2, 3));
            Assert.AreEqual("Hello Devin Black Smith 123", defaults.Invoke(null, "Black", "Smith", 1, 2, 3));
            Assert.AreEqual("Hello Devin Daniel Smith 123", defaults.Invoke(null, null, "Smith", 1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_three_parameter_for_three_arg()
        {
            var hello = new Function<object, object, object, object>((x, y, z) => new Str().Invoke("Hello", " ", x, " ", y, " ", z));
            var defaults = (FNull.Function)fnull(hello, "Devin", "Daniel", "Sackett");

            Assert.AreEqual("Hello John Black Smith", defaults.Invoke("John", "Black", "Smith"));
            Assert.AreEqual("Hello Devin Black Smith", defaults.Invoke(null, "Black", "Smith"));
            Assert.AreEqual("Hello Devin Daniel Sackett", defaults.Invoke(null, null, null));
            Assert.AreEqual("Hello John Daniel Smith", defaults.Invoke("John", null, "Smith"));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3, 4));
        }

        [Test]
        public void FNull_should_create_another_function_with_defaults_passing_three_parameter_for_X_arg()
        {
            var hello = new FunctionParams<object, object, object, object, object>((x, y, z, rest) => apply(new Str(), "Hello", " ", x, " ", y, " ", z, " ", rest));
            var defaults = (FNull.Function)fnull(hello, "Devin", "Daniel", "Sackett");

            Assert.AreEqual("Hello John Black Smith 123", defaults.Invoke("John", "Black", "Smith", 1, 2, 3));
            Assert.AreEqual("Hello Devin Black Smith 123", defaults.Invoke(null, "Black", "Smith", 1, 2, 3));
            Assert.AreEqual("Hello Devin Daniel Sackett 123", defaults.Invoke(null, null, null, 1, 2, 3));
            Assert.Throws<ArityException>(() => defaults.Invoke(1));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2));
            Assert.Throws<ArityException>(() => defaults.Invoke(1, 2, 3));
        }

    }
}
