namespace Base
{
    public interface IObserver<T>
    {
        void Update(T value);
    }
}
