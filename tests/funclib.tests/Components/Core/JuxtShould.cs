using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class JuxtShould
    {
        [Test]
        public void Juxt_should_extract_values_from_a_map()
        {
            var expected = new Vector().Invoke('T', 10);
            var actual = ((IFunction<object, object>)new Juxt().Invoke(new First(), new Count())).Invoke("This Rocks");

            Assert.AreEqual(expected, actual);
        }
    }
}
