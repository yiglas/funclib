namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        public static TResult whensome<T, TResult>(T bindings, Func<T, TResult> body)
        {
            if (!isnull(bindings))
                return body(bindings);

            return default;
        }
    }
}
