using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedAttackAction<T> : AttackAction where T : GameEntity, IAttacker {
    
    public float Spread { get; set; }
    public float ProjectileSpeed { get; set; }

    protected Bullet bulletObject;

    public RangedAttackAction(T gameEntity) : base(gameEntity) { }

    public override void InitAttack() {
        if (hasCooldown) {
            return;
        }
        Attacker.AttackHandler.HandleAttackEffects();
        Fire();
        InitCooldown(Cooldown);
    }

    protected void InitCooldown(float cooldown) {
        hasCooldown = true;
        TimedEffectFactory.Create((GameEntity)Attacker, cooldown, () => {
            hasCooldown = false;
        });
    }

    protected abstract void Fire();

    public override void Hit(IAttackable attackable, Transform transform) {
        Attack attack = new AttackBuilder()
            .Attacker(Attacker)
            .Damage(Damage)
            .Force(Force)
            .Position(transform.position)
            .KnockbackFunc((at, att) => {
                return transform.rotation;
            })
            .Build();
        attackable.RecieveAttackHandler.RecieveAttack(attack);
    }

}
