using System;
using UnityEngine;

public interface IColliderObserver {
	void HandleTriggerEnter(Collider col);
	void HandleTriggerStay(Collider col);
	void HandleTriggerExit(Collider col);
}


