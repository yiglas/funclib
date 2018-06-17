using FunctionalLibrary.Collections.Internal;
using FunctionalLibrary.Core;
using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public class SortedMap : 
        AMap,
        ISorted,
        IReduceKV
    {
        public static readonly SortedMap EMPTY = new SortedMap();

        readonly System.Collections.IComparer _comp;
        readonly RedBlackNode _tree;
        readonly int _count;

        SortedMap() : this(DefaultComparer.Instance, null, 0) { }
        internal SortedMap(System.Collections.IComparer comp) : this(comp, null, 0) { }
        SortedMap(System.Collections.IComparer comp, RedBlackNode tree, int count)
        {
            this._comp = comp;
            this._tree = tree;
            this._count = count;
        }

        #region Creates
        public static SortedMap Create(System.Collections.IDictionary init)
        {
            IMap ret = EMPTY;
            foreach (System.Collections.DictionaryEntry item in init)
                ret = ret.Assoc(item.Key, item.Value);
            return ret as SortedMap;    
        }

        public static SortedMap Create(ISeq init)
        {
            IMap ret = EMPTY;
            for (; init != null; init = init.Next().Next())
            {
                if (init.Next() == null)
                    throw new ArgumentException($"No value supplied for key: {init.First()}");
                ret = ret.Assoc(init.First(), init.Next().First());
            }
            return ret as SortedMap;
        }

        public static SortedMap Create(System.Collections.IComparer comp, ISeq init)
        {
            IMap ret = new SortedMap(comp);
            for (; init != null; init = init.Next().Next())
            {
                if (init.Next() == null)
                    throw new ArgumentException($"No value supplied for key: {init.First()}");
                ret = ret.Assoc(init.First(), init.Next().First());
            }
            return ret as SortedMap;
        }
        #endregion

        #region Overrides
        public override int Count => this._count;
        public override bool ContainsKey(object key) => NodeAt(key) != null;
        public override IKeyValuePair Get(object key)
        {
            var n = NodeAt(key);
            if (n != null)
                return new KeyValuePair(n.Key, n.Value);
            return null;
        }
        public override object GetValue(object key) => GetValue(key, null);
        public override object GetValue(object key, object notFound)
        {
            var n = NodeAt(key);
            return n != null ? n.Value : notFound;
        }
        public override ICollection Empty() => new SortedMap(this._comp);
        public override ISeq Seq() => this._count > 0 ? new SortedMapSeq(this._tree, true, this._count) : null;
        public override IMap Assoc(object key, object val)
        {
            var found = new Box(null);
            var t = Add(this._tree, key, val, found);
            if (t == null)
            {
                var foundNode = found.Value as RedBlackNode;
                if (foundNode.Value == val)
                    return this;

                return new SortedMap(this._comp, Replace(this._tree, key, val), this._count);
            }

            return new SortedMap(this._comp, t.Blacken(), this._count + 1);
        }
        public override IMap Without(object key)
        {
            var found = new Box(null);
            var t = Remove(this._tree, key, found);
            if (t == null)
            {
                if (found.Value == null) return this;

                return new SortedMap(this._comp);
            }

            return new SortedMap(this._comp, t.Blacken(), this._count - 1);
        }
        #endregion

        public System.Collections.IComparer GetComparator() => this._comp;

        public ISeq Seq(bool ascending) => this._count > 0 ? new SortedMapSeq(this._tree, ascending, this._count) : null;
        public ISeq Seq(object key, bool ascending)
        {
            if (this._count > 0)
            {
                ISeq stack = null;
                var t = this._tree;
                while (t != null)
                {
                    int c = this._comp.Compare(key, t.Key);
                    if (c == 0)
                    {
                        stack = (ISeq)new Core.Cons().Invoke(t, stack);
                        return new SortedMapSeq(stack, ascending);
                    }
                    else if (ascending)
                    {
                        if (c < 0)
                        {
                            stack = (ISeq)new Core.Cons().Invoke(t, stack);
                            t = t.Left;
                        }
                        else
                            t = t.Right;
                    }
                    else
                    {
                        if (c > 0)
                        {
                            stack = (ISeq)new Core.Cons().Invoke(t, stack);
                            t = t.Right;
                        }
                        else
                            t = t.Left;
                    }
                }
                if (stack != null)
                    return new SortedMapSeq(stack, ascending);
            }

            return null;
        }


        public override System.Collections.IEnumerator GetKeyEnumerator() => throw new NotImplementedException();
        public override System.Collections.IEnumerator GetValueEnumerator() => throw new NotImplementedException();
        public override ITransientCollection ToTransient() => throw new NotImplementedException();


        RedBlackNode NodeAt(object key)
        {
            var t = this._tree;
            while (t != null)
            {
                int c = this._comp.Compare(key, t.Key);
                if (c == 0) return t;
                else if (c < 0) t = t.Left;
                else t = t.Right;
            }
            return t;
        }

        RedBlackNode Add(RedBlackNode t, object key, object val, Box found)
        {
            if (t == null)
                return val == null ? new RedNode(key) : new RedValueNode(key, val);
            int c = this._comp.Compare(key, t.Key);
            if (c == 0)
            {
                found.Value = t;
                return null;
            }
            var insert = c < 0 ? Add(t.Left, key, val, found) : Add(t.Right, key, val, found);
            if (insert == null) return null;
            return c < 0
                ? t.AddLeft(insert)
                : t.AddRight(insert);
        }

        RedBlackNode Replace(RedBlackNode t, object key, object val)
        {
            int c = this._comp.Compare(key, t.Key);
            return t.Replace(t.Key,
                c == 0 ? val : t.Value,
                c < 0 ? Replace(t.Left, key, val) : t.Left,
                c > 0 ? Replace(t.Right, key, val) : t.Right);
        }

        RedBlackNode Remove(RedBlackNode t, object key, Box found)
        {
            if (t == null) return null;
            int c = this._comp.Compare(key, t.Key);
            if (c == 0)
            {
                found.Value = t;
                return Append(t.Left, t.Right);
            }
            var delete = c < 0 ? Remove(t.Left, key, found) : Remove(t.Right, key, found);
            if (delete == null && found.Value == null) return null;
            if (c < 0)
                return (t.Left is BlackNode)
                    ? BalanceLeftDelete(t.Key, t.Value, delete, t.Right)
                    : MakeRed(t.Key, t.Value, delete, t.Right);
            return (t.Right is BlackNode)
                ? BalanceRightDelete(t.Key, t.Value, t.Left, delete)
                : MakeRed(t.Key, t.Value, t.Left, delete);
        }

        static RedBlackNode Append(RedBlackNode left, RedBlackNode right)
        {
            if (left == null) return right;
            if (right == null) return left;
            else if (left is RedNode)
            {
                if (right is RedNode)
                {
                    var app = Append(left.Right, right.Left);
                    return app is RedNode
                        ? MakeRed(app.Key, app.Value,
                              MakeRed(left.Key, left.Value, left.Left, app.Left),
                              MakeRed(right.Key, right.Value, app.Right, right.Right))
                        : MakeRed(left.Key, left.Value, left.Left, MakeRed(right.Key, right.Value, app, right.Right));
                }
                else
                    return MakeRed(left.Key, left.Value, left.Left, Append(left.Right, right));
            }
            else if (right is RedNode)
                return MakeRed(right.Key, right.Value, Append(left, right.Left), right.Right);
            else
            {
                var app = Append(left.Right, right.Left);
                return (app is RedNode)
                    ? MakeRed(app.Key, app.Value,
                                  MakeBlack(left.Key, left.Value, left.Left, app.Left),
                                  MakeBlack(right.Key, right.Value, app.Right, right.Right))
                                  : BalanceLeftDelete(left.Key, left.Value, left.Left, MakeBlack(right.Key, right.Value, app, right.Right));
            }
        }

        internal static RedNode MakeRed(object key, object val, RedBlackNode left, RedBlackNode right)
        {
            if (left == null && right == null)
            {
                if (val == null)
                    return new RedNode(key);
                return new RedValueNode(key, val);
            }
            if (val == null)
                return new RedBranchNode(key, left, right);

            return new RedBranchValueNode(key, val, left, right);
        }

        internal static BlackNode MakeBlack(object key, object val, RedBlackNode left, RedBlackNode right)
        {
            if (left == null && right == null)
            {
                if (val == null)
                    return new BlackNode(key);
                return new BlackValueNode(key, val);
            }
            if (val == null)
                return new BlackBranchNode(key, left, right);

            return new BlackBranchValueNode(key, val, left, right);
        }

        internal static RedBlackNode BalanceLeftDelete(object key, object val, RedBlackNode del, RedBlackNode right)
        {
            if (del is RedNode)
                return MakeRed(key, val, del.Blacken(), right);
            else if (right is BlackNode)
                return RightBalance(key, val, del, right.Redden());
            else if (right is RedNode && right.Left is BlackNode)
                return MakeRed(right.Left.Key, right.Left.Value,
                    MakeBlack(key, val, del, right.Left.Left),
                    RightBalance(right.Key, right.Value, right.Left.Right, right.Right.Redden()));

            throw new InvalidOperationException("Invariant violation");
        }

        internal static RedBlackNode BalanceRightDelete(object key, object val, RedBlackNode left, RedBlackNode del)
        {
            if (del is RedNode)
                return MakeRed(key, val, left, del.Blacken());
            else if (left is BlackNode)
                return LeftBalance(key, val, left.Redden(), del);
            else if (left is RedNode && left.Right is BlackNode)
                return MakeRed(left.Right.Key, left.Right.Value,
                           LeftBalance(left.Key, left.Value, left.Left.Redden(), left.Right.Left),
                           MakeBlack(key, val, left.Right.Right, del));
            else
                throw new InvalidOperationException("Invariant violation");
        }

        internal static RedBlackNode RightBalance(object key, object val, RedBlackNode left, RedBlackNode insert)
        {
            if (insert is RedNode && insert.Right is RedNode)
                return MakeRed(insert.Key, insert.Value, MakeBlack(key, val, left, insert.Left), insert.Right.Blacken());
            else if (insert is RedNode && insert.Left is RedNode)
                return MakeRed(insert.Left.Key, insert.Left.Value,
                           MakeBlack(key, val, left, insert.Left.Left),
                           MakeBlack(insert.Key, insert.Value, insert.Left.Right, insert.Right));
            else
                return MakeBlack(key, val, left, insert);
        }

        internal static RedBlackNode LeftBalance(object key, object val, RedBlackNode insert, RedBlackNode right)
        {
            if (insert is RedNode && insert.Left is RedNode)
                return MakeRed(insert.Key, insert.Value, insert.Left.Blacken(), MakeBlack(key, val, insert.Right, right));
            else if (insert is RedNode && insert.Right is RedNode)
                return MakeRed(insert.Right.Key, insert.Right.Value,
                            MakeBlack(insert.Key, insert.Value, insert.Left, insert.Right.Left),
                            MakeBlack(key, val, insert.Right.Right, right));
            else
                return MakeBlack(key, val, insert, right);
        }

        public object ReduceKV(IFunction f, object init)
        {
            if (this._tree != null)
                init = this._tree.Reduce(f, init);
            if (init is Reduced r)
                return r.Deref();
            return init;
        }
    }
}
