using FunctionalLibrary.Collections;
using FunctionalLibrary.Collections.Internal;
using System;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Reduce :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
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
                    if (ret is Collections.Reduced r)
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
                    if (ret is Collections.Reduced r)
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
                    if (ret is Collections.Reduced r)
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
                    if (ret is Collections.Reduced r)
                        return r.Deref();
                    return loop((int)new Inc().Invoke(i), ret);
                }
                return v;
            }
        }

        object ObjectReduce(object s, IFunction<object, object, object> f, object val)
        {
            return loop((Type)new Class().Invoke(s), s, val);

            object loop(Type cls, object c, object v)
            {
                var seq = (ISeq)new Seq().Invoke(c);
                if ((bool)new Truthy().Invoke(seq))
                {
                    if ((bool)new IsIdentical().Invoke(new Class().Invoke(seq), cls))
                    {
                        var ret = f.Invoke(v, seq.First());
                        if (ret is Collections.Reduced r)
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
                    if (ret is Collections.Reduced r)
                        return r.Deref();

                    return loop(seq.Next(), ret);
                }
                return v;
            }
        }
    }
}
