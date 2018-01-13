using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAction {

	public string displayName = "";

    public IAttacker Attacker { get; protected set; }
    public int Damage { get; protected set; }
    public float Force { get; protected set; }
    public float Cooldown { get; protected set; }

    protected bool hasCooldown = false;

    public AttackAction(IAttacker attacker) {
        Attacker = attacker;
    }

    public abstract void InitAttack();

    public abstract void Hit(IAttackable attackable, Vector3 position);

}
