using System.Collections.Generic;

namespace Base
{
    public abstract class Observable<T>
    {
        private readonly ICollection<IObserver<T>> _observers = 
            new HashSet<IObserver<T>>();

        public void Attach(IObserver<T> observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver<T> observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(T value)
        {
            foreach (var observer in _observers)
            {
                observer.Dispose(value);
            }
        }
    }
}
