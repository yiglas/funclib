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
        /// 'Updates' a value in an associative structure, where key is the key and func is a function
        /// that will take the old value and any supplied parameters and return the new value and returns 
        /// a new structure. If the key does not exist, the default TValue is passed as the old value.
        /// </summary>
        /// <typeparam name="TKey">Generic key type.</typeparam>
        /// <typeparam name="TValue">Generic value type.</typeparam>
        /// <param name="m">The <see cref="IDictionary{TKey, TValue}"/> updating the value to.</param>
        /// <param name="key">Key to find.</param>
        /// <param name="func">The function to apply the value to.</param>
        /// <returns>
        /// Returns a new <see cref="IDictionary{TKey, TValue}"/> with the value updated.
        /// </returns>
        public static IDictionary<TKey, TValue> update<TKey, TValue>(IDictionary<TKey, TValue> m, TKey key, Func<TValue, TValue> func) =>
            assoc(m, (key, func(get(m, key))));

        /// <summary>
        /// 'Updates' a value in an associative structure, where key is the key and func is a function
        /// that will take the old value and any supplied parameters and return the new value and returns 
        /// a new structure. If the key does not exist, the default TValue is passed as the old value.
        /// </summary>
        /// <typeparam name="TKey">Generic key type.</typeparam>
        /// <typeparam name="TValue">Generic value type.</typeparam>
        /// <typeparam name="T1">Generic type of the additional parameter for the function.</typeparam>
        /// <param name="m">The <see cref="IDictionary{TKey, TValue}"/> updating the value to.</param>
        /// <param name="key">Key to find.</param>
        /// <param name="func">The function to apply the value to.</param>
        /// <param name="x">Additional parameter to supply to the function.</param>
        /// <returns>
        /// Returns a new <see cref="IDictionary{TKey, TValue}"/> with the value updated.
        /// </returns>
        public static IDictionary<TKey, TValue> update<TKey, TValue, T1>(IDictionary<TKey, TValue> m, TKey key, Func<TValue, T1, TValue> func, T1 x) =>
            assoc(m, (key, func(get(m, key), x)));

        /// <summary>
        /// 'Updates' a value in an associative structure, where key is the key and func is a function
        /// that will take the old value and any supplied parameters and return the new value and returns 
        /// a new structure. If the key does not exist, the default TValue is passed as the old value.
        /// </summary>
        /// <typeparam name="TKey">Generic key type.</typeparam>
        /// <typeparam name="TValue">Generic value type.</typeparam>
        /// <typeparam name="T1">Generic type of the additional parameter for the function.</typeparam>
        /// <typeparam name="T2">Generic type of the additional parameter for the function.</typeparam>
        /// <param name="m">The <see cref="IDictionary{TKey, TValue}"/> updating the value to.</param>
        /// <param name="key">Key to find.</param>
        /// <param name="func">The function to apply the value to.</param>
        /// <param name="x">Additional parameter to supply to the function.</param>
        /// <param name="y">Additional parameter to supply to the function.</param>
        /// <returns>
        /// Returns a new <see cref="IDictionary{TKey, TValue}"/> with the value updated.
        /// </returns>
        public static IDictionary<TKey, TValue> update<TKey, TValue, T1, T2>(IDictionary<TKey, TValue> m, TKey key, Func<TValue, T1, T2, TValue> func, T1 x, T2 y) =>
            assoc(m, (key, func(get(m, key), x, y)));

        /// <summary>
        /// 'Updates' a value in an associative structure, where key is the key and func is a function
        /// that will take the old value and any supplied parameters and return the new value and returns 
        /// a new structure. If the key does not exist, the default TValue is passed as the old value.
        /// </summary>
        /// <typeparam name="TKey">Generic key type.</typeparam>
        /// <typeparam name="TValue">Generic value type.</typeparam>
        /// <typeparam name="T1">Generic type of the additional parameter for the function.</typeparam>
        /// <typeparam name="T2">Generic type of the additional parameter for the function.</typeparam>
        /// <typeparam name="T3">Generic type of the additional parameter for the function.</typeparam>
        /// <param name="m">The <see cref="IDictionary{TKey, TValue}"/> updating the value to.</param>
        /// <param name="key">Key to find.</param>
        /// <param name="func">The function to apply the value to.</param>
        /// <param name="x">Additional parameter to supply to the function.</param>
        /// <param name="y">Additional parameter to supply to the function.</param>
        /// <param name="z">Additional parameter to supply to the function.</param>
        /// <returns>
        /// Returns a new <see cref="IDictionary{TKey, TValue}"/> with the value updated.
        /// </returns>
        public static IDictionary<TKey, TValue> update<TKey, TValue, T1, T2, T3>(IDictionary<TKey, TValue> m, TKey key, Func<TValue, T1, T2, T3, TValue> func, T1 x, T2 y, T3 z) =>
            assoc(m, (key, func(get(m, key), x, y, z)));

        /// <summary>
        /// 'Updates' a value in an associative structure, where key is the key and func is a function
        /// that will take the old value and any supplied parameters and return the new value and returns 
        /// a new structure. If the key does not exist, the default TValue is passed as the old value.
        /// </summary>
        /// <typeparam name="TKey">Generic key type.</typeparam>
        /// <typeparam name="TValue">Generic value type.</typeparam>
        /// <typeparam name="T1">Generic type of the additional parameter for the function.</typeparam>
        /// <typeparam name="T2">Generic type of the additional parameter for the function.</typeparam>
        /// <typeparam name="T3">Generic type of the additional parameter for the function.</typeparam>
        /// <typeparam name="T4">Generic type of the additional parameter for the function.</typeparam>
        /// <param name="m">The <see cref="IDictionary{TKey, TValue}"/> updating the value to.</param>
        /// <param name="key">Key to find.</param>
        /// <param name="func">The function to apply the value to.</param>
        /// <param name="x">Additional parameter to supply to the function.</param>
        /// <param name="y">Additional parameter to supply to the function.</param>
        /// <param name="z">Additional parameter to supply to the function.</param>
        /// <param name="more">Parameter List for addition parameter to supply to the function.</param>
        /// <returns>
        /// Returns a new <see cref="IDictionary{TKey, TValue}"/> with the value updated.
        /// </returns>
        public static IDictionary<TKey, TValue> update<TKey, TValue, T1, T2, T3, T4>(IDictionary<TKey, TValue> m, TKey key, DelP4PA<TValue, T1, T2, T3, T4, TValue> func, T1 x, T2 y, T3 z, params T4[] more) =>
            assoc(m, (key, func(get(m, key), x, y, z, more)));
        
        //TODO: implement the update with a IList
    }
}
