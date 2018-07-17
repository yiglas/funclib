using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Creates a <see cref="Function{TResult}"/> from a <see cref="Func{TResult}"/>.
    /// </summary>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class Function<TResult> :
        IFunction<TResult>
    {
        readonly Func<TResult> _func;

        /// <summary>
        /// Creates a <see cref="Function{TResult}"/> from a <see cref="Func{TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{TResult}"/> to execute.</param>
        public Function(Func<TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{TResult}"/>.
        /// </summary>
        /// <returns>
        /// Returns the results of the <see cref="Func{TResult}"/> function.
        /// </returns>
        public TResult Invoke() => this._func();
    }

    /// <summary>
    /// Creates a <see cref="Function{T1, TResult}"/> from a <see cref="Func{T1, TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">Generic type of the input object.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class Function<T1, TResult> :
        IFunction<T1, TResult>
    {
        readonly Func<T1, TResult> _func;

        /// <summary>
        /// Creates a <see cref="Function{T1, TResult}"/> from a <see cref="Func{T1, TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, TResult}"/> to execute.</param>
        public Function(Func<T1, TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, TResult}"/>.
        /// </summary>
        /// <param name="x">First parameter of the function.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 x) => this._func(x);
    }

    /// <summary>
    /// Creates a <see cref="Function{T1, T2, TResult}"/> from a <see cref="Func{T1, T2, TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">Generic type of the first input object.</typeparam>
    /// <typeparam name="T2">Generic type of the second input object.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class Function<T1, T2, TResult> :
        IFunction<T1, T2, TResult>
    {
        readonly Func<T1, T2, TResult> _func;

        /// <summary>
        /// Creates a <see cref="Function{T1, T2, TResult}"/> from a <see cref="Func{T1, T2, TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, T2, TResult}"/> to execute.</param>
        public Function(Func<T1, T2, TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, T2, TResult}"/>.
        /// </summary>
        /// <param name="x">First parameter of the function.</param>
        /// <param name="y">Second parameter of the function.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, T2, TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 x, T2 y) => this._func(x, y);
    }

    /// <summary>
    /// Creates a <see cref="Function{T1, T2, T3, TResult}"/> from a <see cref="Func{T1, T2, T3, TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">Generic type of the first input object.</typeparam>
    /// <typeparam name="T2">Generic type of the second input object.</typeparam>
    /// <typeparam name="T3">Generic type of the third input object.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class Function<T1, T2, T3, TResult> :
        IFunction<T1, T2, T3, TResult>
    {
        readonly Func<T1, T2, T3, TResult> _func;

        /// <summary>
        /// Creates a <see cref="Function{T1, T2, T3, TResult}"/> from a <see cref="Func{T1, T2, T3, TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, T2, T3, TResult}"/> to execute.</param>
        public Function(Func<T1, T2, T3, TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, T2, T3, TResult}"/>.
        /// </summary>
        /// <param name="x">First parameter of the function.</param>
        /// <param name="y">Second parameter of the function.</param>
        /// <param name="z">Third parameter of the function.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, T2, T3, TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 x, T2 y, T3 z) => this._func(x, y, z);
    }

    /// <summary>
    /// Creates a <see cref="Function{T1, T2, T3, T4, TResult}"/> from a <see cref="Func{T1, T2, T3, T4, TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">Generic type of the first input object.</typeparam>
    /// <typeparam name="T2">Generic type of the second input object.</typeparam>
    /// <typeparam name="T3">Generic type of the third input object.</typeparam>
    /// <typeparam name="T4">Generic type of the fourth input object.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class Function<T1, T2, T3, T4, TResult> :
        IFunction<T1, T2, T3, T4, TResult>
    {
        readonly Func<T1, T2, T3, T4, TResult> _func;

        /// <summary>
        /// Creates a <see cref="Function{T1, T2, T3, T4, TResult}"/> from a <see cref="Func{T1, T2, T3, T4, TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, T2, T3, T4, TResult}"/> to execute.</param>
        public Function(Func<T1, T2, T3, T4, TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, T2, T3, T4, TResult}"/>.
        /// </summary>
        /// <param name="a">First parameter of the function.</param>
        /// <param name="b">Second parameter of the function.</param>
        /// <param name="c">Third parameter of the function.</param>
        /// <param name="d">Fourth parameter of the function.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, T2, T3, T4, TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 a, T2 b, T3 c, T4 d) => this._func(a, b, c, d);
    }

    /// <summary>
    /// Creates a <see cref="Function{T1, T2, T3, T4, T5, TResult}"/> from a <see cref="Func{T1, T2, T3, T4, T5, TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">Generic type of the first input object.</typeparam>
    /// <typeparam name="T2">Generic type of the second input object.</typeparam>
    /// <typeparam name="T3">Generic type of the third input object.</typeparam>
    /// <typeparam name="T4">Generic type of the fourth input object.</typeparam>
    /// <typeparam name="T5">Generic type of the fifth input object.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class Function<T1, T2, T3, T4, T5, TResult> :
        IFunction<T1, T2, T3, T4, T5, TResult>
    {
        readonly Func<T1, T2, T3, T4, T5, TResult> _func;

        /// <summary>
        /// Creates a <see cref="Function{T1, T2, T3, T4, T5, TResult}"/> from a <see cref="Func{T1, T2, T3, T4, T5, TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, T2, T3, T4, T5, TResult}"/> to execute.</param>
        public Function(Func<T1, T2, T3, T4, T5, TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, T2, T3, T4, TResult}"/>.
        /// </summary>
        /// <param name="a">First parameter of the function.</param>
        /// <param name="b">Second parameter of the function.</param>
        /// <param name="c">Third parameter of the function.</param>
        /// <param name="d">Fourth parameter of the function.</param>
        /// <param name="e">Fifth parameter of the function.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, T2, T3, T4, T5, TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 a, T2 b, T3 c, T4 d, T5 e) => this._func(a, b, c, d, e);
    }

    /// <summary>
    /// Creates a <see cref="FunctionParams{T1, TResult}"/> from a <see cref="Func{T1[], TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">Generic type of the parameter array.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class FunctionParams<T1, TResult> :
        IFunctionParams<T1, TResult>
    {
        readonly Func<T1[], TResult> _func;

        /// <summary>
        /// Creates a <see cref="FunctionParams{T1, TResult}"/> from a <see cref="Func{T1[], TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1[], TResult}"/> to execute.</param>
        public FunctionParams(Func<T1[], TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1[], TResult}"/>.
        /// </summary>
        /// <param name="args">Array of parameters of the function.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1[], TResult}"/> function.
        /// </returns>
        public TResult Invoke(params T1[] args) => this._func(args);
    }

    /// <summary>
    /// Creates a <see cref="FunctionParams{T1, T2, TResult}"/> from a <see cref="Func{T1, T2[], TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">First parameter of the function.</typeparam>
    /// <typeparam name="T2">Generic type of the rest of the parameters.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class FunctionParams<T1, T2, TResult> :
        IFunctionParams<T1, T2, TResult>
    {
        readonly Func<T1, T2[], TResult> _func;

        /// <summary>
        /// Creates a <see cref="FunctionParams{T1, T2, TResult}"/> from a <see cref="Func{T1, T2[], TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, T2[], TResult}"/> to execute.</param>
        public FunctionParams(Func<T1, T2[], TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, T2[], TResult}"/>.
        /// </summary>
        /// <param name="x">First parameter of the function.</param>
        /// <param name="args">Array of parameters.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, T2[], TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 x, params T2[] args) => this._func(x, args);
    }

    /// <summary>
    /// Creates a <see cref="FunctionParams{T1, T2, T3, TResult}"/> from a <see cref="Func{T1, T2, T3[], TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">First parameter of the function.</typeparam>
    /// <typeparam name="T2">Second parameter of the function.</typeparam>
    /// <typeparam name="T3">Generic type of the rest of the parameters.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class FunctionParams<T1, T2, T3, TResult> :
        IFunctionParams<T1, T2, T3, TResult>
    {
        readonly Func<T1, T2, T3[], TResult> _func;

        /// <summary>
        /// Creates a <see cref="FunctionParams{T1, T2, T3, TResult}"/> from a <see cref="Func{T1, T2, T3[], TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, T2, T3[], TResult}"/> to execute.</param>
        public FunctionParams(Func<T1, T2, T3[], TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, T2, T3[], TResult}"/>.
        /// </summary>
        /// <param name="x">First parameter of the function.</param>
        /// <param name="y">Second parameter of the function.</param>
        /// <param name="args">Array of parameters.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, T2, T3[], TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 x, T2 y, params T3[] args) => this._func(x, y, args);
    }

    /// <summary>
    /// Creates a <see cref="FunctionParams{T1, T2, T3, T4, TResult}"/> from a <see cref="Func{T1, T2, T3, T4[], TResult}"/>.
    /// </summary>
    /// <typeparam name="T1">First parameter of the function.</typeparam>
    /// <typeparam name="T2">Second parameter of the function.</typeparam>
    /// <typeparam name="T3">Third parameter of the function.</typeparam>
    /// <typeparam name="T4">Generic type of the rest of the parameters.</typeparam>
    /// <typeparam name="TResult">Generic type of the return object.</typeparam>
    public class FunctionParams<T1, T2, T3, T4, TResult> :
        IFunctionParams<T1, T2, T3, T4, TResult>
    {
        readonly Func<T1, T2, T3, T4[], TResult> _func;

        /// <summary>
        /// Creates a <see cref="FunctionParams{T1, T2, T3, T4, TResult}"/> from a <see cref="Func{T1, T2, T3, T4[], TResult}"/>.
        /// </summary>
        /// <param name="x">A <see cref="Func{T1, T2, T3, T4[], TResult}"/> to execute.</param>
        public FunctionParams(Func<T1, T2, T3, T4[], TResult> x)
        {
            this._func = x;
        }

        /// <summary>
        /// Invokes the <see cref="Func{T1, T2, T3, T4[], TResult}"/>.
        /// </summary>
        /// <param name="x">First parameter of the function.</param>
        /// <param name="y">Second parameter of the function.</param>
        /// <param name="z">Third parameter of the function.</param>
        /// <param name="args">Array of parameters.</param>
        /// <returns>
        /// Returns the results of the <see cref="Func{T1, T2, T3, T4[], TResult}"/> function.
        /// </returns>
        public TResult Invoke(T1 x, T2 y, T3 z, params T4[] args) => this._func(x, y, z, args);
    }
}
