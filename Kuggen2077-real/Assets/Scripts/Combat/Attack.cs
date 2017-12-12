using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack {

    public IAttacker Attacker { get; private set; }
    public string[] AttackableLayers { get; private set; }
    public int Damage { get; private set; }
    public float ProjectileSpeed { get; private set; }

    public Attack(IAttacker attacker, string[] attackableLayers, int damage, float projectileSpeed) {
        Attacker = attacker;
        AttackableLayers = attackableLayers;
        Damage = damage;
        ProjectileSpeed = projectileSpeed;
    }

}
