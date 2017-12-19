using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringViewManager : MonoBehaviour, IScoreObserver {

	private List<ScoreView> scoreViews;

	// Use this for initialization
	void Start () {
		scoreViews = new List<ScoreView> (GetComponentsInChildren<ScoreView> ());
		ScoringManager.Instance.addObserver (this);

	}

	public void onScoreChange (string playerId, int score) {
		ScoreView result = scoreViews.Find (s => s.id == playerId);
		if (result != null) {
			result.setScore (score);
		}
	}

}
