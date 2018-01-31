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
        AttackActions.Add(ATTACK_RANGE, new EnemyRangeAttackAction(this, 10, 10));
        SpawnYValue = 0.5f;
    }

	protected override void InitEffects() {
        base.InitEffects();
        GameObject bodyGameObjet = Utils.FindChildWithTag(gameObject, "body");
        Renderer renderer = bodyGameObjet.transform.GetComponent<Renderer>();
        if (renderer == null) {
            throw new KuggenException(this + " requires a renderer.");
        }
        RecieveAttackHandler.RecieveAttackCreators.Add(new TemporaryColorChangeEffectCreator(this, renderer, Color.white));
		RecieveAttackHandler.DeathCreators.Add(new ScoreUpdateEffectCreator(2));
        RecieveAttackHandler.RecieveAttackCreators.Add(new KnockbackEffectCreator(this, this));
    }

    protected override void InitStats() {
        HitPoints = 50;
        CurrentHitPoints = 50;
        MovementSpeed = new FloatStat(2);
        MovementFloatiness = 2;
    }
}
