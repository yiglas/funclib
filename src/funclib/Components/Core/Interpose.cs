using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of elements separated by sep.
    /// </summary>
    public class Interpose :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object sep) => funclib.Core.Func(rf => new TransducerFunction(sep, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of elements separated by sep.
        /// </summary>
        /// <param name="sep">Separator object.</param>
        /// <param name="coll">Collection to insert the separtor with.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of elements separated by sep.
        /// </returns>
        public object Invoke(object sep, object coll) =>
            funclib.Core.Drop(1, funclib.Core.Interleave(funclib.Core.Repeat(sep), coll));
        
        public class TransducerFunction :
            ATransducerFunction
        {
            Volatileǃ _started;
            object _sep;

            public TransducerFunction(object sep, object rf) :
                base(rf)
            {
                this._sep = sep;
                this._started = (Volatileǃ)funclib.Core.Volatileǃ(false);
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                if ((bool)funclib.Core.Truthy(this._started.Deref()))
                {
                    var sepr = funclib.Core.Invoke(this._rf, result, this._sep);
                    if ((bool)funclib.Core.IsReduced(sepr))
                        return sepr;

                    return funclib.Core.Invoke(this._rf, sepr, input);
                }

                funclib.Core.VResetǃ(this._started, true);
                return funclib.Core.Invoke(this._rf, result, input);
            }
            #endregion
        }
    }
}