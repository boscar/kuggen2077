using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefaultAttack : AttackAction {

	private AttackCollider attackCollider;

	public EnemyDefaultAttack (IAttacker attacker, int damage) : base(attacker) {
		Damage = damage;
        attackCollider = attacker.Transform.gameObject.GetComponentInChildren<AttackCollider>();
        InitAttackCollider(attackCollider);
    }

    private void InitAttackCollider (AttackCollider attackCollider) {
        if (attackCollider == null) {
            Debug.LogError("AttackCollider not set for " + this);
            return;
        }
        attackCollider.AttackAction = this;
        attackCollider.Layers = new string[] { LayerConstants.PLAYER };
        attackCollider.Continous = true;
        attackCollider.Interval = 0.5f;
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

    public override void Hit(IAttackable attackable, Transform transform) {
        Attack attack = new AttackBuilder()
            .Attacker(Attacker)
            .Damage(Damage).Build();
        attackable.RecieveAttackHandler.RecieveAttack(attack);
    }

}
