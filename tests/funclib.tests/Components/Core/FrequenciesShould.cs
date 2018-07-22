using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class FrequenciesShould
    {
        [Test]
        public void Frequencies_should_list_items_and_their_occurances()
        {
            var expected = new HashMap().Invoke('a', 3, 'b', 1);
            var actual = frequencies(new Vector().Invoke('a', 'b', 'a', 'a'));

            Assert.AreEqual(expected, actual);
        }
    }
}
