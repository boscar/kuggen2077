using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdateEffectCreator : RecieveAttackEffectCreator {
	private int scoreValue;

	public ScoreUpdateEffectCreator(int val) : base(null) {
		scoreValue = val;
	}

	public ScoreUpdateEffectCreator() : base(null) {
		scoreValue = 1;
	}

	public override bool Activate(Attack attack) {
		Player player = attack.Attacker as Player;
		if (player != null) {
			player.Score += scoreValue;
			return true;
		}

		return false;
	}
}
