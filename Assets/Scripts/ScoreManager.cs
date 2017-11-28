using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public GameObject scoreObject;


	private Text scoreText;
	private static int score = 0;

	void Start(){
		scoreText = scoreObject.GetComponent<Text> ();
		Debug.Log (scoreText);

	}

	void Update(){
		scoreText.text = score.ToString() + " points";
	}

	public static void addPoint(){
		score += 1;
	}
}
