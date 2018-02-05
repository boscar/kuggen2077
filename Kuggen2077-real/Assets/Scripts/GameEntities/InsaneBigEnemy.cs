using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsaneBigEnemy : BigEnemy {

    public new const string PREFAB = "enemies/enemy-big-insane";

    protected new void Awake() {
        base.Awake();
        AttackActions[ATTACK_PRIMARY] = new EnemyDefaultAttack(this, 25);
    }

    protected override void InitStats() {
        Strength = 9;
        HitPoints = 400;
        CurrentHitPoints = 400;
        MovementSpeed = new FloatStat(1.8f);
        MovementFloatiness = 1.8f;
    }

}
