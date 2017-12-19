using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttackAction : RangedAttackAction<RangeEnemy>
{

    public EnemyRangeAttackAction(RangeEnemy enemy) : base(enemy) {
        Damage = 1;
        Cooldown = 5f;
        ProjectileSpeed = 18;
        Spread = 3;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
    }

    protected override void CreateBullet() {
        float rotY = Attacker.Transform.rotation.eulerAngles.y + ((UnityEngine.Random.value * (2 * Spread)) - Spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, Attacker.Transform.position, bulletRotation);
        bullet.AttackAction = this;
        bullet.Layers = new string[] { LayerConstants.PLAYER, LayerConstants.WALLS };
        bullet.Speed = ProjectileSpeed;
    }

}


	

