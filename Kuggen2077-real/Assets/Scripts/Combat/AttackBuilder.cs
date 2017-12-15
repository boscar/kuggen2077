using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuilder {

    private IAttacker attacker;
    private int damage = 0;

    public AttackBuilder Attacker(IAttacker attacker) {
        this.attacker = attacker;
        return this;
    }

    public AttackBuilder Damage(int damage) {
        this.damage = damage;
        return this;
    }

    public Attack Build () {
        return new Attack(attacker, damage);
    }
}
