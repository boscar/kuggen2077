using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreController : MonoBehaviour {

	public PlayerScoreView[] scoreViews;
	public GameObject totalView;
	public GameObject totalText;

	// Use this for initialization
	void Start () {
		InitViews ();
	}

	private void InitViews() {
		if (HighScoreManager.NumberOfPlayers < 2) {
			RenderSinglePlayer ();
		} else {
			RenderMultiPlayer ();
		}

		totalText.GetComponent<Text> ().text = HighScoreManager.GetTotalScore ().ToString();
	}

	private void RenderSinglePlayer(){
		foreach (PlayerScoreView v in scoreViews) {
			v.SetActive(false);
		}

		totalView.transform.position = new Vector3 (totalView.transform.position.x, 0, totalView.transform.position.z);
	}

	private void RenderMultiPlayer(){
		int championId = HighScoreManager.GetChampion ();
		foreach (PlayerScoreView v in scoreViews) {
			if (v.PLAYER_ID == championId) {
				v.SetChampion (true);
			}

			v.SetScore (HighScoreManager.GetPlayerScore (v.PLAYER_ID));
		}
	}
}
