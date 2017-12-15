using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAction {

    public IAttacker Attacker { get; protected set; }
    public int Damage { get; protected set; }
    public float Cooldown { get; protected set; }

    public AttackAction(IAttacker attacker) {
        Attacker = attacker;
    }

    public abstract void InitAttack();

    public abstract void Hit(IAttackable attackable);

}
