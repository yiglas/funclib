namespace funclib.Collections.Generic.Internal
{
    class Box<T>
    {
        public T Value { get; set; }

        public Box(T value)
        {
            Value = value;
        }
    }
}