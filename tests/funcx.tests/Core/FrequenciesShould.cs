using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class FrequenciesShould
    {
        [Test]
        public void Frequencies_should_list_items_and_their_occurances()
        {
            var expected = new HashMap().Invoke('a', 3, 'b', 1);
            var actual = new Frequencies().Invoke(new Vector().Invoke('a', 'b', 'a', 'a'));

            Assert.AreEqual(expected, actual);
        }
    }
}
