using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;
using vec = FunctionalLibrary.Collections.Vector;

namespace FunctionalLibrary.Tests.Core
{
    public class ComplementShould
    {
        [Test]
        public void Complement_should_return_the_complement_of_the_given_function()
        {
            var notEmpty = (Complement.Function)new Complement().Invoke(new IsEmpty());

            Assert.IsFalse((bool)notEmpty.Invoke(vec.EMPTY));
            Assert.IsTrue((bool)notEmpty.Invoke(vec.Create(1, 2)));
        }

        [Test]
        public void Complement_should_return_the_complement_with_muliple_param_for_a_given_function()
        {
            var containsChar = new Function<object, object, object>((s, c) => new Some().Invoke(new Function<object, object>(x => c.Equals(x)), s));

            Assert.IsTrue((bool)containsChar.Invoke("abc", 'b'));
        }
    }
}
