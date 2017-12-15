using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefaultAttack : AttackAction {

	private AttackCollider attackCollider;

	public EnemyDefaultAttack (IAttacker attacker) : base(attacker) {
		Damage = 2;
        attackCollider = attacker.Transform.gameObject.GetComponentInChildren<AttackCollider>();
        if (attackCollider == null) {
            Debug.LogError("AttackCollider not set for " + this);
            return;
        }
        attackCollider.AttackAction = this;
        attackCollider.AttackableLayers = new string[] { LayerConstants.PLAYER };
    }

    public override void InitAttack() {
        if(attackCollider == null) {
            Debug.LogError("AttackCollider not set for " + this);
            return;
        }
        attackCollider.IsActivated = true;
    }

    public void StopAttack() {
        if (attackCollider == null) {
            Debug.LogError("AttackCollider not set for " + this);
            return;
        }
        attackCollider.IsActivated = false;
    }

    public override void Hit(IAttackable attackable) {
        Attack attack = new AttackBuilder()
            .Attacker(Attacker)
            .Damage(Damage).Build();
        attackable.RecieveAttackHandler.RecieveAttack(attack);
    }

}
