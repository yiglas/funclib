namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        public static TResult apply<TResult>(Delegate f, IEnumerable args) => applyInternal1<TResult>(f, args);


        static TResult applyInternal1<TResult>(Delegate f, IEnumerable args) =>
            (TResult)Convert.ChangeType(applyInternal2(f, args), typeof(TResult));

        static object applyInternal2(Delegate f, IEnumerable args)
        {
            switch (count(args))
            {
                case 0:
                    args = null;
                    return f.DynamicInvoke();
                case 1:
                    return f.DynamicInvoke(ret1(first(args), args = null));
                case 2:
                    return f.DynamicInvoke(
                        first(args),
                        ret1(first(args = next(args)), args = null));
                case 3:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 4:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 5:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 6:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 7:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 8:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 9:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 10:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 11:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 12:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 13:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 14:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 15:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 16:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 17:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 18:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 19:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                case 20:
                    return f.DynamicInvoke(
                        first(args),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        first(args = next(args)),
                        ret1(first(args = next(args)), args = null));
                default:
                    throw new InvalidOperationException("Max arity hit");
            }

            object ret1(object ret, object @null) => ret;
        }
    }
}
