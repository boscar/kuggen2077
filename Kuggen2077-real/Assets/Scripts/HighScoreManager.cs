﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager {

	private static int numberOfPlayers = 0;
	private static Dictionary<int, int> scores = new Dictionary<int, int> ();

	public static int GetPlayerScore(int playerId){
		int score;
		if (!scores.TryGetValue (playerId, out score)) {
			throw new KuggenException ("Unable to get score for playerId: " + playerId + " in HighScoreManager");
		}

		return score;
	}

	public static void IncrementPlayerScore(int playerId, int score){
		if (!scores.ContainsKey (playerId)) {
			throw new KuggenException ("No player with " + playerId + " in HighScoreManager");
		}
		scores [playerId] += score;
	}

	public static int GetTotalScore(){
		int total = 0;
		foreach (KeyValuePair<int, int> entry in scores) {
			total += entry.Value;
		}

		return total;
	}

	public static void AddPlayer(int playerId){
		numberOfPlayers += 1;
		if (scores.ContainsKey (playerId)) {
			throw new KuggenException ("Player with ID " + playerId + " already added to HighScoreManager");
		}
		scores [playerId] = 0;
	}

	public void reset(){
		numberOfPlayers = 0;
		scores.Clear ();
	}
}

