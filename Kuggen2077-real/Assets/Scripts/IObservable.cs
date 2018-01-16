using System;

public interface IObservable<T> {
	void AddObserver(IObserver<T> obs);
	void RemoveObserver(IObserver<T> obs);
	void CallObservers();
}


