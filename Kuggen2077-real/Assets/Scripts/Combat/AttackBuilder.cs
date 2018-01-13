using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuilder {

    private IAttacker attacker;
    private int damage = 0;
    private float force = 0;
    private Vector3 position;

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

    public Attack Build () {
        return new Attack(attacker, damage, force, position);
    }

}
