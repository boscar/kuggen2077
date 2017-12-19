using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager {
	
	private Dictionary<string, int> scores = new Dictionary<string, int>();
	private List<IScoreObserver> observers = new List<IScoreObserver>();

	private static ScoringManager instance;
	private ScoringManager() {}

	public static ScoringManager Instance {
		get {
			if (instance == null) {
				instance = new ScoringManager();
			}
			return instance;
		}
	}

	public void incrementScore(string playerId) {
		if (!scores.ContainsKey (playerId)) {
			scores [playerId] = 0;
		}
		scores [playerId] = scores [playerId] + 1;
		foreach (IScoreObserver obs in observers) {
			obs.onScoreChange (playerId, scores [playerId]);
		}
	}

	public int getScore(string playerId) {
		return scores [playerId];
	}

	public Dictionary<string, int> getAllScores() {		
		return scores;
	}

	public void addObserver (IScoreObserver obs) {
		observers.Add (obs);
	}

	public void removeObserver (IScoreObserver obs) {
		observers.Remove (obs);
	}
}
