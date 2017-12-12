using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultAttack : AttackAction {

    private Bullet bullet;

    public PlayerDefaultAttack () {
        Damage = 10;
        bullet = Resources.Load<Bullet>("simple_bullet");
    }

    public override void Activate(IAttacker attacker) {
        Attack attack = new AttackBuilder()
            .Attacker(attacker)
            .AttackableLayers(new string[] { LayerConstants.ENEMY, LayerConstants.WALLS})
            .Damage(Damage).Build();
        GameObject.Instantiate<Bullet>(bullet, attacker.Transform.position, attacker.Transform.rotation);
    }

}
