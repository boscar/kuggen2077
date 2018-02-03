using System;
using System.Collections.Generic;

public interface IObservable<T> {
	void AddObserver(IObserver<T> obs);
	void RemoveObserver(IObserver<T> obs);
	void CallObservers();
	List<IObserver<T>> Observers { get; }
}


