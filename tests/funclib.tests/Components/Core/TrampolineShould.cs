using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

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
                if ((bool)isLessThan(x, 0))
                    return printLn("done");

                return new Function<object>(() => foo.Invoke(
                    @do(
                        printLn(":x", x),
                        dec(x))));
            });

            var actual = trampoline(foo, 10);

            Assert.IsNull(actual);
        }
    }
}
