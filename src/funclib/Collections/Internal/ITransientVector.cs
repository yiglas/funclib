namespace funclib.Collections.Internal
{
    interface ITransientVector :
        ITransientAssociative,
        ICounted
    {
        new IVector ToPersistent();

        object this[int index] { get; set; }
        object this[int index, object notFound] { get; set; }

        ITransientVector Assoc(int i, object val);
        ITransientVector Pop();
    }
}
