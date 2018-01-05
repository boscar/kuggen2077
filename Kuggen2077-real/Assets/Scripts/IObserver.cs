using System;

public interface IObserver<T> {
	void onUpdate(T data);
}


