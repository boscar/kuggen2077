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

	public void PlayMenu(bool fade){
		if (fade) {
			Instance.StartCoroutine (Fade (menuMusic, 0.15f));
		} else {
			musicSource.clip = menuMusic;
			musicSource.Play ();
		}
	}

	public void PlayLevel(int levelId, bool fade){
		if (levelId < 0 || levelId > levelMusic.Length - 1) {
			throw new KuggenException ("Level Id must be between 0 and " + levelMusic.Length + " in " + this);
		}
			
		AudioClip clip = levelMusic [levelId];
		if (fade) {
			Instance.StartCoroutine (Fade (clip, 0.75f));
		} else {
			musicSource.clip = clip;
			musicSource.Play ();
		}
	}
		

	IEnumerator Fade(AudioClip clip, float speed){
		yield return FadeOut (speed);
		musicSource.clip = clip;
		musicSource.Play ();
		yield return FadeIn (speed);
	}

	IEnumerator FadeIn(float speed){
		float volume = musicSource.volume;
		while (volume < 1) {
			volume += speed;
			musicSource.volume = volume;
			yield return new WaitForSeconds (0.1f);
		}
	}

	IEnumerator FadeOut(float speed){
		float volume = musicSource.volume;
		while (volume > 0) {
			volume -= speed;
			musicSource.volume = volume;
			yield return new WaitForSeconds (0.1f);
		}
	}
}
