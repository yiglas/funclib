namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        // TODO: add more function to compose
        // TODO: remove the Delegate function
        // TODO: try to constraint T as a Delegate
        
        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<TResult> comp<TResult>(Func<TResult> f) => f;

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<TResult> comp<TG, TResult>(Func<TG, TResult> f, Func<TG> g) => 
            () => 
            f(g());

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="T2">Type of input for function g.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<T2, TResult> comp<TG, T2, TResult>(Func<TG, TResult> f, Func<T2, TG> g) =>
            (T2 x) =>
            f(g(x));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="T2">Type of input for function g.</typeparam>
        /// <typeparam name="T3">Type of 2nd input for function g.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<T2, T3, TResult> comp<TG, T2, T3, TResult>(Func<TG, TResult> f, Func<T2, T3, TG> g) =>
            (T2 x, T3 y) =>
            f(g(x, y));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="T2">Type of input for function g.</typeparam>
        /// <typeparam name="T3">Type of 2nd input for function g.</typeparam>
        /// <typeparam name="T4">Type of 3nd input for function g.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<T2, T3, T4, TResult> comp<TG, T2, T3, T4, TResult>(Func<TG, TResult> f, Func<T2, T3, T4, TG> g) =>
            (T2 x, T3 y, T4 z) =>
            f(g(x, y, z));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="T2">Type of input for function g.</typeparam>
        /// <typeparam name="T3">Type of 2nd input for function g.</typeparam>
        /// <typeparam name="T4">Type of 3nd input for function g.</typeparam>
        /// <typeparam name="T5">Type of 3nd input for function g.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Del<T2, T3, T4, T5, TResult> comp<TG, T2, T3, T4, T5, TResult>(Func<TG, TResult> f, Del<T2, T3, T4, T5, TG> g) =>
            (T2 x, T3 y, T4 z, T5[] args) =>
            f(g(x, y, z, args));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TH">Type of function h's result.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <param name="h">Function 3</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<TResult> comp<TG, TH, TResult>(Func<TG, TResult> f, Func<TH, TG> g, Func<TH> h) =>
            () =>
            f(g(h()));
        
        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TH">Type of function h's result.</typeparam>
        /// <typeparam name="T2">Type of input for function h.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <param name="h">Function 3</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<T2, TResult> comp<TG, TH, T2, TResult>(Func<TG, TResult> f, Func<TH, TG> g, Func<T2, TH> h) =>
            (T2 x) =>
            f(g(h(x)));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TH">Type of function h's result.</typeparam>
        /// <typeparam name="T2">Type of input for function h.</typeparam>
        /// <typeparam name="T3">Type of 2nd input for function h.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <param name="h">Function 3</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<T2, T3, TResult> comp<TG, TH, T2, T3, TResult>(Func<TG, TResult> f, Func<TH, TG> g, Func<T2, T3, TH> h) =>
            (T2 x, T3 y) =>
            f(g(h(x, y)));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TH">Type of function h's result.</typeparam>
        /// <typeparam name="T2">Type of input for function h.</typeparam>
        /// <typeparam name="T3">Type of 2nd input for function h.</typeparam>
        /// <typeparam name="T4">Type of 3nd input for function h.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <param name="h">Function 3</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<T2, T3, T4, TResult> comp<TG, TH, T2, T3, T4, TResult>(Func<TG, TResult> f, Func<TH, TG> g, Func<T2, T3, T4, TH> h) =>
            (T2 x, T3 y, T4 z) =>
            f(g(h(x, y, z)));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TH">Type of function h's result.</typeparam>
        /// <typeparam name="T2">Type of input for function h.</typeparam>
        /// <typeparam name="T3">Type of 2nd input for function h.</typeparam>
        /// <typeparam name="T4">Type of 3nd input for function h.</typeparam>
        /// <typeparam name="T5">Type of 4nd input for function h.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <param name="h">Function 3</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Del<T2, T3, T4, T5, TResult> comp<TG, TH, T2, T3, T4, T5, TResult>(Func<TG, TResult> f, Func<TH, TG> g, Del<T2, T3, T4, T5, TH> h) =>
            (T2 x, T3 y, T4 z, T5[] args) =>
            f(g(h(x, y, z, args)));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TH">Type of function h's result.</typeparam>
        /// <typeparam name="TI">Type of function i's result.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <param name="h">Function 3</param>
        /// <param name="i">Function 4</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<TResult> comp<TG, TH, TI, TResult>(Func<TG, TResult> f, Func<TH, TG> g, Func<TI, TH> h, Func<TI> i) =>
            () =>
            f(g(h(i())));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TH">Type of function h's result.</typeparam>
        /// <typeparam name="TI">Type of function i's result.</typeparam>
        /// <typeparam name="T2">Type of input for function i.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <param name="h">Function 3</param>
        /// <param name="i">Function 4</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<T2, TResult> comp<TG, TH, TI, T2, TResult>(Func<TG, TResult> f, Func<TH, TG> g, Func<TI, TH> h, Func<T2, TI> i) =>
            (T2 x) =>
            f(g(h(i(x))));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TH">Type of function h's result.</typeparam>
        /// <typeparam name="TI">Type of function i's result.</typeparam>
        /// <typeparam name="T2">Type of input for function i.</typeparam>
        /// <typeparam name="T3">Type of 2nd input for function i.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <param name="h">Function 3</param>
        /// <param name="i">Function 4</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<T2, T3, TResult> comp<TG, TH, TI, T2, T3, TResult>(Func<TG, TResult> f, Func<TH, TG> g, Func<TI, TH> h, Func<T2, T3, TI> i) =>
            (T2 x, T3 y) =>
            f(g(h(i(x, y))));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TH">Type of function h's result.</typeparam>
        /// <typeparam name="TI">Type of function i's result.</typeparam>
        /// <typeparam name="T2">Type of input for function i.</typeparam>
        /// <typeparam name="T3">Type of 2nd input for function i.</typeparam>
        /// <typeparam name="T4">Type of 3nd input for function i.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <param name="h">Function 3</param>
        /// <param name="i">Function 4</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Func<T2, T3, T4, TResult> comp<TG, TH, TI, T2, T3, T4, TResult>(Func<TG, TResult> f, Func<TH, TG> g, Func<TI, TH> h, Func<T2, T3, T4, TI> i) =>
            (T2 x, T3 y, T4 z) =>
            f(g(h(i(x, y, z))));

        /// <summary>
        /// Takes a set of functions and returns a fn that is the composition of those fns.
        /// </summary>
        /// <typeparam name="TG">Type of function g's result.</typeparam>
        /// <typeparam name="TH">Type of function h's result.</typeparam>
        /// <typeparam name="TI">Type of function i's result.</typeparam>
        /// <typeparam name="T2">Type of input for function i.</typeparam>
        /// <typeparam name="T3">Type of 2nd input for function i.</typeparam>
        /// <typeparam name="T4">Type of 3nd input for function i.</typeparam>
        /// <typeparam name="T5">Type of 4nd input for function i.</typeparam>
        /// <typeparam name="TResult">Type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="g">Function 2</param>
        /// <param name="h">Function 3</param>
        /// <param name="i">Function 4</param>
        /// <returns>
        /// Returns a fn that is the composition of passed in fns.
        /// </returns>
        public static Del<T2, T3, T4, T5, TResult> comp<TG, TH, TI, T2, T3, T4, T5, TResult>(Func<TG, TResult> f, Func<TH, TG> g, Func<TI, TH> h, Del<T2, T3, T4, T5, TI> i) =>
            (T2 x, T3 y, T4 z, T5[] args) =>
            f(g(h(i(x, y, z, args))));
        
    }
}


