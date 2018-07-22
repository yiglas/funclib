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
            Assert.IsTrue((bool)isAssociative(hashMap()));
            Assert.IsTrue((bool)isAssociative(arrayMap()));
        }

        [Test]
        public void IsAssociative_should_return_false_if_an_object_doesnot_implement_IAssociative()
        {
            Assert.IsFalse((bool)isAssociative(1));
            Assert.IsFalse((bool)isAssociative(null));
        }
    }
}