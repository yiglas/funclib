using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of elements separated by sep.
    /// </summary>
    public class Interpose :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object sep) => func<object, object>(rf => new TransducerFunction(sep, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of elements separated by sep.
        /// </summary>
        /// <param name="sep">Separator object.</param>
        /// <param name="coll">Collection to insert the separtor with.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of elements separated by sep.
        /// </returns>
        public object Invoke(object sep, object coll) =>
            drop(1, interleave(repeat(sep), coll));
        
        public class TransducerFunction :
            ATransducerFunction
        {
            Volatileǃ _started;
            object _sep;

            public TransducerFunction(object sep, object rf) :
                base(rf)
            {
                this._sep = sep;
                this._started = (Volatileǃ)volatileǃ(false);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                if ((bool)truthy(this._started.Deref()))
                {
                    var sepr = invoke(this._rf, result, this._sep);
                    if ((bool)isReduced(sepr))
                        return sepr;

                    return invoke(this._rf, sepr, input);
                }

                vresetǃ(this._started, true);
                return invoke(this._rf, result, input);
            }
            #endregion
        }
    }
}