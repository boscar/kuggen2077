﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAttackAction : PlayerRangedAttackAction {

    public SniperAttackAction(Player gameEntity) : base(gameEntity) {
        Damage = 80;
        Force = 5f;
        Cooldown = 1.1f;
        ProjectileSpeed = 40;
        Spread = 0.2f;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
		fireSound = Resources.Load<AudioClip>("Sounds/Weapon/Sniper");
		displayName = "Sniper Rifle";
        HitEffectCreators.Add(new SpawnParticlesHitEffectCreator(gameEntity, "particles/VfxHitSparks", 0.5f));
    }

    protected override void Fire() {
		AudioHandler.PlaySingle(fireSound);
        float rotY = Attacker.Transform.rotation.eulerAngles.y + ((UnityEngine.Random.value * (2 * Spread)) - Spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, Attacker.Transform.position, bulletRotation);
        bullet.AttackAction = this;
        bullet.transform.localScale = bullet.transform.localScale * 0.9f;
        bullet.Layers = new string[] { LayerConstants.ENEMY, LayerConstants.WALLS };
        bullet.Speed = ProjectileSpeed;
    }

}
