using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultAttack : AttackAction {

    private Bullet bulletObject;
    private GameEntity gameEntity;
    private bool hasCooldown = false;

    public new float Cooldown { get; set; }

    public PlayerDefaultAttack (GameEntity gameEntity) {
        this.gameEntity = gameEntity;
        Damage = 10;
        Cooldown = 0.2f;
        bulletObject = Resources.Load<Bullet>("simple_bullet");
    }

    public override void Activate(IAttacker attacker) {
        if(hasCooldown) {
            return;
        }
        CreateBullet(attacker);
        hasCooldown = true;
        TimedEffectFactory.Create(gameEntity, Cooldown, () => {
            hasCooldown = false;
        });
    }

    private void CreateBullet(IAttacker attacker) {
        Attack attack = new AttackBuilder()
            .Attacker(attacker)
            .AttackableLayers(new string[] { LayerConstants.ENEMY, LayerConstants.WALLS })
            .Damage(Damage).Build();
        Bullet bullet = GameObject.Instantiate<Bullet>(bulletObject, attacker.Transform.position, attacker.Transform.rotation);
        bullet.Attack = attack;
        bullet.Speed = 10;
    }

}
