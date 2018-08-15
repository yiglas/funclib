namespace funclib.Collections.Internal
{
    interface ITransientSet : 
        ITransientCollection,
        ICounted
    {
        new int Count { get; }
        ITransientSet Disjoin(object key);
        bool Contains(object key);
        object Get(object key);        
    }
}
