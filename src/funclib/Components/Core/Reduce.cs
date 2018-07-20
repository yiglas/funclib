using funclib.Collections;
using funclib.Collections.Internal;
using System;
using System.Linq;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// f should implement the <see cref="IFunction{T1, T2, TResult}"/> interface. If val is not supplied,
    /// returns the result of applying f to the first 2 items in coll, then applying f to the result and 
    /// the 3rd item, etc. If coll contains no items, f must implement <see cref="IFunction{TResult}"/> 
    /// interface and reduce returns the result of calling f with no arguments. If coll has only 1 item,
    /// it is returned and f is not called. If val is supplied, returns the result of applying f to val
    /// and the first item in coll, then applying f to the result and the 2nd item, etc. If coll contains 
    /// no items, val is returned and f is not called.
    /// </summary>
    public class Reduce :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// f should implement the <see cref="IFunction{T1, T2, TResult}"/> interface. If val is not supplied,
        /// returns the result of applying f to the first 2 items in coll, then applying f to the result and 
        /// the 3rd item, etc. If coll contains no items, f must implement <see cref="IFunction{TResult}"/> 
        /// interface and reduce returns the result of calling f with no arguments. If coll has only 1 item,
        /// it is returned and f is not called. If val is supplied, returns the result of applying f to val
        /// and the first item in coll, then applying f to the result and the 2nd item, etc. If coll contains 
        /// no items, val is returned and f is not called.
        /// </summary>
        /// <param name="f">An object that implements <see cref="IFunction{T1, T2, TResult}"/> interface unless coll has not items, then it needs to implement the <see cref="IFunction{TResult}"/> interface.</param>
        /// <param name="coll">The collection to reduce.</param>
        /// <returns>
        /// Returns the result of calling f to the 1st and 2nd items, then calling f with the result and 3rd item, etc.
        /// </returns>
        public object Invoke(object f, object coll) =>
            coll is IReduce r
                ? r.Reduce((IFunction<object, object, object>)f)
                : coll is null ? ((IFunction<object>)f).Invoke()
                : coll is ASeq ? SeqReduce(coll, f)
                : coll is LazySeq ? SeqReduce(coll, f)
                : coll is IVector ? SeqReduce(coll, f)
                : coll is System.Collections.IEnumerable e ? IterReduce(e, f)
                //: coll is KeySeq ? IterReduce(coll, f)
                //: coll is ValueSeq ? IterReduce(coll, f)
                : SeqReduce(coll, f);

        /// <summary>
        /// f should implement the <see cref="IFunction{T1, T2, TResult}"/> interface. If val is not supplied,
        /// returns the result of applying f to the first 2 items in coll, then applying f to the result and 
        /// the 3rd item, etc. If coll contains no items, f must implement <see cref="IFunction{TResult}"/> 
        /// interface and reduce returns the result of calling f with no arguments. If coll has only 1 item,
        /// it is returned and f is not called. If val is supplied, returns the result of applying f to val
        /// and the first item in coll, then applying f to the result and the 2nd item, etc. If coll contains 
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
                ? r.Reduce((IFunction<object, object, object>)f, val)
                : coll is null ? val
                : coll is ASeq ? SeqReduce(coll, f, val)
                : coll is LazySeq ? SeqReduce(coll, f, val)
                : coll is IVector ? SeqReduce(coll, f, val)
                : coll is System.Collections.IEnumerable e ? IterReduce(e, f, val)
                //: coll is KeySeq ? IterReduce(coll, f, val)
                //: coll is ValueSeq ? IterReduce(coll, f, val)
                : SeqReduce(coll, f, val);


        object SeqReduce(object coll, object f)
        {
            var s = (ISeq)new Seq().Invoke(coll);
            if ((bool)new Truthy().Invoke(s))
            {
                var fn = (IFunction<object, object, object>)f;
                return InternalReduce(s.Next(), fn, s.First());
            }

            return ((IFunction<object>)f).Invoke();
        }

        object SeqReduce(object coll, object f, object val)
        {
            var s = (ISeq)new Seq().Invoke(coll);
            return InternalReduce(s, (IFunction<object, object, object>)f, val);
        }

        object IterReduce(System.Collections.IEnumerable coll, object f)
        {
            var iter = coll.GetEnumerator();
            if (iter.MoveNext())
            {
                return loop(iter.Current, (IFunction<object, object, object>)f);
            }

            return ((IFunction<object>)f).Invoke();

            object loop(object ret, IFunction<object, object, object> fn)
            {
                if (iter.MoveNext())
                {
                    ret = fn.Invoke(ret, iter.Current);
                    if (ret is Reduced r)
                        return r.Deref();
                    return loop(ret, fn);
                }
                return ret;
            }
        }

        object IterReduce(System.Collections.IEnumerable coll, object f, object val)
        {
            var iter = coll.GetEnumerator();
            return loop(val, (IFunction<object, object, object>)f);

            object loop(object ret, IFunction<object, object, object> fn)
            {
                if (iter.MoveNext())
                {
                    var let = fn.Invoke(ret, iter.Current);
                    if (ret is Reduced r)
                        return r.Deref();
                    return loop(ret, fn);
                }
                return ret;
            }
        }

        object InternalReduce(object s, IFunction<object, object, object> f, object val) =>
            s == null
                ? val
                : s is IChunkedSeq ? IChunkedSeqReduce(s, f, val)
                : s is StringSeq strSeq ? StringSeqReduce(strSeq, f, val)
                : ObjectReduce(s, f, val);

        object IChunkedSeqReduce(object s, IFunction<object, object, object> f, object val)
        {
            s = new Seq().Invoke(s);
            if ((bool)new Truthy().Invoke(s))
            {
                if ((bool)new IsChunkedSeq().Invoke(s))
                {
                    var ret = ((IChunked)new ChunkFirst().Invoke(s)).Reduce(f, val);
                    if (ret is Reduced r)
                        return r.Deref();
                    return IChunkedSeqReduce(new ChunkNext().Invoke(s), f, ret);
                }

                return InterfaceOrNaiveReduce(s, f, val);
            }
            return val;
        }

        object StringSeqReduce(StringSeq strSeq, IFunction<object, object, object> f, object val)
        {
            var s = strSeq.S;
            var len = s.Length;

            return loop(strSeq.I, val);

            object loop(int i, object v)
            {
                if (i < len)
                {
                    var ret = f.Invoke(v, s[i]);
                    if (ret is Reduced r)
                        return r.Deref();
                    return loop((int)new Inc().Invoke(i), ret);
                }
                return v;
            }
        }

        object ObjectReduce(object s, IFunction<object, object, object> f, object val)
        {
            return loop((Type)@class(s), s, val);

            object loop(Type cls, object c, object v)
            {
                var seq = (ISeq)new Seq().Invoke(c);
                if ((bool)new Truthy().Invoke(seq))
                {
                    if ((bool)new IsIdentical().Invoke(@class(seq), cls))
                    {
                        var ret = f.Invoke(v, seq.First());
                        if (ret is Reduced r)
                            return r.Deref();
                        return loop(cls, seq.Next(), ret);
                    }

                    return InterfaceOrNaiveReduce(seq, f, v);
                }
                return v;
            }
        }

        object InterfaceOrNaiveReduce(object coll, IFunction<object, object, object> f, object val)
        {
            if (coll is IReduce r)
                return r.Reduce(f, val);

            return NaiveSeqReduce(coll, f, val);
        }

        object NaiveSeqReduce(object coll, IFunction<object, object, object> f, object val)
        {
            return loop(coll, val);

            object loop(object s, object v)
            {
                var seq = (ISeq)new Seq().Invoke(s);
                if ((bool)new Truthy().Invoke(seq))
                {
                    var ret = f.Invoke(v, seq.First());
                    if (ret is Reduced r)
                        return r.Deref();

                    return loop(seq.Next(), ret);
                }
                return v;
            }
        }
    }
}
