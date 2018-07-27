using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class ReGroupsShould
    {
        [Test]
        public void ReGroups_should_return_a_vector()
        {
            var phoneNumber = "123-456-789-1234";
            var matcher = reMatcher(rePattern(@"((\d+)-(\d+))"), phoneNumber);

            reFind(matcher);
            var actual = reGroups(matcher);

            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
        }
    }
}
