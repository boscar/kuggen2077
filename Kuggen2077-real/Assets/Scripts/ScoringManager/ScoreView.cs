using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour {
	public string id;
	private Text label;

	void Start () {
		label = GetComponent<Text> ();
	}

	public void setScore(int score){
		label.text = score.ToString();
	}
}
