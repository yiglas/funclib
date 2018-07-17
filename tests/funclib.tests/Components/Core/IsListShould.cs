using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsListShould
    {
        [Test]
        public void IsList_should_return_true_if_an_object_is_IList()
        {
            Assert.IsTrue((bool)new IsList().Invoke(new funclib.Components.Core.List().Invoke()));
        }

        [Test]
        public void IsList_should_return_false_if_an_object_is_not_IList()
        {
            Assert.IsFalse((bool)new IsList().Invoke(new Vector().Invoke()));
            Assert.IsFalse((bool)new IsList().Invoke(null));
        }
    }
}
