using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class TreeSeqShould
    {
        [Test]
        public void TreeSeq_should_return_each()
        {
            var list = new funclib.Components.Core.List();

            var expected = funclib.Core.List(":a", ":b", ":d", ":e", ":c", ":f");

            var tree = funclib.Core.List(":a", funclib.Core.List(":b", funclib.Core.List(":d"), funclib.Core.List(":e")), funclib.Core.List(":c", funclib.Core.List(":f")));
            var actual = funclib.Core.ToArray(funclib.Core.Map(new First(), funclib.Core.TreeSeq(new Next(), new Rest(), tree)));

            Assert.AreEqual(expected, actual);
        }
    }
}
