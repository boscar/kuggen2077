using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardFastEnemy : FastEnemy {

    public new const string PREFAB = "enemies/enemy-basic-hard";

    protected new void Awake() {
        base.Awake();
        AttackActions[ATTACK_PRIMARY] = new EnemyDefaultAttack(this, 20);
    }

    protected override void InitStats() {
        Strength = 2;
        HitPoints = 100;
        CurrentHitPoints = 100;
        MovementSpeed = new FloatStat(4);
        MovementFloatiness = 4;
    }

}
