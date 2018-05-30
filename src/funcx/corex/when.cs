namespace FunctionalLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        public static TResult when<T, TResult>(T test, Func<TResult> body)
        {
            if (truthy(test))
                return body();

            return default;
        }
    }
}
