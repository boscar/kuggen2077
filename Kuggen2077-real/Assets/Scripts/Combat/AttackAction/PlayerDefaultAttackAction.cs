using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultAttack : AttackAction {

    private Bullet bulletObject;

    public PlayerDefaultAttack () {
        Damage = 10;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
    }

    public override void Activate(IAttacker attacker) {
        Attack attack = new AttackBuilder()
            .Attacker(attacker)
            .AttackableLayers(new string[] { LayerConstants.ENEMY, LayerConstants.WALLS})
            .Damage(Damage).Build();
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, attacker.Transform.position, attacker.Transform.rotation);
        bullet.Attack = attack;
        bullet.Speed = 10;
    }

}
