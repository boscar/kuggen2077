using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsaneRangeEnemy : RangeEnemy {

    public new const string PREFAB = "enemies/enemy-ranged-insane";

    protected new void Awake() {
        base.Awake();
        AttackActions[ATTACK_RANGE] = new EnemyRangeAttackAction(this, 15, 14);
    }

    protected override void InitStats() {
        Strength = 4;
        HitPoints = 100;
        CurrentHitPoints = 100;
        MovementSpeed = new FloatStat(3);
        MovementFloatiness = 3;
    }

}
