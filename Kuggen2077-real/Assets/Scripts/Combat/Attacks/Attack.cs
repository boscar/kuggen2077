using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack {

    public int Damage { get; protected set; }
    public float cooldown { get; protected set; }

    public abstract void Activate(IAttacker attacker);

}
