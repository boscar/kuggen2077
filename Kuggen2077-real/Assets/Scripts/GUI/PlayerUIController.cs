using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour {

	public PlayerUIView[] views;

	void Start () {
		if (views.Length < 2) {
			throw new KuggenException ("atleast two PlayerUIView are required in " + this);
		}
			
		if (HighScoreManager.NumberOfPlayers == 1) {
			showSinglePlayer ();
		}
	}

	void showSinglePlayer(){
		Debug.Log ("Show SinglePlayer");
		Debug.Log (views [0].transform.position);
		//views[0].transform.position = new Vector3 (0, 60, 0);

		views [1].gameObject.SetActive (false);
	}
}
