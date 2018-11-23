namespace funclib.Components.Core.Generic
{
    public class Falsy<T> :
        IFunction<T, bool>
    {
        public bool Invoke(T source)
        {
            if (source == null)
                return true;
            else if (source is bool b)
                return !b;
            else 
                return false;
        }
    }
}