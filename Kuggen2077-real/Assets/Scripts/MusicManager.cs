using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip menuMusic;
	public AudioClip[] levelMusic;
	public AudioSource musicSource;
	public static MusicManager Instance;

	// singleton pattern
	void Awake () {
		if (Instance == null){
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public void PlayMenu(){
		musicSource.clip = menuMusic;
		musicSource.Play ();
	}

	public void PlayLevel(int levelId){
		if (levelId < 0 || levelId > levelMusic.Length - 1) {
			throw new KuggenException ("Level Id must be between 0 and " + levelMusic.Length + " in " + this);
		}

		AudioClip clip = levelMusic [levelId];
		musicSource.clip = clip;
		musicSource.Play ();
	}
}
