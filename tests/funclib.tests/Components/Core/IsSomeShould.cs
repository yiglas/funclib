using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsSomeShould
    {
        [Test]
        public void IsSome_should_return_true_if_not_null()
        {
            Assert.IsTrue((bool)new IsSome().Invoke(1));
            Assert.IsTrue((bool)new IsSome().Invoke(false));
            Assert.IsTrue((bool)new IsSome().Invoke(new Vector().Invoke(1, 2, 3)));
        }

        [Test]
        public void IsSome_should_return_false_if_is_null()
        {
            Assert.IsFalse((bool)new IsSome().Invoke(null));
        }
    }
}
