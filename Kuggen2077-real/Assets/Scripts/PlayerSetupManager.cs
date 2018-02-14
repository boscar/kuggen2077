using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetupManager : MonoBehaviour {

	public GameObject playerOne;
	public GameObject playerTwo;

	// Use this for initialization
	void Start () {
		switch (HighScoreManager.Players) {
		case HighScoreManager.PlayerState.PLAYER_ALL:
			playerOne.SetActive (true);
			playerTwo.SetActive (true);
			break;

		case HighScoreManager.PlayerState.PLAYER_ONE:
			playerOne.SetActive (true);
			break;

		case HighScoreManager.PlayerState.PLAYER_TWO:
			playerTwo.SetActive (true);
			break;

		default:
			break;
		}
	}
}
