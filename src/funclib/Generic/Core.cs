﻿using System;
using funclib.Collections;
using funclib.Collections.Generic;
using funclib.Components.Core.Generic;
using System;

namespace funclib.Generic
{
    public static class Core<T>
    {
        public static IsEqualTo<T> isEqualTo => new IsEqualTo<T>();
        public static Compare<T> compare => new Compare<T>();
        public static And<T> and => new And<T>();
        public static Seq<T> seq => new Seq<T>();
        public static First<T> first => new First<T>();
        public static Next<T> next => new Next<T>();
        public static Count<T> count => new Count<T>();
        public static funclib.Components.Core.Generic.Cons<T> cons => new funclib.Components.Core.Generic.Cons<T>();
        public static funclib.Components.Core.Generic.List<T> list => new funclib.Components.Core.Generic.List<T>();
    }

    public static class Core<TKey, TValue>
    {
        public static Count<TKey, TValue> count => new Count<TKey, TValue>();
    }

    public static class Core
    {
        public static And and => new And();
        public static Seq seq => new Seq();
        public static First first => new First();
        public static Next next => new Next();
        public static Count count => new Count();
        public static funclib.Components.Core.Generic.Cons cons => new funclib.Components.Core.Generic.Cons();

        public static bool IsEqualTo<T>(T x) => Core<T>.isEqualTo.Invoke(x);
        public static bool IsEqualTo<T>(T x, T y) => Core<T>.isEqualTo.Invoke(x, y);
        public static int Compare<T>(T x, T y) => Core<T>.compare.Invoke(x, y);
        public static bool And() => and.Invoke();
        public static T And<T>(T x) => Core<T>.and.Invoke(x);
        public static T And<T>(T x, T y) => Core<T>.and.Invoke(x, y);
        public static ISeq<T> Seq<T>(ASeq<T> coll) => Core<T>.seq.Invoke(coll);
        public static ISeq<T> Seq<T>(ISeqable<T> coll) => Core<T>.seq.Invoke(coll);
        public static ISeq<T> Seq<T>(System.Collections.Generic.IEnumerable<T> coll) => Core<T>.seq.Invoke(coll);
        public static ISeq<T> Seq<T>(params T[] coll) => Core<T>.seq.Invoke(coll);
        public static ISeq<T> Seq<T>(T coll) => Core<T>.seq.Invoke(coll);
        public static ISeq<char> Seq(string coll) => seq.Invoke(coll);
        public static T First<T>(ASeq<T> coll) => Core<T>.first.Invoke(coll);
        public static T First<T>(ISeqable<T> coll) => Core<T>.first.Invoke(coll);
        public static T First<T>(System.Collections.Generic.IEnumerable<T> coll) => Core<T>.first.Invoke(coll);
        public static T First<T>(params T[] coll) => Core<T>.first.Invoke(coll);
        public static T First<T>(T coll) => Core<T>.first.Invoke(coll);
        public static char First(string coll) => first.Invoke(coll);
        public static ISeq<T> Next<T>(ASeq<T> coll) => Core<T>.next.Invoke(coll);
        public static ISeq<T> Next<T>(ISeqable<T> coll) => Core<T>.next.Invoke(coll);
        public static ISeq<T> Next<T>(System.Collections.Generic.IEnumerable<T> coll) => Core<T>.next.Invoke(coll);
        public static ISeq<T> Next<T>(params T[] coll) => Core<T>.next.Invoke(coll);
        public static ISeq<T> Next<T>(T coll) => Core<T>.next.Invoke(coll);
        public static ISeq<char> Next(string coll) => next.Invoke(coll);
        public static Function<T> Func<T>(Func<T> x) => new Function<T>(x);
        public static int Count(ICounted coll) => count.Invoke(coll);
        public static int Count(string coll) => count.Invoke(coll);
        public static int Count<T>(ICollection<T> coll) => Core<T>.count.Invoke(coll);
        public static int Count<T>(T coll) => Core<T>.count.Invoke(coll);
        public static int Count<T>(System.Collections.Generic.ICollection<T> coll) => Core<T>.count.Invoke(coll);
        public static int Count<TKey, TValue>(IKeyValuePair<TKey, TValue> coll) => Core<TKey, TValue>.count.Invoke(coll);
        public static int Count<TKey, TValue>(System.Collections.Generic.KeyValuePair<TKey, TValue> coll) => Core<TKey, TValue>.count.Invoke(coll);
        public static ISeq<T> Cons<T>(T x, ASeq<T> coll) => Core<T>.cons.Invoke(x, coll);
         public static ISeq<T> Cons<T>(T x, ISeq<T> coll) => Core<T>.cons.Invoke(x, coll);
        public static ISeq<T> Cons<T>(T x, ISeqable<T> coll) => Core<T>.cons.Invoke(x, coll);
        public static ISeq<T> Cons<T>(T x, System.Collections.Generic.IEnumerable<T> coll) => Core<T>.cons.Invoke(x, coll);
        public static ISeq<T> Cons<T>(T x, params T[] coll) => Core<T>.cons.Invoke(x, coll);
        public static ISeq<T> Cons<T>(T x, T coll) => Core<T>.cons.Invoke(x, coll);
        public static ISeq<char> Cons(char x, string coll) => cons.Invoke(x, coll);

        public static Collections.Generic.List<T> List<T>(params T[] items) => Core<T>.list.Invoke(items);

        public static LazySeq<T> LazySeq<T>() => new LazySeq<T>();
        public static LazySeq<T> LazySeq<T>(Func<T> fn) => new LazySeq<T>(fn);
        public static LazySeq<T> LazySeq<T>(IFunction<T> fn) => new LazySeq<T>(fn);
        public static LazySeq<T> LazySeq<T>(T body) => new LazySeq<T>(body);
    }
}
