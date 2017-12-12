using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveAttackHandler : MonoBehaviour {

    private IAttackable Attackable { get; set; }

    public RecieveAttackHandler(IAttackable attackable) {
        if (attackable == null) {
            throw new KuggenException("IAttacker can not be null for " + this);
        }
        Attackable = attackable;
    }

	public void RecieveAttack(Attack attack) {
        Attackable.CurrentHitPoints -= attack.Damage;
        if (Attackable.CurrentHitPoints <= 0) {
            Die();
        }
    }

    public void Die () {
        GameEntity.Destroy(Attackable.Transform.gameObject);
    }

}
