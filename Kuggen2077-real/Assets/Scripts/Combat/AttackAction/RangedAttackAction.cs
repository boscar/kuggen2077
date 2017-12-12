using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedAttackAction : AttackAction {
    public float Spread { get; set; }
    public float ProjectileSpeed { get; set; }
}
