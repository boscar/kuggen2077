using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunAttackAction : RangedAttackAction<Player> {

    public MachineGunAttackAction(Player gameEntity) : base(gameEntity) {
        Damage = 4;
        Force = 0.3f;
        Cooldown = 0.04f;
        ProjectileSpeed = 30;
        Spread = 3.5f;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
    }

    protected override void Fire() {
        float rotY = Attacker.Transform.rotation.eulerAngles.y + ((UnityEngine.Random.value * (2 * Spread)) - Spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, Attacker.Transform.position, bulletRotation);
        bullet.AttackAction = this;
        bullet.transform.localScale = bullet.transform.localScale * 0.9f;
        bullet.Layers = new string[] { LayerConstants.ENEMY, LayerConstants.WALLS };
        bullet.Speed = ProjectileSpeed;
    }

}
