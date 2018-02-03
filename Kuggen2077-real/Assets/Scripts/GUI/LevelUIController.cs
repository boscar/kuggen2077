using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour, IObserver<LevelEndlessRandomize> {

	public LevelEndlessRandomize level;
	public Text	sectionText;

	void Awake () {
		level.AddObserver (this);
	}

	public void OnUpdate(LevelEndlessRandomize level) {
		sectionText.text = Utils.LeftPad ((level.CurrentSection.Index + 1).ToString (), 3, "0");
	}
		
}
