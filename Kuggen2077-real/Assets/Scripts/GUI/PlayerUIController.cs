using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour {

	public PlayerUIView playerOne;
	public PlayerUIView playerTwo;

	void Awake () {
		switch (HighScoreManager.Players) {
		case HighScoreManager.PlayerState.PLAYER_ONE:
			ShowPlayerOne ();
			break;

		case HighScoreManager.PlayerState.PLAYER_TWO:
			ShowPlayerTwo ();
			break;

		case HighScoreManager.PlayerState.PLAYER_ALL:
			ShowPlayerAll ();
			break;

		default:
			break;
		}
	}

	void ShowPlayerOne(){
		RectTransform transform = playerOne.GetComponent<RectTransform> ();
		transform.localPosition = new Vector3 (0, transform.localPosition.y, transform.localPosition.z);
		playerTwo.gameObject.SetActive (false);
	}

	void ShowPlayerTwo(){
		RectTransform transform = playerTwo.GetComponent<RectTransform> ();
		transform.localPosition = new Vector3 (0, transform.localPosition.y, transform.localPosition.z);
		playerOne.gameObject.SetActive (false);
	}

	void ShowPlayerAll(){
		
	}
}
