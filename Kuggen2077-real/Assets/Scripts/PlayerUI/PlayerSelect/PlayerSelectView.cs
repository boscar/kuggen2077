using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectView : MonoBehaviour {
	// Use this for initialization
	void Start () {
		PlayerSelectState sm = new PlayerSelectState ();
		sm.moveNext (PlayerSelectState.Command.Connect);
		Debug.Log (sm.CurrentState);
	}
}
