using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectCreator : EffectCreator {

	protected IAudible Audible { get; set; }
	protected AudioClip[] Clips { get; set; }

	public SoundEffectCreator(IAudible audible, params AudioClip[] clips) : base(null){
		Audible = audible;
		Clips = clips;
	}

	public override bool Activate (){
		Audible.AudioHandler.PlaySingle (Clips);
		return true;
	}
}
