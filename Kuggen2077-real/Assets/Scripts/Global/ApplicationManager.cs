﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {
	
	public static ApplicationManager Instance { get; private set; }
	public ApplicationState State = new ApplicationState (ApplicationState.SceneState.Main);

	public AudioClip backSound;
	public AudioClip startGameSound;

	// singleton pattern
	void Awake () {
		if (Instance == null){
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
		InitSubscribers ();
	}

	void InitSubscribers(){
		// Main -> Quit
		State.Subscribe (ApplicationState.SceneState.Main, ApplicationState.Command.Quit, () => {
			QuitGame();
		});

		// Main -> Play
		State.Subscribe (ApplicationState.SceneState.Main, ApplicationState.Command.Play, () => {
			SceneManager.LoadScene("play-menu");
		});

		// Main <- Play
		State.Subscribe (ApplicationState.SceneState.Play, ApplicationState.Command.Main, () => {
			GlobalSoundManager.Instance.PlaySingle(backSound);
			SceneManager.LoadScene("main-menu");
		});

		// Play -> Level
		State.Subscribe (ApplicationState.SceneState.Play, ApplicationState.Command.Level, () => {
			GlobalSoundManager.Instance.PlaySingle(startGameSound);
			HighScoreManager.Reset();
			MusicManager.Instance.PlayLevel(0, true);
			SceneManager.LoadScene("main-scene");
		});

		// Level -> Results
		State.Subscribe (ApplicationState.SceneState.Level, ApplicationState.Command.Result, () => {
			SceneManager.LoadScene("result-menu");
		});

		// Level <- Results
		State.Subscribe (ApplicationState.SceneState.Result, ApplicationState.Command.Level, () => {
			HighScoreManager.Reset();
			MusicManager.Instance.PlayLevel(0, true);
			SceneManager.LoadScene("main-scene");
		});

		// Results -> Main
		State.Subscribe (ApplicationState.SceneState.Result, ApplicationState.Command.Main, () => {
			MusicManager.Instance.PlayMenu(true);
			SceneManager.LoadScene("main-menu");
		});
	}

	public void ChangeScene(ApplicationState.Command command){
		State.MoveNext (command);
	}
		
	public void QuitGame(){
		Debug.Log ("!!!!quit!!!!!");
		Application.Quit ();
	}
}
