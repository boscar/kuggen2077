using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAttackAction : PlayerRangedAttackAction {

    private const float FIRE_MAX_DELAY = 0.06f;

    private float BulletLifetime { get; set; }
    private int BulletAmount { get; set; }

    public ShotgunAttackAction(Player gameEntity) : base(gameEntity) {
        Damage = 5;
        Force = 1f;
        Cooldown = 1f;
        ProjectileSpeed = 36;
        Spread = 16;
        BulletLifetime = 0.25f;
        BulletAmount = 26;
        bulletObject = Resources.Load<Bullet>("shotgunround");
		fireSound = Resources.Load<AudioClip>("Sounds/Weapon/Shotgun");
        displayName = "Shotgun";
        HitEffectCreators.Add(new SpawnParticlesHitEffectCreator(gameEntity, "particles/VfxHitSparksSmall", 0.5f));
    }

    protected override void Fire() {
		AudioHandler.PlaySingle(fireSound);
        for (int i = 0; i < BulletAmount; ++i) {
            ((GameEntity)Attacker).StartCoroutine(CreateBulletDelayed(UnityEngine.Random.value * FIRE_MAX_DELAY));
        }
    }

    protected IEnumerator CreateBulletDelayed(float delay) {
        yield return new WaitForSeconds(delay);
        CreateBullet();
    }

    private void CreateBullet() {
        float rotY = Attacker.Transform.rotation.eulerAngles.y + ((UnityEngine.Random.value * Spread) - (0.5f * Spread)) + ((UnityEngine.Random.value * Spread) - (0.5f * Spread));
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, Attacker.Transform.position, bulletRotation);
        bullet.AttackAction = this;
        bullet.transform.localScale = bullet.transform.localScale * 0.7f;
        bullet.Layers = new string[] { LayerConstants.ENEMY, LayerConstants.WALLS };
        bullet.Speed = ProjectileSpeed;
        GameObject.Destroy(bullet.gameObject, (UnityEngine.Random.value * (0.2f * BulletLifetime)) + (0.8f * BulletLifetime));
    }

}
