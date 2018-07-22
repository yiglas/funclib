using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsAssociativeShould
    {
        [Test]
        public void IsAssociative_should_return_true_if_an_object_that_implements_IAssociative()
        {
            Assert.IsTrue((bool)new IsAssociative().Invoke(hashMap()));
            Assert.IsTrue((bool)new IsAssociative().Invoke(arrayMap()));
        }

        [Test]
        public void IsAssociative_should_return_false_if_an_object_doesnot_implement_IAssociative()
        {
            Assert.IsFalse((bool)new IsAssociative().Invoke(1));
            Assert.IsFalse((bool)new IsAssociative().Invoke(null));
        }
    }
}