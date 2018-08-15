using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class FrequenciesShould
    {
        [Test]
        public void Frequencies_should_list_items_and_their_occurances()
        {
            var expected = funclib.Core.HashMap('a', 3, 'b', 1);
            var actual = funclib.Core.Frequencies(funclib.Core.Vector('a', 'b', 'a', 'a'));

            Assert.AreEqual(expected, actual);
        }
    }
}
