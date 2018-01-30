using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsaneFastEnemy : FastEnemy {

    public new const string PREFAB = "enemies/enemy-basic-insane";

    protected new void Awake() {
        base.Awake();
        AttackActions[ATTACK_PRIMARY] = new EnemyDefaultAttack(this, 40);
    }

    protected override void InitStats() {
        Strength = 4;
        HitPoints = 150;
        CurrentHitPoints = 150;
        MovementSpeed = new FloatStat(5);
        MovementFloatiness = 5;
    }
}
