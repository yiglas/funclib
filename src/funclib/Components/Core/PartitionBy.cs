using funclib.Components.Core.Generic;

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
        public object Invoke(object f) => funclib.Core.Func(rf => new TransducerFunction(f, rf));
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
            funclib.Core.LazySeq(() =>
            {
                var s = funclib.Core.Seq(coll);
                if ((bool)funclib.Core.Truthy(s))
                {
                    var fst = funclib.Core.First(s);
                    var fv = funclib.Core.Invoke(f, fst);
                    var run = funclib.Core.Cons(fst, funclib.Core.TakeWhile(funclib.Core.Func(x => funclib.Core.IsEqualTo(fv, funclib.Core.Invoke(f, x))), funclib.Core.Next(s)));

                    return funclib.Core.Cons(run, Invoke(f, funclib.Core.Seq(funclib.Core.Drop(funclib.Core.Count(run), s))));
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
                this._pv = (Volatileǃ)funclib.Core.Volatileǃ("::none");
            }

            #region Overrides
            public override object Invoke(object result)
            {
                if (!(bool)funclib.Core.IsZero(this._a.Count))
                {
                    var v = funclib.Core.Vec(this._a.ToArray());
                    this._a.Clear();
                    result = funclib.Core.Unreduce(funclib.Core.Invoke(this._rf, result, v));
                }

                return funclib.Core.Invoke(this._rf, result);
            }
            public override object Invoke(object result, object input)
            {
                var pval = this._pv.Deref();
                var val = funclib.Core.Invoke(this._f, input);
                funclib.Core.VResetǃ(this._pv, val);
                if ((bool)funclib.Core.Truthy(funclib.Core.Or(funclib.Core.IsIdentical(pval, "::none"), funclib.Core.IsEqualTo(val, pval))))
                {
                    this._a.Add(input);
                    return result;
                }

                var v = funclib.Core.Vec(this._a.ToArray());
                this._a.Clear();
                var ret = funclib.Core.Invoke(this._rf, result, v);

                if (!(bool)funclib.Core.Reduced(ret))
                    this._a.Add(input);

                return ret;
            }
            #endregion
        }
    }
}
