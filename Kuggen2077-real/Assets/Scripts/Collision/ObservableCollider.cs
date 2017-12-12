﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableCollider : MonoBehaviour {

	private List<IColliderObserver> observers;

	protected void Start() {
		observers = new List<IColliderObserver> ();
	}

	public void addObserver(IColliderObserver obs){
		observers.Add (obs);
	}

	public void removeObserver(IColliderObserver obs){
		observers.Remove (obs);
	}

	void OnTriggerEnter(Collider collider) {
		foreach (IColliderObserver co in observers){
			Debug.Log ("OBSerVEr TRIGGER: " + co.ToString());
			co.HandleTriggerEnter (collider);
		}
	}
		
   	void OnTriggerStay(Collider collider) {
		foreach (IColliderObserver co in observers){
			co.HandleTriggerStay (collider);
		}
    }

	void OnTriggerExit(Collider collider) {
		foreach (IColliderObserver co in observers){
			co.HandleTriggerExit (collider);
		}
	}
		
}
