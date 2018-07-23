using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;


namespace funclib.Tests.Components.Core
{
    public class ComplementShould
    {
        [Test]
        public void Complement_should_return_the_complement_of_the_given_function()
        {
            var notEmpty = (Complement.Function)complement(new IsEmpty());

            Assert.IsFalse((bool)notEmpty.Invoke(new Vector().Invoke()));
            Assert.IsTrue((bool)notEmpty.Invoke(new Vector().Invoke(1, 2)));
        }

        [Test]
        public void Complement_should_return_the_complement_with_muliple_param_for_a_given_function()
        {
            var containsChar = new Function<object, object, object>((s, c) => some(new Function<object, object>(x => c.Equals(x)), s));

            Assert.IsTrue((bool)containsChar.Invoke("abc", 'b'));
        }
    }
}
