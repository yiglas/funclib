using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class RepeatedlyShould
    {
        [Test]
        public void Repeatedly_should_return_an_lazyseq()
        {
            var actual = new Repeatedly().Invoke(new Function<object>(() => new RandInt().Invoke(11)));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Repeatedly_should_be_able_to_pass_to_the_take_function()
        {
            var l = new System.Collections.Generic.List<int>();

            var actual = new ToArray().Invoke(new Take().Invoke(5, new Repeatedly().Invoke(new Function<object>(() => { l.Add(1); return null; }))));

            Assert.AreEqual(5, l.Count);
        }

        [Test]
        public void Repeatedly_should_run_only_the_length_passed()
        {
            var l = new System.Collections.Generic.List<int>();

            var actual = new ToArray().Invoke(new Repeatedly().Invoke(5, new Function<object>(() => { l.Add(1); return null; })));

            Assert.AreEqual(5, l.Count);
        }
    }
}
