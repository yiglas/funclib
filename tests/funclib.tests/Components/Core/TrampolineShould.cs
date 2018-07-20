using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class TrampolineShould
    {
        [Test]
        public void Trampoline_should_process_Function()
        {
            IFunction<object, object> foo = null;
            foo = new Function<object, object>(x =>
            {
                if ((bool)new IsLessThan().Invoke(x, 0))
                    return new PrintLn().Invoke("done");

                return new Function<object>(() => foo.Invoke(
                    new Do().Invoke(
                        new PrintLn().Invoke(":x", x),
                        new Dec().Invoke(x))));
            });

            var actual = new Trampoline().Invoke(foo, 10);

            Assert.IsNull(actual);
        }
    }
}
