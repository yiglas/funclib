namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Takes a function f, and returns a function that calls f, replacing a null first arguments with the supplied arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to null-patch.</param>
        /// <param name="x">The default value for the first argument.</param>
        /// <returns>
        /// A function with the same argument.
        /// </returns>
        public static Func<T1, TResult> fnull<T1, TResult>(Func<T1, TResult> f, T1 x) =>
            (T1 a) =>
            f != null
                ? f(a == null ? x : a)
                : default;

        /// <summary>
        /// Takes a function f, and returns a function that calls f, replacing a null first arguments with the supplied arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to null-patch.</param>
        /// <param name="x">The default value for the first argument.</param>
        /// <returns>
        /// A function with the same argument.
        /// </returns>
        public static Func<T1, T2, TResult> fnull<T1, T2, TResult>(Func<T1, T2, TResult> f, T1 x) =>
            (T1 a, T2 b) =>
            f != null
                ? f(a == null ? x : a, b)
                : default;

        /// <summary>
        /// Takes a function f, and returns a function that calls f, replacing a null first arguments with the supplied arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to null-patch.</param>
        /// <param name="x">The default value for the first argument.</param>
        /// <returns>
        /// A function with the same argument.
        /// </returns>
        public static Func<T1, T2, T3, TResult> fnull<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> f, T1 x) =>
            (T1 a, T2 b, T3 c) =>
            f != null
                ? f(a == null ? x : a, b, c)
                : default;

        /// <summary>
        /// Takes a function f, and returns a function that calls f, replacing a null first arguments with the supplied arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to null-patch.</param>
        /// <param name="x">The default value for the first argument.</param>
        /// <param name="y">The default value for the second argument.</param>
        /// <returns>
        /// A function with the same argument.
        /// </returns>
        public static Func<T1, T2, TResult> fnull<T1, T2, TResult>(Func<T1, T2, TResult> f, T1 x, T2 y) =>
            (T1 a, T2 b) =>
            f != null
                ? f(a == null ? x : a, b == null ? y : b)
                : default;

        /// <summary>
        /// Takes a function f, and returns a function that calls f, replacing a null first arguments with the supplied arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to null-patch.</param>
        /// <param name="x">The default value for the first argument.</param>
        /// <param name="y">The default value for the second argument.</param>
        /// <returns>
        /// A function with the same argument.
        /// </returns>
        public static Func<T1, T2, T3, TResult> fnull<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> f, T1 x, T2 y) =>
            (T1 a, T2 b, T3 c) =>
            f != null
                ? f(a == null ? x : a, b == null ? y : b, c)
                : default;

        /// <summary>
        /// Takes a function f, and returns a function that calls f, replacing a null first arguments with the supplied arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to null-patch.</param>
        /// <param name="x">The default value for the first argument.</param>
        /// <param name="y">The default value for the second argument.</param>
        /// <param name="z">The default value for the third argument.</param>
        /// <returns>
        /// A function with the same argument.
        /// </returns>
        public static Func<T1, T2, T3, TResult> fnull<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> f, T1 x, T2 y, T3 z) =>
            (T1 a, T2 b, T3 c) =>
            f != null
                ? f(a == null ? x : a, b == null ? y : b, c == null ? z : c)
                : default;

    }
}
