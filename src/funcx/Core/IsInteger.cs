using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsInteger :
        IFunction<object, object>
    {
        public object Invoke(object n) =>
            new Or().Invoke(
                new Function<object>(() => n is Int32),
                new Function<object>(() => n is Int64),
                new Function<object>(() => n is Int16),
                new Function<object>(() => n is UInt32),
                new Function<object>(() => n is UInt64),
                new Function<object>(() => n is UInt16),
                new Function<object>(() => n is Char),
                new Function<object>(() => n is Byte),
                new Function<object>(() => n is SByte));
    }
}
