using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectView : MonoBehaviour {

	public enum State { DISCONNECTED, CONNECTED, READY }

	// Use this for initialization
	void Start () {
	}
	
	public void setState(State s) {
		switch (s) {
			case State.DISCONNECTED: {
				break;
			}

			case State.CONNECTED: {
				break;
			}

			case State.READY: {
				break;
			}

		}
	}

}
