using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager {

	// Keep everything static in order to preserver HighScore state on Load (scene changes)
	public static int NumberOfPlayers { get; private set; }
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

	public static int GetChampion(){
		int max = -1;
		int id = -1;
		foreach (KeyValuePair<int, int> entry in scores) {
			if (max < 0 || entry.Value > max) {
				max = entry.Value;
				id = entry.Key;
			}
		}

		return id;
	}

	public static void AddPlayer(int playerId){
		if (scores.ContainsKey (playerId)) {
			throw new KuggenException ("Player with ID " + playerId + " already added to HighScoreManager");
		}

		NumberOfPlayers += 1;
		scores [playerId] = 0;
	}
		

	public static void Reset(){
		NumberOfPlayers = 0;
		scores.Clear ();
	}
}

