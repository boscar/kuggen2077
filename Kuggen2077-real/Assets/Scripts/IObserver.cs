﻿using System;

public interface IObserver<T> {
	void OnUpdate(T data);
}


