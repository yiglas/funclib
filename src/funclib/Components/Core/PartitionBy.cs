using funclib.Components.Core.Generic;
using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Applies <see cref="IFunction{T1, TResult}"/> to each value in coll, splitting it each 
    /// time f returns a new value. Returns a <see cref="LazySeq"/> of partitions.
    /// </summary>
    public class PartitionBy :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object f) => func<object, object>(rf => new TransducerFunction(f, rf));
        /// <summary>
        /// Applies <see cref="IFunction{T1, TResult}"/> to each value in coll, splitting it each 
        /// time f returns a new value. Returns a <see cref="LazySeq"/> of partitions.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of partitions.
        /// </returns>
        public object Invoke(object f, object coll) =>
            lazySeq(() =>
            {
                var s = seq(coll);
                if ((bool)truthy(s))
                {
                    var fst = first(s);
                    var fv = invoke(f, fst);
                    var run = cons(fst, takeWhile(func<object, object>(x => isEqualTo(fv, invoke(f, x))), next(s)));

                    return cons(run, Invoke(f, seq(drop(count(run), s))));
                }
                return null;
            });

        public class TransducerFunction :
            ATransducerFunction
        {
            System.Collections.ArrayList _a;
            Volatileǃ _pv;
            object _f;

            public TransducerFunction(object f, object rf) :
                base(rf)
            {
                this._f = f;
                this._a = new System.Collections.ArrayList();
                this._pv = (Volatileǃ)volatileǃ("::none");
            }

            #region Overrides
            public override object Invoke(object result)
            {
                if (!(bool)isZero(this._a.Count))
                {
                    var v = vec(this._a.ToArray());
                    this._a.Clear();
                    result = unreduce(invoke(this._rf, result, v));
                }

                return invoke(this._rf, result);
            }
            public override object Invoke(object result, object input)
            {
                var pval = this._pv.Deref();
                var val = invoke(this._f, input);
                vresetǃ(this._pv, val);
                if ((bool)truthy(or(isIdentical(pval, "::none"), isEqualTo(val, pval))))
                {
                    this._a.Add(input);
                    return result;
                }

                var v = vec(this._a.ToArray());
                this._a.Clear();
                var ret = invoke(this._rf, result, v);

                if (!(bool)reduced(ret))
                    this._a.Add(input);

                return ret;
            }
            #endregion
        }
    }
}
