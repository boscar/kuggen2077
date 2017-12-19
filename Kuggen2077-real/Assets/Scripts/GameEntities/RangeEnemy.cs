using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy {

    public const string ATTACK_PRIMARY = "attack_range";

    protected new void Awake()
    {
        base.InitStats();
        base.InitHandlers();
        AttackActions.Add(ATTACK_PRIMARY, new EnemyRangeAttackAction(this));
    }

    protected new void FixedUpdate()
    {   
        base.FixedUpdate();
    }
}
