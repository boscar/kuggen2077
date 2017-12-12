﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultAttack : AttackAction {

    public PlayerDefaultAttack () {
        Damage = 10;

    }

    public override void Activate(IAttacker attacker) {
        Attack attack = new AttackBuilder()
            .Attacker(attacker)
            .AttackableLayers(new string[] { LayerConstants.ENEMY, LayerConstants.WALLS})
            .Damage(Damage).Build();
        //Create projectile
    }

}
