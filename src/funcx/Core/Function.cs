using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Function<TResult> :
        IFunction<TResult>
    {
        readonly Func<TResult> _func;

        public Function(Func<TResult> x)
        {
            this._func = x;
        }

        public TResult Invoke() => this._func();
    }

    public class Function<T1, TResult> :
        IFunction<T1, TResult>
    {
        readonly Func<T1, TResult> _func;

        public Function(Func<T1, TResult> x)
        {
            this._func = x;
        }

        public TResult Invoke(T1 x) => this._func(x);
    }

    public class Function<T1, T2, TResult> :
        IFunction<T1, T2, TResult>
    {
        readonly Func<T1, T2, TResult> _func;

        public Function(Func<T1, T2, TResult> x)
        {
            this._func = x;
        }

        public TResult Invoke(T1 x, T2 y) => this._func(x, y);
    }

    public class Function<T1, T2, T3, TResult> :
        IFunction<T1, T2, T3, TResult>
    {
        readonly Func<T1, T2, T3, TResult> _func;

        public Function(Func<T1, T2, T3, TResult> x)
        {
            this._func = x;
        }

        public TResult Invoke(T1 x, T2 y, T3 z) => this._func(x, y, z);
    }

    public class Function<T1, T2, T3, T4, TResult> :
        IFunction<T1, T2, T3, T4, TResult>
    {
        readonly Func<T1, T2, T3, T4, TResult> _func;

        public Function(Func<T1, T2, T3, T4, TResult> x)
        {
            this._func = x;
        }

        public TResult Invoke(T1 a, T2 b, T3 c, T4 d) => this._func(a, b, c, d);
    }

    public class Function<T1, T2, T3, T4, T5, TResult> :
        IFunction<T1, T2, T3, T4, T5, TResult>
    {
        readonly Func<T1, T2, T3, T4, T5, TResult> _func;

        public Function(Func<T1, T2, T3, T4, T5, TResult> x)
        {
            this._func = x;
        }

        public TResult Invoke(T1 a, T2 b, T3 c, T4 d, T5 e) => this._func(a, b, c, d, e);
    }

    public class FunctionParams<T1, TResult> :
        IFunctionParams<T1, TResult>
    {
        readonly Func<T1[], TResult> _func;

        public FunctionParams(Func<T1[], TResult> x)
        {
            this._func = x;
        }

        public TResult Invoke(params T1[] args) => this._func(args);
    }

    public class FunctionParams<T1, T2, TResult> :
        IFunctionParams<T1, T2, TResult>
    {
        readonly Func<T1, T2[], TResult> _func;

        public FunctionParams(Func<T1, T2[], TResult> x)
        {
            this._func = x;
        }

        public TResult Invoke(T1 x, params T2[] args) => this._func(x, args);
    }

    public class FunctionParams<T1, T2, T3, T4, TResult> :
        IFunctionParams<T1, T2, T3, T4, TResult>
    {
        readonly Func<T1, T2, T3, T4[], TResult> _func;

        public FunctionParams(Func<T1, T2, T3, T4[], TResult> x)
        {
            this._func = x;
        }

        public TResult Invoke(T1 x, T2 y, T3 z, params T4[] args) => this._func(x, y, z, args);
    }
}
