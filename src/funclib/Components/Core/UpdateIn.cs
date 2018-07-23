using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// 'Updates' a value in a nested <see cref="Collections.IAssociative"/> structure,
    /// where ks is a <see cref="Collections.ISeq"/> of keys and f is a <see cref="IFunction"/>
    /// that will take the old value and any supplied args and return the new value, and
    /// returns a new nested structure. If any levels do not exists, a <see cref="HashMap"/>
    /// will be created.
    /// </summary>
    public class UpdateIn :
        IFunctionParams<object, object, object, object, object>
    {
        /// <summary>
        /// 'Updates' a value in a nested <see cref="Collections.IAssociative"/> structure,
        /// where ks is a <see cref="Collections.ISeq"/> of keys and f is a <see cref="IFunction"/>
        /// that will take the old value and any supplied args and return the new value, and
        /// returns a new nested structure. If any levels do not exists, a <see cref="Collections.HashMap"/>
        /// will be created.
        /// </summary>
        /// <param name="m">An object that implements the <see cref="Collections.IAssociative"/> interface.</param>
        /// <param name="ks">An object that implements the <see cref="Collections.ISeq"/> interface.</param>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="args">A list of supplied arguments.</param>
        /// <returns>
        /// Returns a new <see cref="Collections.HashMap"/> with the value updated.
        /// </returns>
        public object Invoke(object m, object ks, object f, params object[] args) => up(m, ks, f, args);

        object up(object m, object ks, object f, object args)
        {
            var k = first(ks);
            ks = more(ks);

            if ((bool)truthy(ks))
                return assoc(m, k, up(get(m, k), ks, f, args));

            return assoc(m, k, apply(f, get(m, k), args));
        }
    }
}
