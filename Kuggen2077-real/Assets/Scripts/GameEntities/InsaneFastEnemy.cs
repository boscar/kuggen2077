using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsaneFastEnemy : FastEnemy {

    public new const string PREFAB = "enemies/enemy-basic-insane";

    protected new void Awake() {
        base.Awake();
        AttackActions[ATTACK_PRIMARY] = new EnemyDefaultAttack(this, 15);
    }

    protected override void InitStats() {
        Strength = 4;
        HitPoints = 100;
        CurrentHitPoints = 100;
        MovementSpeed = new FloatStat(4.5f);
        MovementFloatiness = 4.5f;
    }
}
