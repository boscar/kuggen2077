using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedAttackAction : AttackAction {
    public RangedAttackAction(IAttacker attacker) : base(attacker) { }

    public float Spread { get; set; }
    public float ProjectileSpeed { get; set; }
}
