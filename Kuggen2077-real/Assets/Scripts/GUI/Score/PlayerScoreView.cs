using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreView : MonoBehaviour {

	public int PLAYER_ID;
	public Text score;
	public GameObject champion;
	
	public void SetScore(int val){
		score.text = val.ToString();
	}

	public void SetChampion(bool enabled){
		champion.SetActive (enabled);
	}

	public void SetActive(bool val){
		gameObject.SetActive (val);
	}
}
