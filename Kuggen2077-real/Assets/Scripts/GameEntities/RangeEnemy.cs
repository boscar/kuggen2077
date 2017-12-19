using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy {

    public const string ATTACK_RANGE = "attack_range";

    protected new void Awake()
    {
        base.Awake();
        AttackActions.Add(ATTACK_RANGE, new EnemyRangeAttackAction(this));
    }
}
