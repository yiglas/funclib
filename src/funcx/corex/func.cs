namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        public static Delegate func<T1>(T1 f) where T1 : Delegate => f;


        /// <summary>
        /// Inference type helper for the <see cref="Func{TResult}"/> delegate.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to infer</param>
        /// <returns>
        /// Returns the given function but gives the compiler the ability to infer its types.
        /// </returns>
        public static Func<TResult> func<TResult>(Func<TResult> f) => f;

        /// <summary>
        /// Inference type helper for the <see cref="Func{T, TResult}"/> delegate.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to infer</param>
        /// <returns>
        /// Returns the given function but gives the compiler the ability to infer its types.
        /// </returns>
        public static Func<T, TResult> func<T, TResult>(Func<T, TResult> f) => f;

        /// <summary>
        /// Inference type helper for the <see cref="Func{T1, T2, TResult}"/> delegate.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to infer</param>
        /// <returns>
        /// Returns the given function but gives the compiler the ability to infer its types.
        /// </returns>
        public static Func<T1, T2, TResult> func<T1, T2, TResult>(Func<T1, T2, TResult> f) => f;

        /// <summary>
        /// Inference type helper for the <see cref="Func{T1, T2, T3, TResult}"/> delegate.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to infer</param>
        /// <returns>
        /// Returns the given function but gives the compiler the ability to infer its types.
        /// </returns>
        public static Func<T1, T2, T3, TResult> func<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> f) => f;

        /// <summary>
        /// Inference type helper for the <see cref="Func{T1, T2, T3, T4, TResult}"/> delegate.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to infer</param>
        /// <returns>
        /// Returns the given function but gives the compiler the ability to infer its types.
        /// </returns>
        public static Func<T1, T2, T3, T4, TResult> func<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> f) => f;

        /// <summary>
        /// Inference type helper for the <see cref="Func{T1, T2, T3, T4, T5, TResult}"/> delegate.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to infer</param>
        /// <returns>
        /// Returns the given function but gives the compiler the ability to infer its types.
        /// </returns>
        public static Func<T1, T2, T3, T4, T5, TResult> func<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> f) => f;

        /// <summary>
        /// Inference type helper for the <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/> delegate.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="f">The function to infer</param>
        /// <returns>
        /// Returns the given function but gives the compiler the ability to infer its types.
        /// </returns>
        public static Func<T1, T2, T3, T4, T5, T6, TResult> func<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> f) => f;

        /// <summary>
        /// Inference type helper for an <see cref="Action"/> that converts it into a <see cref="Func{TResult}"/> with null as the result.
        /// </summary>
        /// <param name="a">The action to infer.</param>
        /// <returns>
        /// A function that returns null.
        /// </returns>
        public static Func<object> func(Action a) => () => { a(); return null; };

        /// <summary>
        /// Inference type helper for an <see cref="Action{T}"/> that converts it into a <see cref="Func{T, TResult}"/> with null as the result.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="a">The action to infer.</param>
        /// <returns>
        /// A function that returns null.
        /// </returns>
        public static Func<T, object> func<T>(Action<T> a) => (T x) => { a(x); return null; };

        /// <summary>
        /// Inference type helper for an <see cref="Action{T1, T2}"/> that converts it into a <see cref="Func{T1, T2, TResult}"/> with null as the result.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="a">The action to infer.</param>
        /// <returns>
        /// A function that returns null.
        /// </returns>
        public static Func<T1, T2, object> func<T1, T2>(Action<T1, T2> a) => (T1 x, T2 y) => { a(x, y); return null; };

        /// <summary>
        /// Inference type helper for an <see cref="Action{T1, T2, T3}"/> that converts it into a <see cref="Func{T1, T2, T3, TResult}"/> with null as the result.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="a">The action to infer.</param>
        /// <returns>
        /// A function that returns null.
        /// </returns>
        public static Func<T1, T2, T3, object> func<T1, T2, T3>(Action<T1, T2, T3> a) => (T1 x, T2 y, T3 z) => { a(x, y, z); return null; };

        /// <summary>
        /// Inference type helper for an <see cref="Action{T1, T2, T3, T4}"/> that converts it into a <see cref="Func{T1, T2, T3, T4, TResult}"/> with null as the result.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="a">The action to infer.</param>
        /// <returns>
        /// A function that returns null.
        /// </returns>
        public static Func<T1, T2, T3, T4, object> func<T1, T2, T3, T4>(Action<T1, T2, T3, T4> a) => (T1 x, T2 y, T3 z, T4 b) => { a(x, y, z, b); return null; };

        /// <summary>
        /// Inference type helper for an <see cref="Action{T1, T2, T3, T4, T5}"/> that converts it into a <see cref="Func{T1, T2, T3, T4, T5, TResult}"/> with null as the result.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="a">The action to infer.</param>
        /// <returns>
        /// A function that returns null.
        /// </returns>
        public static Func<T1, T2, T3, T4, T5, object> func<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> a) => (T1 x, T2 y, T3 z, T4 b, T5 c) => { a(x, y, z, b, c); return null; };

        /// <summary>
        /// Inference type helper for an <see cref="Action{T1, T2, T3, T4, T5, T6}"/> that converts it into a <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/> with null as the result.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
        /// <param name="a">The action to infer.</param>
        /// <returns>
        /// A function that returns null.
        /// </returns>
        public static Func<T1, T2, T3, T4, T5, T6, object> func<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> a) => (T1 x, T2 y, T3 z, T4 b, T5 c, T6 d) =>  { a(x, y, z, b, c, d); return null; };
    }
}
