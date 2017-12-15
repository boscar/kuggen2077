using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack {

    public IAttacker Attacker { get; private set; }
    public int Damage { get; private set; }

    public Attack(IAttacker attacker, int damage) {
        Attacker = attacker;
        Damage = damage;
    }

}
