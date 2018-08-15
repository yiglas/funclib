using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class JuxtShould
    {
        [Test]
        public void Juxt_should_extract_values_from_a_map()
        {
            var expected = funclib.Core.Vector('T', 10);
            var actual = funclib.Core.Invoke(funclib.Core.Juxt(funclib.Core.first, funclib.Core.count), "This Rocks");

            Assert.AreEqual(expected, actual);
        }
    }
}
