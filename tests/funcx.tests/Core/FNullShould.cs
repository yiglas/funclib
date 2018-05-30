using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Core
{
    public class FNullShould
    {
        [Test]
        public void FNull_should_allow_same_number_of_parameters_and_work_the_same_way()
        {
            var sayHelloWithDefaults = fnull(SayHello, "World");

            var actual = sayHelloWithDefaults("sir");

            Assert.AreEqual("Hello sir", actual);
        }

        [Test]
        public void FNull_should_use_defaults_if_null_passed_as_parameter()
        {
            var sayHelloWithDefaults = fnull(SayHello, "World");

            var actual = sayHelloWithDefaults(null);

            Assert.AreEqual("Hello World", actual);
        }

        public string SayHello(string name)
        {
            return $"Hello {name}";
        }
    }
}
