using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the nodes in a tree, via a depth-funclib.Core.First( walk.
    /// </summary>
    public class TreeSeq :
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the nodes in a tree, via a depth-funclib.Core.First( walk.
        /// </summary>
        /// <param name="branch">An object that implements <see cref="IFunction{T1, TResult}"/> interface that returns true if passed a node
        /// that can have children, otherwise false.</param>
        /// <param name="children">An object that implements <see cref="IFunction{T1, TResult}"/> interface that returns a sequence of the children.</param>
        /// <param name="root">An object for the root node of the tree.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> of the nodes in a tree.
        /// </returns>
        public object Invoke(object branch, object children, object root) => new Walk(branch, children).Invoke(root);

        class Walk :
            IFunction<object, object>
        {
            object _branch;
            object _children;

            public Walk(object branch, object children)
            {
                this._branch = branch;
                this._children = children;
            }

            public object Invoke(object node) =>
                funclib.Core.LazySeq(() =>
                    funclib.Core.Cons(node,
                        funclib.Core.T(funclib.Core.Invoke(this._branch, node))
                            ? funclib.Core.MapCat(this, funclib.Core.Invoke(this._children, node))
                            : null));
        }
    }
}
