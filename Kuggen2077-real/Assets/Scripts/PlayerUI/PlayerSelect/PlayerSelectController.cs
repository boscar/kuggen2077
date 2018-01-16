using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectController : MonoBehaviour {

	private Component[] views;
	private Dictionary<int, ControlKeyBindings> keybindings = new Dictionary<int, ControlKeyBindings> () {
		{ 1, new GamepadOneControlKeyBindings () },
		{ 2, new GamepadTwoControlKeyBindings () },
	};

	public RawImage startGamePrompt;
	public ApplicationManager applicationManager;

	private bool canProceedToGame;

	// Use this for initialization
	void Start () {
		views = GetComponentsInChildren<PlayerSelectView> ();

	}

	private bool ClickedStart(){
		return Input.GetButtonUp (keybindings [1].Start) || Input.GetButtonUp (keybindings [2].Start);
	}

	private bool ClickedBack(){
		return Input.GetButtonUp (keybindings[1].Discard) || Input.GetButtonUp (keybindings[2].Discard);
	}

	// Update is called once per frame
	void Update () {
		if (canProceedToGame) {
			if (ClickedStart ()) {
				SceneManager.LoadScene ("felix-test");
			}
		} else {
			if (ClickedBack ()) {
				SceneManager.LoadScene ("main-menu");
			}
		}

		canProceedToGame = false;
		foreach (PlayerSelectView v in views) {
			if (v.sm.CurrentState == PlayerSelectState.ViewState.Ready) {
				canProceedToGame = true;
			}
		}

		startGamePrompt.enabled = canProceedToGame;
	}
}