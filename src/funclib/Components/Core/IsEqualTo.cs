using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns true if values are equal, otherwise false.
    /// </summary>
    public class IsEqualTo :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns true if values are equal, otherwise false.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <returns>
        /// Always true.
        /// </returns>
        public object Invoke(object x) => true;
        /// <summary>
        /// Returns true if values are equal, otherwise false.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test against.</param>
        /// <returns>
        /// Returns true if x is equal to y, otherwise false.
        /// </returns>
        public object Invoke(object x, object y)
        {
            if (x == y) return true;
            if (x != null)
            {
                if (Numbers.IsNumber(x) && Numbers.IsNumber(y))
                    return Numbers.IsEqual(x, y);

                return x.Equals(y);
            }

            return false;
        }
        /// <summary>
        /// Returns true if values are equal, otherwise false.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test against.</param>
        /// <param name="more">All other elements to test.</param>
        /// <returns>
        /// Returns true if values are equal, otherwise false.
        /// </returns>
        public object Invoke(object x, object y, params object[] more)
        {
            if ((bool)Invoke(x, y))
            {
                var n = funclib.Core.Next(more);
                if ((bool)funclib.Core.Truthy(n))
                    return Invoke(y, funclib.Core.First(more), (object[])funclib.Core.ToArray(n));

                return Invoke(y, funclib.Core.First(more));
            }

            return false;
        }
    }


    public class E :
        IFunction<object, bool>,
        IFunction<object, object, bool>,
        IFunctionParams<object, object, object, bool>
    {
        public bool Invoke(object x) => true;
        public bool Invoke(object x, object y)
        {
            if (x == y) return true;
            if (x != null)
            {
                if (Numbers.IsNumber(x) && Numbers.IsNumber(y))
                    return Numbers.IsEqual(x, y);

                return x.Equals(y);
            }

            return false;
        }
        public bool Invoke(object x, object y, params object[] more)
        {
            if (Invoke(x, y))
            {
                var n = funclib.Core.Next(more);
                if ((bool)funclib.Core.Truthy(n))
                    return Invoke(y, funclib.Core.First(more), (object[])funclib.Core.ToArray(n));

                return Invoke(y, funclib.Core.First(more));
            }

            return false;
        }
    }
}
