namespace Base
{
    public interface IObserver<T>
    {
        void Dispose(T value);
    }
}
