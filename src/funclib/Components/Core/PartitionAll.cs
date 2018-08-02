using funclib.Components.Core.Generic;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of lists like <see cref="Partition"/>, but my include
    /// partitions with fewer then n items at the end.
    /// </summary>
    public class PartitionAll :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object n) => func<object, object>(rf => new TransducerFunction(n, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of lists like <see cref="Partition"/>, but my include
        /// partitions with fewer then n items at the end.
        /// </summary>
        /// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
        /// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of lists like <see cref="Partition"/>, but my include
        /// partitions with fewer then n items at the end.
        /// </returns>
        public object Invoke(object n, object coll) => Invoke(n, n, coll);
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of lists like <see cref="Partition"/>, but my include
        /// partitions with fewer then n items at the end.
        /// </summary>
        /// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
        /// <param name="step">A <see cref="int"/> specifying the starting point for each group.</param>
        /// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of lists like <see cref="Partition"/>, but my include
        /// partitions with fewer then n items at the end.
        /// </returns>
        public object Invoke(object n, object step, object coll) =>
            lazySeq(() =>
            {
                var s = seq(coll);
                if ((bool)truthy(s))
                {
                    var seq = doAll(take(n, s));
                    return cons(seq, Invoke(n, step, nthRest(s, step)));
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
                this._a.Add(input);
                if (this._n == this._a.Count)
                {
                    var v = vec(this._a.ToArray());
                    this._a.Clear();
                    return invoke(this._rf, result, v);
                }

                return result;
            }
            #endregion
        }

    }
}
