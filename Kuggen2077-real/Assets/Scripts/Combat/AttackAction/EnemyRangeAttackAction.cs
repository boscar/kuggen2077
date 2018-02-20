using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttackAction : RangedAttackAction<RangeEnemy>
{

    public EnemyRangeAttackAction(RangeEnemy enemy, int damage, float projectileSpeed) : base(enemy) {
        Damage = damage;
        Cooldown = 5f;
        ProjectileSpeed = projectileSpeed;
        Spread = 3;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
        InitCooldown(1.5f);
        HitEffectCreators.Add(new SpawnParticlesHitEffectCreator(enemy, "particles/VfxHitSparks", 0.5f));
    }

    protected override void Fire() {
        float rotY = Attacker.Transform.rotation.eulerAngles.y + ((UnityEngine.Random.value * (2 * Spread)) - Spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, Attacker.Transform.position, bulletRotation);
        bullet.AttackAction = this;
        bullet.Layers = new string[] { LayerConstants.PLAYER, LayerConstants.WALLS };
        bullet.Speed = ProjectileSpeed;
    }

}


	

