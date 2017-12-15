using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefaultAttack : AttackAction {

	private Bullet bulletObject;

	public EnemyDefaultAttack () {
		Damage = 2;
	}

	public override void Activate(IAttacker attacker) {
		Attack attack = new AttackBuilder()
			.Attacker(attacker)
			.AttackableLayers(new string[] { LayerConstants.ENEMY, LayerConstants.WALLS})
			.Damage(Damage).Build();

		Debug.Log ("!!attack!!");
	}

}
