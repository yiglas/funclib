using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of the nodes in a tree, via a depth-first walk.
    /// </summary>
    public class TreeSeq :
        IFunction<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the nodes in a tree, via a depth-first walk.
        /// </summary>
        /// <param name="branch">An object that implements <see cref="IFunction{T1, TResult}"/> interface that returns true if passed a node
        /// that can have children, otherwise false.</param>
        /// <param name="children">An object that implements <see cref="IFunction{T1, TResult}"/> interface that returns a sequence of the children.</param>
        /// <param name="root">An object for the root node of the tree.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of the nodes in a tree. 
        /// </returns>
        public object Invoke(object branch, object children, object root) => new Walk(branch, children).Invoke(root);

        class Walk :
            IFunction<object, object>
        {
            IFunction<object, object> _branch;
            IFunction<object, object> _children;
            
            public Walk(object branch, object children)
            {
                this._branch = (IFunction<object, object>)branch;
                this._children = (IFunction<object, object>)children;
            }

            public object Invoke(object node) =>
                new LazySeq(() => 
                    new Cons().Invoke(node,
                        (bool)new Truthy().Invoke(this._branch.Invoke(node))
                            ? new MapCat().Invoke(this, this._children.Invoke(node))
                            : null));
        }
    }
}
