using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of elements separated by sep.
    /// </summary>
    public class Interpose :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object sep) => new Function<object, object>(rf => new TransducerFunction(sep, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of elements separated by sep.
        /// </summary>
        /// <param name="sep">Separator object.</param>
        /// <param name="coll">Collection to insert the separtor with.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of elements separated by sep.
        /// </returns>
        public object Invoke(object sep, object coll) =>
            new Drop().Invoke(1, new Interleave().Invoke(new Repeat().Invoke(sep), coll));
        
        public class TransducerFunction :
            ATransducerFunction
        {
            Volatile _started;
            object _sep;

            public TransducerFunction(object sep, object rf) :
                base(rf)
            {
                this._sep = sep;
                this._started = (Volatile)new Volatile_().Invoke(false);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                if ((bool)new Truthy().Invoke(this._started.Deref()))
                {
                    var sepr = ((IFunction<object, object, object>)this._rf).Invoke(result, this._sep);
                    if ((bool)new IsReduced().Invoke(sepr))
                        return sepr;

                    return ((IFunction<object, object, object>)this._rf).Invoke(sepr, input);
                }

                new VReset_().Invoke(this._started, true);
                return ((IFunction<object, object, object>)this._rf).Invoke(result, input);
            }
            #endregion
        }
    }
}