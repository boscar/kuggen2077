using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundManager : MonoBehaviour {

	public AudioSource efxSource;
	public AudioSource musicSource;
	public static GlobalSoundManager Instance;

	// singleton pattern
	void Awake () {
		if (Instance == null){
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingle(AudioClip clip){
		efxSource.PlayOneShot (clip);
	}

	public void RandomizeSingle(params AudioClip[] clips){
		int randomIndex = Random.Range (0, clips.Length);
		efxSource.PlayOneShot (clips [randomIndex]);

	}
}
