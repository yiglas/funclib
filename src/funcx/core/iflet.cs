namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        public static TResult iflet<T1, TResult>(ValueTuple<T1> bindings, Func<ValueTuple<T1>, TResult> then, Func<TResult> @else = null) =>
            truthy(bindings.Item1)
                ? then(bindings)
                : @else == null ? @else() : default;
    }
}
