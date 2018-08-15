using funclib.Collections;
using funclib.Collections.Internal;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// f should implement the <see cref="IFunction{T1, T2, TResult}"/> interface. If val is not supplied,
    /// returns the result of applying f to the funclib.Core.First( 2 items in coll, then applying f to the result and 
    /// the 3rd item, etc. If coll contains no items, f must implement <see cref="IFunction{TResult}"/> 
    /// interface and reduce returns the result of calling f with no arguments. If coll has only 1 item,
    /// it is returned and f is not called. If val is supplied, returns the result of applying f to val
    /// and the funclib.Core.First( item in coll, then applying f to the result and the 2nd item, etc. If coll contains 
    /// no items, val is returned and f is not called.
    /// </summary>
    public class Reduce :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// f should implement the <see cref="IFunction{T1, T2, TResult}"/> interface. If val is not supplied,
        /// returns the result of applying f to the funclib.Core.First( 2 items in coll, then applying f to the result and 
        /// the 3rd item, etc. If coll contains no items, f must implement <see cref="IFunction{TResult}"/> 
        /// interface and reduce returns the result of calling f with no arguments. If coll has only 1 item,
        /// it is returned and f is not called. If val is supplied, returns the result of applying f to val
        /// and the funclib.Core.First( item in coll, then applying f to the result and the 2nd item, etc. If coll contains 
        /// no items, val is returned and f is not called.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction{T1, T2, TResult}"/> interface unless coll has not items, then it needs to implement the <see cref="IFunction{TResult}"/> interface.</param>
        /// <param name="coll">The collection to reduce.</param>
        /// <returns>
        /// Returns the result of calling f to the 1st and 2nd items, then calling f with the result and 3rd item, etc.
        /// </returns>
        public object Invoke(object f, object coll) =>
            coll is IReduce r
                ? r.Reduce(f)
                : coll is null ? funclib.Core.Invoke(f)
                : coll is ASeq ? SeqReduce(coll, f)
                : coll is LazySeq ? SeqReduce(coll, f)
                : coll is IVector ? SeqReduce(coll, f)
                : coll is System.Collections.IEnumerable e ? IterReduce(e, f)
                //: coll is KeySeq ? IterReduce(coll, f)
                //: coll is ValueSeq ? IterReduce(coll, f)
                : SeqReduce(coll, f);

        /// <summary>
        /// f should implement the <see cref="IFunction{T1, T2, TResult}"/> interface. If val is not supplied,
        /// returns the result of applying f to the funclib.Core.First( 2 items in coll, then applying f to the result and 
        /// the 3rd item, etc. If coll contains no items, f must implement <see cref="IFunction{TResult}"/> 
        /// interface and reduce returns the result of calling f with no arguments. If coll has only 1 item,
        /// it is returned and f is not called. If val is supplied, returns the result of applying f to val
        /// and the funclib.Core.First( item in coll, then applying f to the result and the 2nd item, etc. If coll contains 
        /// no items, val is returned and f is not called.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="val">The initial starting value.</param>
        /// <param name="coll">The collection to reduce over.</param>
        /// <returns>
        /// Returns the result of calling f to val and 1st, then calling f with the result and 2nd, etc.
        /// </returns>
        public object Invoke(object f, object val, object coll) =>
            coll is IReduce r
                ? r.Reduce(f, val)
                : coll is null ? val
                : coll is ASeq ? SeqReduce(coll, f, val)
                : coll is LazySeq ? SeqReduce(coll, f, val)
                : coll is IVector ? SeqReduce(coll, f, val)
                : coll is System.Collections.IEnumerable e ? IterReduce(e, f, val)
                //: coll is KeySeq ? IterReduce(coll, f, val)
                //: coll is ValueSeq ? IterReduce(coll, f, val)
                : SeqReduce(coll, f, val);


        static object SeqReduce(object coll, object f)
        {
            var s = funclib.Core.Seq(coll);
            if ((bool)funclib.Core.Truthy(s))
            {
                return InternalReduce(funclib.Core.Next(s), f, funclib.Core.First(s));
            }

            return funclib.Core.Invoke(f);
        }

        static object SeqReduce(object coll, object f, object val) => InternalReduce(funclib.Core.Seq(coll), f, val);

        static object IterReduce(System.Collections.IEnumerable coll, object f)
        {
            var iter = coll.GetEnumerator();
            if (iter.MoveNext())
            {
                return loop(iter.Current, f);
            }

            return funclib.Core.Invoke(f);

            object loop(object ret, object fn)
            {
                if (iter.MoveNext())
                {
                    ret = funclib.Core.Invoke(fn, ret, iter.Current);
                    if (ret is Reduced r)
                        return r.Deref();
                    return loop(ret, fn);
                }
                return ret;
            }
        }

        static object IterReduce(System.Collections.IEnumerable coll, object f, object val)
        {
            var iter = coll.GetEnumerator();
            return loop(val, f);

            object loop(object ret, object fn)
            {
                if (iter.MoveNext())
                {
                    ret = funclib.Core.Invoke(fn, ret, iter.Current);
                    if (ret is Reduced r)
                        return r.Deref();
                    return loop(ret, fn);
                }
                return ret;
            }
        }

        static object InternalReduce(object s, object f, object val) =>
            s is null
                ? val
                : s is IChunkedSeq ? IChunkedSeqReduce(s, f, val)
                : s is StringSeq strSeq ? StringSeqReduce(strSeq, f, val)
                : ObjectReduce(s, f, val);

        static object IChunkedSeqReduce(object s, object f, object val)
        {
            s = funclib.Core.Seq(s);
            if ((bool)funclib.Core.Truthy(s))
            {
                if ((bool)funclib.Core.IsChunkedSeq(s))
                {
                    var ret = ((IChunked)funclib.Core.ChunkFirst(s)).Reduce(f, val);
                    if (ret is Reduced r)
                        return r.Deref();
                    return IChunkedSeqReduce(funclib.Core.ChunkNext(s), f, ret);
                }

                return InterfaceOrNaiveReduce(s, f, val);
            }
            return val;
        }

        static object StringSeqReduce(StringSeq strSeq, object f, object val)
        {
            var s = strSeq.S;
            var len = s.Length;

            return loop(strSeq.I, val);

            object loop(int i, object v)
            {
                if (i < len)
                {
                    var ret = funclib.Core.Invoke(f, v, s[i]);
                    if (ret is Reduced r)
                        return r.Deref();
                    return loop((int)funclib.Core.Inc(i), ret);
                }
                return v;
            }
        }

        static object ObjectReduce(object s, object f, object val)
        {
            return loop(funclib.Core.Class(s), s, val);

            object loop(object cls, object c, object v)
            {
                var sq = funclib.Core.Seq(c);
                if ((bool)funclib.Core.Truthy(sq))
                {
                    if ((bool)funclib.Core.IsIdentical(funclib.Core.Class(sq), cls))
                    {
                        var ret = funclib.Core.Invoke(f, v, funclib.Core.First(sq));
                        if (ret is Reduced r)
                            return r.Deref();
                        return loop(cls, funclib.Core.Next(sq), ret);
                    }

                    return InterfaceOrNaiveReduce(sq, f, v);
                }
                return v;
            }
        }

        static object InterfaceOrNaiveReduce(object coll, object f, object val)
        {
            if (coll is IReduce r)
                return r.Reduce(f, val);

            return NaiveSeqReduce(coll, f, val);
        }

        static object NaiveSeqReduce(object coll, object f, object val)
        {
            return loop(coll, val);

            object loop(object s, object v)
            {
                var sq = funclib.Core.Seq(s);
                if ((bool)funclib.Core.Truthy(sq))
                {
                    var ret = funclib.Core.Invoke(f, v, funclib.Core.First(sq));
                    if (ret is Reduced r)
                        return r.Deref();

                    return loop(funclib.Core.Next(sq), ret);
                }
                return v;
            }
        }
    }
}
