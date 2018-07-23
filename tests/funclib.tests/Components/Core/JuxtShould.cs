using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class JuxtShould
    {
        [Test]
        public void Juxt_should_extract_values_from_a_map()
        {
            var expected = vector('T', 10);
            var actual = ((IFunction<object, object>)juxt(new First(), new Count())).Invoke("This Rocks");

            Assert.AreEqual(expected, actual);
        }
    }
}
