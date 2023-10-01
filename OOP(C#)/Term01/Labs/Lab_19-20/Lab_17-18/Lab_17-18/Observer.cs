using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_18
{
    public interface IObservable
    {
        public void AddObserver(IObserver o);
        public void RemoveObserver(IObserver o);
        public void NotifyObservers(string message);
    }
    public class BankObservable : IObservable
    {
        private List<IObserver> observers;
        public BankObservable()
        {
            observers = new List<IObserver>();
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers(string message)
        {
            foreach (IObserver observer in observers)
                observer.Update(message);
        }
    }

    public interface IObserver
    {
        public void Update(string message);
    }
}
