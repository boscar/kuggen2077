using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectController : MonoBehaviour {

	private Component[] views;
	public RawImage startGamePrompt;

	// Use this for initialization
	void Start () {
		views = GetComponentsInChildren<PlayerSelectView> ();
	}
	
	// Update is called once per frame
	void Update () {
		bool hasReady = false;
		foreach (PlayerSelectView v in views) {
			if (v.sm.CurrentState == PlayerSelectState.ViewState.Ready) {
				hasReady = true;
			}
		}

		startGamePrompt.enabled = hasReady;
	}
}
