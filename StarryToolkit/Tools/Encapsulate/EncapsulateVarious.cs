namespace StarryToolkits.Tools.Encapsulate;

public class EncapsulateVarious<T>
{
    private T? _value=default(T);

    public T? Value
    {
        get => _value;
        protected set => _value = value;
    }
}