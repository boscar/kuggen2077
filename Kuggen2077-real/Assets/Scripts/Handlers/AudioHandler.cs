using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler { 

	private IAudible Audible { get; set; }

	public AudioHandler(IAudible audible){
		Audible = audible;
	}

	public void PlaySingle(AudioClip clip){
		ResetPitch ();
		Audible.AudioSource.PlayOneShot (clip);
	}

	public void PlayRandomized(params AudioClip[] clips){
		ResetPitch ();
		int randomIndex = Random.Range (0, clips.Length);
		Audible.AudioSource.PlayOneShot (clips [randomIndex]);
	}

	public void PlayPitched(AudioClip clip, float lowerBound, float upperBound){
		float pitch = UnityEngine.Random.Range (lowerBound, upperBound);
		Audible.AudioSource.pitch = pitch;
		Audible.AudioSource.PlayOneShot (clip);
	}

	private void ResetPitch(){
		Audible.AudioSource.pitch = 1;
	}
}
