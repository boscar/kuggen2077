using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler {

    public IAttacker Attacker { get; private set; }

    public AttackHandler (IAttacker attacker) {
        if (attacker == null) {
            throw new KuggenException("IAttacker can not be null for " + this);
        }
        Attacker = attacker;
    }

    public void Attack(string id) {
        AttackAction attackAction = Attacker.AttackActions[id];
        if (attackAction != null) {
            attackAction.Activate(Attacker);
        }
    }

}
