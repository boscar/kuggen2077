using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler { 

	private IAudible Audible { get; set; }

	public AudioHandler(IAudible audible){
		Audible = audible;
	}

	public void PlaySingle(params AudioClip[] clips){
		ResetPitch ();
		int randomIndex = Random.Range (0, clips.Length);
		Audible.AudioSource.PlayOneShot (clips [randomIndex]);
	}

	public void PlayPitched(float lowerBound, float upperBound, params AudioClip[] clips){
		float pitch = Random.Range (lowerBound, upperBound);
		int randomIndex = Random.Range (0, clips.Length);
		Audible.AudioSource.pitch = pitch;
		Audible.AudioSource.PlayOneShot (clips[randomIndex]);
	}

	private void ResetPitch(){
		Audible.AudioSource.pitch = 1;
	}
}
