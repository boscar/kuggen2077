using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardFastEnemy : FastEnemy {

    public new const string PREFAB = "enemies/enemy-basic-hard";

    protected new void Awake() {
        base.Awake();
        AttackActions[ATTACK_PRIMARY] = new EnemyDefaultAttack(this, 13);
    }

    protected override void InitStats() {
        Strength = 2;
        HitPoints = 75;
        CurrentHitPoints = 75;
        MovementSpeed = new FloatStat(3.75f);
        MovementFloatiness = 3.75f;
    }

}
