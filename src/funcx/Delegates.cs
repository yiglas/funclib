namespace funcx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Delegate function method signature with last parameter as a "params" function.
    /// </summary>
    /// <typeparam name="T1">Generic type of the params list.</typeparam>
    /// <typeparam name="R">Generic return type.</typeparam>
    /// <param name="more">Array list of parameter values</param>
    /// <returns>
    /// Returns generic type R.
    /// </returns>
    public delegate R DelPA<T1, R>(params T1[] more);

    /// <summary>
    /// Delegate function method signature with last parameter as a "params" function.
    /// </summary>
    /// <typeparam name="T1">Generic type of parameter 1.</typeparam>
    /// <typeparam name="T2">Generic type of the params list.</typeparam>
    /// <typeparam name="R">Generic return type.</typeparam>
    /// <param name="x">Parameter value 1</param>
    /// <param name="more">Array list of parameter values</param>
    /// <returns>
    /// Returns generic type R.
    /// </returns>
    public delegate R DelP1PA<T1, T2, R>(T1 x, params T2[] more);

    /// <summary>
    /// Delegate function method signature with last parameter as a "params" function.
    /// </summary>
    /// <typeparam name="T1">Generic type of parameter 1.</typeparam>
    /// <typeparam name="T2">Generic type of the parameter 2.</typeparam>
    /// <typeparam name="T3">Generic type of the params list.</typeparam>
    /// <typeparam name="R">Generic return type.</typeparam>
    /// <param name="x">Parameter value 1</param>
    /// <param name="y">Parameter value 2</param>
    /// <param name="more">Array list of parameter values</param>
    /// <returns>
    /// Returns generic type R.
    /// </returns>
    public delegate R DelP2PA<T1, T2, T3, R>(T1 x, T2 y, params T3[] more);

    /// <summary>
    /// Delegate function method signature with last parameter as a "params" function.
    /// </summary>
    /// <typeparam name="T1">Generic type of parameter 1.</typeparam>
    /// <typeparam name="T2">Generic type of the parameter 2.</typeparam>
    /// <typeparam name="T3">Generic type of the parameter 3.</typeparam>
    /// <typeparam name="T4">Generic type of the params list.</typeparam>
    /// <typeparam name="R">Generic return type.</typeparam>
    /// <param name="x">Parameter value 1</param>
    /// <param name="y">Parameter value 2</param>
    /// <param name="z">Parameter value 3</param>
    /// <param name="more">Array list of parameter values</param>
    /// <returns>
    /// Returns generic type R.
    /// </returns>
    public delegate R DelP3PA<T1, T2, T3, T4, R>(T1 x, T2 y, T3 z, params T4[] more);

    /// <summary>
    /// Delegate function method signature with last parameter as a "params" function.
    /// </summary>
    /// <typeparam name="T1">Generic type of parameter 1.</typeparam>
    /// <typeparam name="T2">Generic type of the parameter 2.</typeparam>
    /// <typeparam name="T3">Generic type of the parameter 3.</typeparam>
    /// <typeparam name="T4">Generic type of the parameter 4.</typeparam>
    /// <typeparam name="T5">Generic type of the params list.</typeparam>
    /// <typeparam name="R">Generic return type.</typeparam>
    /// <param name="a">Parameter value 1</param>
    /// <param name="b">Parameter value 2</param>
    /// <param name="c">Parameter value 3</param>
    /// <param name="d">Parameter value 4</param>
    /// <param name="more">Array list of parameter values</param>
    /// <returns>
    /// Returns generic type R.
    /// </returns>
    public delegate R DelP4PA<T1, T2, T3, T4, T5, R>(T1 a, T2 b, T3 c, T4 d, params T5[] more);
}
