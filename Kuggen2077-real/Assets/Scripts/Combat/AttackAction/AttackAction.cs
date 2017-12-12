using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAction {

    public int Damage { get; protected set; }
    public float Cooldown { get; protected set; }

    public abstract void Activate(IAttacker attacker);

}
