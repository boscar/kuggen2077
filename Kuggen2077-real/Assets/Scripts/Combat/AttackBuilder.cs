using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackBuilder {

    private IAttacker attacker;
    private int damage = 0;
    private float force = 0;
    private Vector3 position = Vector3.zero;
    private Quaternion rotation = Quaternion.Euler(Vector3.zero);
    private Func<Attack, IAttackable, Vector3> knockbackFunc = Attack.DEFAULT_KNOCKBACK_FUNC;

    public AttackBuilder Attacker(IAttacker attacker) {
        this.attacker = attacker;
        return this;
    }

    public AttackBuilder Damage(int damage) {
        this.damage = damage;
        return this;
    }

    public AttackBuilder Force(float force) {
        this.force = force;
        return this;
    }

    public AttackBuilder Position(Vector3 position) {
        this.position = position;
        return this;
    }

    public AttackBuilder Rotation(Quaternion rotation) {
        this.rotation = rotation;
        return this;
    }

    public AttackBuilder KnockbackFunc(Func<Attack, IAttackable, Vector3> knockbackFunc) {
        this.knockbackFunc = knockbackFunc;
        return this;
    }

    public Attack Build () {
        return new Attack(attacker, damage, force, position, rotation, knockbackFunc);
    }

}
