using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAttackAction : RangedAttackAction<Player> {

    private const float FIRE_MAX_DELAY = 0.05f;

    private float BulletLifetime { get; set; }
    private int BulletAmount { get; set; }

    public ShotgunAttackAction(Player gameEntity) : base(gameEntity) {
        Damage = 10;
        Cooldown = 1f;
        ProjectileSpeed = 36;
        Spread = 22;
        BulletLifetime = 0.25f;
        BulletAmount = 12;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
    }

    protected override void Fire() {
        for (int i = 0; i < BulletAmount; ++i) {
            GameEntity.StartCoroutine(CreateBulletDelayed(UnityEngine.Random.value * FIRE_MAX_DELAY));
        }
    }

    protected IEnumerator CreateBulletDelayed(float delay) {
        yield return new WaitForSeconds(delay);
        CreateBullet();
    }

    private void CreateBullet() {
        float rotY = Attacker.Transform.rotation.eulerAngles.y + ((UnityEngine.Random.value * (2 * Spread)) - Spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, Attacker.Transform.position, bulletRotation);
        bullet.AttackAction = this;
        bullet.transform.localScale = bullet.transform.localScale * 0.7f;
        bullet.Layers = new string[] { LayerConstants.ENEMY, LayerConstants.WALLS };
        bullet.Speed = ProjectileSpeed;
        GameObject.Destroy(bullet.gameObject, BulletLifetime);
    }

}
