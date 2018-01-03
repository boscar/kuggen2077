using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy {

    public const string ATTACK_RANGE = "attack_range";

    public new const string PREFAB = "enemies/enemy-ranged";

    protected new void Awake()
    {
        base.Awake();
        AttackActions.Add(ATTACK_RANGE, new EnemyRangeAttackAction(this));
    }

	protected override void InitEffects() {
		RecieveAttackHandler.RecieveAttackCreators.Add(new TemporaryColorChangeEffectCreator(this, Color.white));
		RecieveAttackHandler.DeathCreators.Add(new ScoreUpdateEffectCreator(2));
	}

    protected override void InitStats() {
        HitPoints = 50;
        CurrentHitPoints = 50;
        MovementSpeed = 2;
        MovementFloatiness = 2;
    }
}
