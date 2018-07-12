using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class TreeSeqShould
    {
        [Test]
        public void TreeSeq_should_return_each()
        {
            var list = new FunctionalLibrary.Core.List();

            var expected = list.Invoke(":a", ":b", ":d", ":e", ":c", ":f");

            var tree = list.Invoke(":a", list.Invoke(":b", list.Invoke(":d"), list.Invoke(":e")), list.Invoke(":c", list.Invoke(":f")));
            var actual = new ToArray().Invoke(new Map().Invoke(new First(), new TreeSeq().Invoke(new Next(), new Rest(), tree)));

            Assert.AreEqual(expected, actual);
        }
    }
}
