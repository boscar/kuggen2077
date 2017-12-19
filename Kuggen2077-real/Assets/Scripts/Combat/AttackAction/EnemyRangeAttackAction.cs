using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttackAction : RangedAttackAction
{

    private Bullet bulletObject;
    private GameEntity gameEntity;
    private bool hasCooldown = false;

    public EnemyRangeAttackAction(Enemy enemy) : base(enemy)
    {
        this.gameEntity = enemy;
        Damage = 1;
        Cooldown = 0.2f;
        ProjectileSpeed = 18;
        Spread = 3;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
    }



    public override void InitAttack()
    {
        if (hasCooldown)
        {
            return;
        }
        CreateBullet(this);
        hasCooldown = true;
        TimedEffectFactory.Create(gameEntity, Cooldown, () => {
            hasCooldown = false;
        });
    }

    private void CreateBullet(AttackAction attackAction)
    {
        float rotY = Attacker.Transform.rotation.eulerAngles.y + ((UnityEngine.Random.value * (2 * Spread)) - Spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, Attacker.Transform.position, bulletRotation);
        bullet.AttackAction = this;
        bullet.Layers = new string[] { LayerConstants.PLAYER, LayerConstants.WALLS };
        bullet.Speed = ProjectileSpeed;
    }

    public override void Hit(IAttackable attackable)
    {
        Attack attack = new AttackBuilder()
         .Attacker(Attacker)
         .Damage(Damage).Build();
        attackable.RecieveAttackHandler.RecieveAttack(attack);
    }
}


	

