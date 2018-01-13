using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack {

    public IAttacker Attacker { get; private set; }
    public int Damage { get; private set; }
    public float Force { get; private set; }
    public Vector3 Position { get; private set; }

    public Attack(IAttacker attacker, int damage, float force, Vector3 position) {
        Attacker = attacker;
        Damage = damage;
        Force = force;
        Position = position;
    }

}
