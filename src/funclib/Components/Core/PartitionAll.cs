using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of lists like <see cref="funclib.Components.Core.Partition"/>, but my include
    /// partitions with fewer then n items at the end.
    /// </summary>
    public class PartitionAll :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object n) => funclib.Core.Func(rf => new TransducerFunction(n, rf));
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of lists like <see cref="funclib.Components.Core.Partition"/>, but my include
        /// partitions with fewer then n items at the end.
        /// </summary>
        /// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
        /// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of lists like <see cref="funclib.Components.Core.Partition"/>, but my include
        /// partitions with fewer then n items at the end.
        /// </returns>
        public object Invoke(object n, object coll) => Invoke(n, n, coll);
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of lists like <see cref="funclib.Components.Core.Partition"/>, but my include
        /// partitions with fewer then n items at the end.
        /// </summary>
        /// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
        /// <param name="step">A <see cref="int"/> specifying the starting point for each group.</param>
        /// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of lists like <see cref="funclib.Components.Core.Partition"/>, but my include
        /// partitions with fewer then n items at the end.
        /// </returns>
        public object Invoke(object n, object step, object coll) =>
            funclib.Core.LazySeq(() =>
            {
                var s = funclib.Core.Seq(coll);
                if (funclib.Core.T(s))
                {
                    var seq = funclib.Core.DoAll(funclib.Core.Take(n, s));
                    return funclib.Core.Cons(seq, Invoke(n, step, funclib.Core.NthRest(s, step)));
                }
                return null;
            });

        public class TransducerFunction :
            ATransducerFunction
        {
            int _n;
            System.Collections.ArrayList _a;

            public TransducerFunction(object n, object rf) :
                base(rf)
            {
                this._n = Numbers.ConvertToInt(n);
                this._a = new System.Collections.ArrayList(this._n);
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
                this._a.Add(input);
                if (this._n == this._a.Count)
                {
                    var v = funclib.Core.Vec(this._a.ToArray());
                    this._a.Clear();
                    return funclib.Core.Invoke(this._rf, result, v);
                }

                return result;
            }
            #endregion
        }

    }
}
