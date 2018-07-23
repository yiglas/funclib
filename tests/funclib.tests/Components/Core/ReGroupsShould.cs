using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ReGroupsShould
    {
        [Test]
        public void ReGroups_should_return_a_vector()
        {
            var phoneNumber = "123-456-789-1234";
            var matcher = new ReMatcher().Invoke(new RePattern().Invoke(@"((\d+)-(\d+))"), phoneNumber);

            reFind(matcher);
            var actual = new ReGroups().Invoke(matcher);

            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
        }
    }
}
