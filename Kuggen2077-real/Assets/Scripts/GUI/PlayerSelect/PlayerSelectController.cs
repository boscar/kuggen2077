using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectController : MonoBehaviour {

	public AudioClip backClip;
	public AudioClip startGameClip;

	private Dictionary<int, ControlKeyBindings> keybindings = new Dictionary<int, ControlKeyBindings> () {
		{ 1, new GamepadOneControlKeyBindings () },
		{ 2, new GamepadTwoControlKeyBindings () },
	};

	public RawImage startGamePrompt;
	public PlayerSelectView[] views;

	private bool canProceedToGame;


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
				GlobalSoundManager.Instance.PlaySingle (startGameClip);
				MusicManager.Instance.PlayLevel (0, false);
				SceneManager.LoadScene ("level-0");
			}
		} else {
			if (ClickedBack ()) {
				GlobalSoundManager.Instance.PlaySingle (backClip);
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