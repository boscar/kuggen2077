using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultAttack : RangedAttackAction<Player> {

    public PlayerDefaultAttack (Player player) : base(player) {
        Damage = 10;
        Cooldown = 0.2f;
        ProjectileSpeed = 18;
        Spread = 3;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
		displayName = "Pistol";
    }

    protected override void Fire() {
        float rotY = Attacker.Transform.rotation.eulerAngles.y + ((UnityEngine.Random.value * (2 * Spread)) - Spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, Attacker.Transform.position, bulletRotation);
        bullet.AttackAction = this;
        bullet.Layers = new string[] { LayerConstants.ENEMY, LayerConstants.WALLS };
        bullet.Speed = ProjectileSpeed;
    }

}
