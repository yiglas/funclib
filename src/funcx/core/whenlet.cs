namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        public static TResult whenlet<T, TResult>(T bindings, Func<T, TResult> body)
        {
            if (truthy(bindings))
                return body(bindings);

            return default;
        }
    }
}
