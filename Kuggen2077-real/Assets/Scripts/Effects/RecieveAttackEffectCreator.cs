using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RecieveAttackEffectCreator {

    protected IAttackable Attackable { get; set; }

    protected RecieveAttackEffectCreator (IAttackable attackable) {
        Attackable = attackable;
    }

    public abstract bool Activate(Attack attack);

}
