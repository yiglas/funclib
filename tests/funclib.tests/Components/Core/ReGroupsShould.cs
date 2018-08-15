using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ReGroupsShould
    {
        [Test]
        public void ReGroups_should_return_a_vector()
        {
            var phoneNumber = "123-456-789-1234";
            var matcher = funclib.Core.ReMatcher(funclib.Core.RePattern(@"((\d+)-(\d+))"), phoneNumber);

            funclib.Core.ReFind(matcher);
            var actual = funclib.Core.ReGroups(matcher);

            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
        }
    }
}
