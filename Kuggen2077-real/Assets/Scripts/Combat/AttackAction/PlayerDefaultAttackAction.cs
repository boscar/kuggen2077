using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultAttack : PlayerRangedAttackAction {

    public PlayerDefaultAttack (Player player) : base(player) {
        Damage = 10;
        Force = 1f;
        Cooldown = 0.2f;
        ProjectileSpeed = 18;
        Spread = 3;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
		fireSound = Resources.Load<AudioClip>("Sounds/Weapon/Pistol");
		displayName = "Pistol";
        HitEffectCreators.Add(new SpawnParticlesHitEffectCreator(player, "particles/VfxHitSparksSmall", 0.5f));
    }

    protected override void Fire() {
		AudioHandler.PlayPitched (0.95f, 1.05f, fireSound);
        float rotY = Attacker.Transform.rotation.eulerAngles.y + ((UnityEngine.Random.value * (2 * Spread)) - Spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, Attacker.Transform.position, bulletRotation);
        bullet.AttackAction = this;
        bullet.Layers = new string[] { LayerConstants.ENEMY, LayerConstants.WALLS };
        bullet.Speed = ProjectileSpeed;
    }

}
