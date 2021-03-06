﻿using System;
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
		return Input.GetButtonDown (keybindings [1].Start) || Input.GetButtonUp (keybindings [2].Start);
	}

	private bool ClickedBack(){
		return Input.GetButtonDown (keybindings[1].Discard) || Input.GetButtonUp (keybindings[2].Discard);
	}

	// Update is called once per frame
	void Update () {
		if (canProceedToGame) {
			if (ClickedStart ()) {
				PersistPlayers ();
				ApplicationManager.Instance.ChangeScene (ApplicationState.Command.Level);
			}
		} else {
			if (ClickedBack ()) {
				ApplicationManager.Instance.ChangeScene (ApplicationState.Command.Main);
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

	void PersistPlayers(){
		HighScoreManager.Players = HighScoreManager.PlayerState.PLAYER_ALL;

		bool playerOneReady = views [0].sm.CurrentState == PlayerSelectState.ViewState.Ready;
		bool playerTwoReady = views [1].sm.CurrentState == PlayerSelectState.ViewState.Ready;

		if (playerOneReady && !playerTwoReady) {
			HighScoreManager.Players = HighScoreManager.PlayerState.PLAYER_ONE;
		} else if (!playerOneReady && playerTwoReady) {
			HighScoreManager.Players = HighScoreManager.PlayerState.PLAYER_TWO;
		}
	}
}