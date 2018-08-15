using funclib.Components.Core.Generic;
using NUnit.Framework;

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
                if ((bool)funclib.Core.IsLessThan(x, 0))
                    return funclib.Core.PrintLn("done");

                return new Function<object>(() => foo.Invoke(
                    funclib.Core.Do(
                        funclib.Core.PrintLn(":x", x),
                        funclib.Core.Dec(x))));
            });

            var actual = funclib.Core.Trampoline(foo, 10);

            Assert.IsNull(actual);
        }
    }
}
