using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedAttackAction<T> : AttackAction where T : GameEntity, IAttacker {

    protected GameEntity GameEntity { get; set; }
    public float Spread { get; set; }
    public float ProjectileSpeed { get; set; }

    protected Bullet bulletObject;

    public RangedAttackAction(T gameEntity) : base(gameEntity) {
        GameEntity = gameEntity;
    }

    public override void InitAttack() {
        if (hasCooldown) {
            return;
        }
        Fire();
        InitCooldown(Cooldown);
    }

    protected void InitCooldown(float cooldown) {
        hasCooldown = true;
        TimedEffectFactory.Create(GameEntity, cooldown, () => {
            hasCooldown = false;
        });
    }

    protected abstract void Fire();

    public override void Hit(IAttackable attackable) {
        Attack attack = new AttackBuilder()
            .Attacker(Attacker)
            .Damage(Damage).Build();
        attackable.RecieveAttackHandler.RecieveAttack(attack);
    }

}
