namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        public static TResult whennot<T, TResult>(T test, Func<T, TResult> body)
        {
            if (!truthy(test))
                return body(test);

            return default;
        }
    }
}
