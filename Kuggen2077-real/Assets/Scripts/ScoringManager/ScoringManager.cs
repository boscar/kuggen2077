using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager {
	
	private Dictionary<string, int> scores = new Dictionary<string, int>();

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

	public void incrementScore(string playerId){
		scores [playerId] = scores [playerId] + 1;
	}

	public int getScore(string playerId){
		return scores [playerId];
	}

	public Dictionary<string, int> getAllScores(){		
		return scores;
	}
}
