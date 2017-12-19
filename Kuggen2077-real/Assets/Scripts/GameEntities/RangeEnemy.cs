using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy {



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
