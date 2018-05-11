namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        // TODO: add comments

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="binding"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static TResult let<T1, TResult>(T1 binding, Func<T1, TResult> form) =>
            form(binding);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="binding"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static TResult let<T1, T2, TResult>(ValueTuple<T1, T2> binding, Func<ValueTuple<T1, T2>, TResult> form) =>
            form(binding);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="binding"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static TResult let<T1, T2, T3, TResult>(ValueTuple<T1, T2, T3> binding, Func<ValueTuple<T1, T2, T3>, TResult> form) =>
            form(binding);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="binding"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static TResult let<T1, T2, T3, T4, TResult>(ValueTuple<T1, T2, T3, T4> binding, Func<ValueTuple<T1, T2, T3, T4>, TResult> form) =>
            form(binding);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="binding"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static TResult let<T1, T2, T3, T4, T5, TResult>(ValueTuple<T1, T2, T3, T4, T5> binding, Func<ValueTuple<T1, T2, T3, T4, T5>, TResult> form) =>
            form(binding);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="binding"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static TResult let<T1, T2, T3, T4, T5, T6, TResult>(ValueTuple<T1, T2, T3, T4, T5, T6> binding, Func<ValueTuple<T1, T2, T3, T4, T5, T6>, TResult> form) =>
            form(binding);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="binding"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static TResult let<T1, T2, T3, T4, T5, T6, T7, TResult>(ValueTuple<T1, T2, T3, T4, T5, T6, T7> binding, Func<ValueTuple<T1, T2, T3, T4, T5, T6, T7>, TResult> form) =>
            form(binding);
    }
}
