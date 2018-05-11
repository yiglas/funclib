namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static partial class core
    {
        // TODO: remove the Delegate function

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="f">Function 1</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<TResult> partial<TResult>(Func<TResult> f) => f;

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<TResult> partial<TArg1, TResult>(Func<TArg1, TResult> f, TArg1 arg1) =>
            () =>
            f(arg1);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="T2">The type of the 2nd argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<T2, TResult> partial<TArg1, T2, TResult>(Func<TArg1, T2, TResult> f, TArg1 arg1) =>
            (T2 x) =>
            f(arg1, x);
        
        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="T2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="T3">The type of the 3nd argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<T2, T3, TResult> partial<TArg1, T2, T3, TResult>(Func<TArg1, T2, T3, TResult> f, TArg1 arg1) =>
            (T2 x, T3 y) =>
            f(arg1, x, y);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="T2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="T3">The type of the 3nd argument.</typeparam>
        /// <typeparam name="T4">The type of the 4nd argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<T2, T3, T4, TResult> partial<TArg1, T2, T3, T4, TResult>(Func<TArg1, T2, T3, T4, TResult> f, TArg1 arg1) =>
            (T2 x, T3 y, T4 z) =>
            f(arg1, x, y, z);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="T2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="T3">The type of the 3nd argument.</typeparam>
        /// <typeparam name="T4">The type of the 4nd argument.</typeparam>
        /// <typeparam name="T5">The type of the 5nd argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Del<T2, T3, T4, T5, TResult> partial<TArg1, T2, T3, T4, T5, TResult>(Del<TArg1, T2, T3, T4, T5, TResult> f, TArg1 arg1) =>
            (T2 x, T3 y, T4 z, T5[] args) =>
            f(arg1, x, y, z, args);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="TArg2">The type of the 2st argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<TResult> partial<TArg1, TArg2, TResult>(Func<TArg1, TArg2, TResult> f, TArg1 arg1, TArg2 arg2) =>
            () =>
            f(arg1, arg2);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="TArg2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="T2">The type of the 3rd argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<T2, TResult> partial<TArg1, TArg2, T2, TResult>(Func<TArg1, TArg2, T2, TResult> f, TArg1 arg1, TArg2 arg2) =>
            (T2 x) =>
            f(arg1, arg2, x);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="TArg2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="T2">The type of the 3rd argument.</typeparam>
        /// <typeparam name="T3">The type of the 4th argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<T2, T3, TResult> partial<TArg1, TArg2, T2, T3, TResult>(Func<TArg1, TArg2, T2, T3, TResult> f, TArg1 arg1, TArg2 arg2) =>
            (T2 x, T3 y) =>
            f(arg1, arg2, x, y);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="TArg2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="T2">The type of the 3rd argument.</typeparam>
        /// <typeparam name="T3">The type of the 4th argument.</typeparam>
        /// <typeparam name="T4">The type of the 5th argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<T2, T3, T4, TResult> partial<TArg1, TArg2, T2, T3, T4, TResult>(Func<TArg1, TArg2, T2, T3, T4, TResult> f, TArg1 arg1, TArg2 arg2) =>
            (T2 x, T3 y, T4 z) =>
            f(arg1, arg2, x, y, z);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="TArg2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="T2">The type of the 3rd argument.</typeparam>
        /// <typeparam name="T3">The type of the 4th argument.</typeparam>
        /// <typeparam name="T4">The type of the 5th argument.</typeparam>
        /// <typeparam name="T5">The type of the 6th argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Del<T2, T3, T4, T5, TResult> partial<TArg1, TArg2, T2, T3, T4, T5, TResult>(Del<TArg1, TArg2, T2, T3, T4, T5, TResult> f, TArg1 arg1, TArg2 arg2) =>
            (T2 x, T3 y, T4 z, T5[] args) =>
            f(arg1, arg2, x, y, z, args);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="TArg2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="TArg3">The type of the 3rd argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <param name="arg3">Argument 3</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<TResult> partial<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, TResult> f, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
            () =>
            f(arg1, arg2, arg3);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="TArg2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="TArg3">The type of the 3rd argument.</typeparam>
        /// <typeparam name="T2">The type of the 4th argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <param name="arg3">Argument 3</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<T2, TResult> partial<TArg1, TArg2, TArg3, T2, TResult>(Func<TArg1, TArg2, TArg3, T2, TResult> f, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
            (T2 x) =>
            f(arg1, arg2, arg3, x);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="TArg2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="TArg3">The type of the 3rd argument.</typeparam>
        /// <typeparam name="T2">The type of the 4th argument.</typeparam>
        /// <typeparam name="T3">The type of the 5th argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <param name="arg3">Argument 3</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<T2, T3, TResult> partial<TArg1, TArg2, TArg3, T2, T3, TResult>(Func<TArg1, TArg2, TArg3, T2, T3, TResult> f, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
            (T2 x, T3 y) =>
            f(arg1, arg2, arg3, x, y);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="TArg2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="TArg3">The type of the 3rd argument.</typeparam>
        /// <typeparam name="T2">The type of the 4th argument.</typeparam>
        /// <typeparam name="T3">The type of the 5th argument.</typeparam>
        /// <typeparam name="T4">The type of the 6th argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <param name="arg3">Argument 3</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Func<T2, T3, T4, TResult> partial<TArg1, TArg2, TArg3, T2, T3, T4, TResult>(Func<TArg1, TArg2, TArg3, T2, T3, T4, TResult> f, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
            (T2 x, T3 y, T4 z) =>
            f(arg1, arg2, arg3, x, y, z);

        /// <summary>
        /// Takes a function f and fewer than the normal arguments to f, and
        /// returns a fn that takes a variable number of additional args
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TArg1">The type of the 1st argument.</typeparam>
        /// <typeparam name="TArg2">The type of the 2nd argument.</typeparam>
        /// <typeparam name="TArg3">The type of the 3rd argument.</typeparam>
        /// <typeparam name="T2">The type of the 4th argument.</typeparam>
        /// <typeparam name="T3">The type of the 5th argument.</typeparam>
        /// <typeparam name="T4">The type of the 6th argument.</typeparam>
        /// <typeparam name="T5">The type of the 7th argument.</typeparam>
        /// <param name="f">Function 1</param>
        /// <param name="arg1">Argument 1</param>
        /// <param name="arg2">Argument 2</param>
        /// <param name="arg3">Argument 3</param>
        /// <returns>
        /// The partial function
        /// </returns>
        public static Del<T2, T3, T4, T5, TResult> partial<TArg1, TArg2, TArg3, T2, T3, T4, T5, TResult>(Del<TArg1, TArg2, TArg3, T2, T3, T4, T5, TResult> f, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
            (T2 x, T3 y, T4 z, T5[] args) =>
            f(arg1, arg2, arg3, x, y, z, args);
    }
}
