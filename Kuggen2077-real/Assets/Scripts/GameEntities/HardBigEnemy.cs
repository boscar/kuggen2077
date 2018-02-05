using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBigEnemy : BigEnemy {

    public new const string PREFAB = "enemies/enemy-big-hard";

    protected new void Awake() {
        base.Awake();
        AttackActions[ATTACK_PRIMARY] = new EnemyDefaultAttack(this, 21);
    }

    protected override void InitStats() {
        Strength = 6;
        HitPoints = 275;
        CurrentHitPoints = 275;
        MovementSpeed = new FloatStat(1.4f);
        MovementFloatiness = 1.4f;
    }

}
