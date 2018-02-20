using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitEffectCreator {

    protected IAttacker Attacker { get; set; }

    protected HitEffectCreator(IAttacker attacker) {
        Attacker = attacker;
    }

    public abstract bool Activate(Attack attack);

}
