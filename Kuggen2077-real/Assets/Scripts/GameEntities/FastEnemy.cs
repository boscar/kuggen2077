using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy {

    public const string ATTACK_PRIMARY = "attack_primary";

    public new const string PREFAB = "enemies/enemy-basic";

    protected new void Awake() {
        base.Awake();
        SpawnYValue = 1.1f;
        AttackActions.Add(ATTACK_PRIMARY, new EnemyDefaultAttack(this, 10));
    }

	protected override void InitEffects() {
        base.InitEffects();
        RecieveAttackHandler.RecieveAttackCreators.Add(new TemporaryColorChangeEffectCreator(this, Color.white));
		RecieveAttackHandler.DeathCreators.Add(new ScoreUpdateEffectCreator(1));
        RecieveAttackHandler.RecieveAttackCreators.Add(new KnockbackEffectCreator(this, this));
    }

    protected override void InitStats() {
        HitPoints = 50;
        CurrentHitPoints = 50;
        MovementSpeed = new FloatStat(3);
        MovementFloatiness = 3;
    }

}
