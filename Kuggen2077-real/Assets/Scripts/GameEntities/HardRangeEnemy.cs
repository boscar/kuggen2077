using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardRangeEnemy : RangeEnemy {

    public new const string PREFAB = "enemies/enemy-ranged-hard";

    protected new void Awake() {
        base.Awake();
        AttackActions[ATTACK_RANGE] = new EnemyRangeAttackAction(this, 15, 12);
    }

    protected override void InitStats() {
        Strength = 2;
        HitPoints = 75;
        CurrentHitPoints = 75;
        MovementSpeed = new FloatStat(2.5f);
        MovementFloatiness = 2.5f;
    }

}
