using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchedSoundEffectCreator : SoundEffectCreator {

	private float Low;
	private float High;

	public PitchedSoundEffectCreator(IAudible audible, float high, float low, params AudioClip[] clips) : base(audible, clips) {
		Low = low;
		High = high;
	}

	public override bool Activate (){
		Audible.AudioHandler.PlayPitched (Low, High, Clips);
		return true;
	}
}
