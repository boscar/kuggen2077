using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy {

    public const string ATTACK_PRIMARY = "attack_primary";

    public new const string PREFAB = "enemies/enemy-basic";

    protected new void Awake() {
        base.Awake();
        AttackActions.Add(ATTACK_PRIMARY, new EnemyDefaultAttack(this));
    }

    protected override void InitStats() {
        HitPoints = 50;
        CurrentHitPoints = 50;
        MovementSpeed = new FloatStat(3);
        MovementFloatiness = 3;
    }

}
