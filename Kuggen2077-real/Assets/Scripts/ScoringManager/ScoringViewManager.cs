using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringViewManager : MonoBehaviour {

	private ScoringManager manager;
	private ScoreView[] scoreViews;

	// Use this for initialization
	void Start () {
		manager = ScoringManager.Instance;
		scoreViews = GetComponentsInChildren<ScoreView>();
	}
	
	// Update is called once per frame
	void Update () {
		Dictionary<string, int> scores = manager.getAllScores ();
		foreach (ScoreView view in scoreViews) {
			if (scores.ContainsKey(view.id)) {
				view.setScore (scores [view.id]);
			}
		}
	}

}
