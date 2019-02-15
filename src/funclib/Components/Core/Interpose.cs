using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of elements separated by sep.
    /// </summary>
    public class Interpose :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object sep) => funclib.Core.Func(rf => new TransducerFunction(sep, rf));
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of elements separated by sep.
        /// </summary>
        /// <param name="sep">Separator object.</param>
        /// <param name="coll">Collection to insert the separator with.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of elements separated by sep.
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
                if (funclib.Core.T(this._started.Deref()))
                {
                    var sep = funclib.Core.Invoke(this._rf, result, this._sep);
                    if ((bool)funclib.Core.IsReduced(sep))
                        return sep;

                    return funclib.Core.Invoke(this._rf, sep, input);
                }

                funclib.Core.VResetǃ(this._started, true);
                return funclib.Core.Invoke(this._rf, result, input);
            }
            #endregion
        }
    }
}