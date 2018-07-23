using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsListShould
    {
        [Test]
        public void IsList_should_return_true_if_an_object_is_IList()
        {
            Assert.IsTrue((bool)isList(list()));
        }

        [Test]
        public void IsList_should_return_false_if_an_object_is_not_IList()
        {
            Assert.IsFalse((bool)isList(vector()));
            Assert.IsFalse((bool)isList(null));
        }
    }
}
