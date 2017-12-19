using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveAttackHandler {

    private IAttackable Attackable { get; set; }

    public List<RecieveAttackEffectCreator> RecieveAttackCreators { get; private set; }

    public RecieveAttackHandler(IAttackable attackable) {
        if (attackable == null) {
            throw new KuggenException("IAttacker can not be null for " + this);
        }
        Attackable = attackable;
        RecieveAttackCreators = new List<RecieveAttackEffectCreator>();
    }

	public void RecieveAttack(Attack attack) {
        foreach(RecieveAttackEffectCreator creators in RecieveAttackCreators) {
            creators.Activate(attack);
        }
        Attackable.CurrentHitPoints -= attack.Damage;
        Debug.Log(Attackable + " recieved " + attack.Damage + " damage and has " + Attackable.CurrentHitPoints + " hp.");
        if (Attackable.CurrentHitPoints <= 0) {
            Die();
        }
    }

    public void Die () {
        GameEntity.Destroy(Attackable.Transform.gameObject);
    }

}
