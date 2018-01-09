using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectView : MonoBehaviour {

	private Dictionary<PlayerSelectState.ViewState, Action> views = new Dictionary<PlayerSelectState.ViewState, Action> ();

	// Use this for initialization
	void Start () {
		views.Add (PlayerSelectState.ViewState.Connected, () => setConnected ());
		views.Add (PlayerSelectState.ViewState.Disconnected, () => setDisconnected());
		views.Add (PlayerSelectState.ViewState.Ready, () => setReady());
	}

	public void updateView(PlayerSelectState.ViewState state){
		if (views.ContainsKey (state)) {
			views [state].Invoke ();
		}
	}

	private void setDisconnected(){
		Debug.Log ("Disconnected");
	}

	private void setConnected(){
		Debug.Log ("Connected");
	}

	private void setReady(){
		Debug.Log ("Ready");
	}

}
