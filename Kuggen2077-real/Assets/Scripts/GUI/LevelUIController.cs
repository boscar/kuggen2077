using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour, IObserver<Level> {

	public LevelEndlessRandomize level;
	public Text	waveText;

	void Awake () {
		level.AddObserver (this);
	}

	public void OnUpdate(Level level) {
		Debug.Log ("level: " + level);
	}
		
}
