using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdateEffectCreator : RecieveAttackEffectCreator {
	public ScoreUpdateEffectCreator() : base(null) {}

	public override bool Activate(Attack attack) {
		Player player = attack.Attacker as Player;
		if (player != null) {
			ScoringManager.Instance.incrementScore (player.id);
			return true;
		}

		return false;
	}
}
