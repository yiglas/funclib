using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

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
        public object Invoke(object f) => new Function<object, object>(rf => new TransducerFunction(f, rf));
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
                var fn = ((IFunction<object, object>)f);
                var s = (ISeq)seq(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    var fst = s.First();
                    var fv = fn.Invoke(fst);
                    var run = cons(fst, takeWhile(new Function<object, object>(x => isEqualTo(fv, fn.Invoke(x))), s.Next()));

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
                this._pv = (Volatileǃ)new Volatileǃ().Invoke("::none");
            }

            #region Overrides
            public override object Invoke(object result)
            {
                if (!(bool)isZero(this._a.Count))
                {
                    var v = new Vec().Invoke(this._a.ToArray());
                    this._a.Clear();
                    result = new Unreduce().Invoke(((IFunction<object, object, object>)this._rf).Invoke(result, v));
                }

                return ((IFunction<object, object>)this._rf).Invoke(result);
            }
            public override object Invoke(object result, object input)
            {
                var pval = this._pv.Deref();
                var val = ((IFunction<object, object>)this._f).Invoke(input);
                new VResetǃ().Invoke(this._pv, val);
                if ((bool)new Truthy().Invoke(or(isIdentical(pval, "::none"), isEqualTo(val, pval))))
                {
                    this._a.Add(input);
                    return result;
                }

                var v = new Vec().Invoke(this._a.ToArray());
                this._a.Clear();
                var ret = ((IFunction<object, object, object>)this._rf).Invoke(result, v);

                if (!(bool)reduced(ret))
                    this._a.Add(input);

                return ret;
            }
            #endregion
        }
    }
}
