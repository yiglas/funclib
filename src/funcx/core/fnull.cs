using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class FNull<T1, TResult> :
        IFunction<IFunction<T1, TResult>, T1, IFunction<T1, TResult>>
    {
        public IFunction<T1, TResult> Invoke(IFunction<T1, TResult> f, T1 x) =>
            f == null
                ? null
                : new Function<T1, TResult>(a => f.Invoke(a == null ? x : a));
    }

    public class FNull<T1, T2, TResult> :
        IFunction<IFunction<T1, T2, TResult>, T1, IFunction<T1, T2, TResult>>,
        IFunction<IFunction<T1, T2, TResult>, T1, T2, IFunction<T1, T2, TResult>>
    {
        public IFunction<T1, T2, TResult> Invoke(IFunction<T1, T2, TResult> f, T1 x) =>
            f == null
                ? null
                : new Function<T1, T2, TResult>((a, b) => f.Invoke(a == null ? x : a, b));

        public IFunction<T1, T2, TResult> Invoke(IFunction<T1, T2, TResult> f, T1 x, T2 y) =>
            f == null
                ? null
                : new Function<T1, T2, TResult>((a, b) => f.Invoke(a == null ? x : a, b == null ? y : b));

    }

    public class FNull<T1, T2, T3, TResult> :
        IFunction<IFunction<T1, T2, T3, TResult>, T1, IFunction<T1, T2, T3, TResult>>,
        IFunction<IFunction<T1, T2, T3, TResult>, T1, T2, IFunction<T1, T2, T3, TResult>>,
        IFunction<IFunction<T1, T2, T3, TResult>, T1, T2, T3, IFunction<T1, T2, T3, TResult>>
    {
        public IFunction<T1, T2, T3, TResult> Invoke(IFunction<T1, T2, T3, TResult> f, T1 x) =>
            f == null
                ? null
                : new Function<T1, T2, T3, TResult>((a, b, c) => f.Invoke(a == null ? x : a, b, c));

        public IFunction<T1, T2, T3, TResult> Invoke(IFunction<T1, T2, T3, TResult> f, T1 x, T2 y) =>
            f == null
                ? null
                : new Function<T1, T2, T3, TResult>((a, b, c) => f.Invoke(a == null ? x : a, b == null ? y : b, c));
        
        public IFunction<T1, T2, T3, TResult> Invoke(IFunction<T1, T2, T3, TResult> f, T1 x, T2 y, T3 z) =>
            f == null
                ? null
                : new Function<T1, T2, T3, TResult>((a, b, c) => f.Invoke(a == null ? x : a, b == null ? y : b, c == null ? z : c));
    }

    public class FNull<T1, T2, T3, T4, TResult> :
        IFunction<IFunctionParams<T1, T2, T3, T4, TResult>, T1, IFunctionParams<T1, T2, T3, T4, TResult>>,
        IFunction<IFunctionParams<T1, T2, T3, T4, TResult>, T1, T2, IFunctionParams<T1, T2, T3, T4, TResult>>,
        IFunction<IFunctionParams<T1, T2, T3, T4, TResult>, T1, T2, T3, IFunctionParams<T1, T2, T3, T4, TResult>>
    {
        public IFunctionParams<T1, T2, T3, T4, TResult> Invoke(IFunctionParams<T1, T2, T3, T4, TResult> f, T1 x) =>
            f == null
                ? null
                : new FunctionParams<T1, T2, T3, T4, TResult>((a, b, c, ds) => f.Invoke(a == null ? x : a, b, c, ds));

        public IFunctionParams<T1, T2, T3, T4, TResult> Invoke(IFunctionParams<T1, T2, T3, T4, TResult> f, T1 x, T2 y) =>
            f == null
                ? null
                : new FunctionParams<T1, T2, T3, T4, TResult>((a, b, c, ds) => f.Invoke(a == null ? x : a, b == null ? y : b, c, ds));

        public IFunctionParams<T1, T2, T3, T4, TResult> Invoke(IFunctionParams<T1, T2, T3, T4, TResult> f, T1 x, T2 y, T3 z) =>
            f == null
                ? null
                : new FunctionParams<T1, T2, T3, T4, TResult>((a, b, c, ds) => f.Invoke(a == null ? x : a, b == null ? y : b, c == null ? z : c, ds));
    }
}
