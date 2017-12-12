using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuilder {

    private IAttacker attacker;
    private string[] attackableLayers;
    private int damage = 0;
    private float projectileSpeed = 0;

    public AttackBuilder Attacker(IAttacker attacker) {
        this.attacker = attacker;
        return this;
    }

    public AttackBuilder AttackableLayers(string[] attackableLayers) {
        this.attackableLayers = attackableLayers;
        return this;
    }

    public AttackBuilder Damage(int damage) {
        this.damage = damage;
        return this;
    }

    public AttackBuilder ProjectileSpeed(float projectileSpeed) {
        this.projectileSpeed = projectileSpeed;
        return this;
    }

    public Attack Build () {
        return new Attack(attacker, attackableLayers, damage, projectileSpeed);
    }
}
