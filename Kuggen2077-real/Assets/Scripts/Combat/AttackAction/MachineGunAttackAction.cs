using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunAttackAction : PlayerRangedAttackAction {

    public MachineGunAttackAction(Player gameEntity) : base(gameEntity) {
		Damage = 10;
        Force = 0.3f;
        Cooldown = 0.095f;
        ProjectileSpeed = 30;
        Spread = 3.5f;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
		fireSound = Resources.Load<AudioClip>("Sounds/Weapon/Machinegun");
		displayName = "Machine Gun";
        HitEffectCreators.Add(new SpawnParticlesHitEffectCreator(gameEntity, "particles/VfxHitSparksSmall", 0.5f));
    }

    protected override void Fire() {
		AudioHandler.PlayPitched (0.95f, 1.05f, fireSound);
        float rotY = Attacker.Transform.rotation.eulerAngles.y + ((UnityEngine.Random.value * (2 * Spread)) - Spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, Attacker.Transform.position, bulletRotation);
        bullet.AttackAction = this;
        bullet.transform.localScale = bullet.transform.localScale * 0.9f;
        bullet.Layers = new string[] { LayerConstants.ENEMY, LayerConstants.WALLS };
        bullet.Speed = ProjectileSpeed;
    }

}
