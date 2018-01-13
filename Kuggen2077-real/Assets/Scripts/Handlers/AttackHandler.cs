using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler {

    private IAttacker Attacker { get; set; }

    public List<EffectCreator> AttackCreators { get; private set; }

    public AttackHandler(IAttacker attacker) {
        if (attacker == null) {
            throw new KuggenException("IAttacker can not be null for " + this);
        }
        Attacker = attacker;

        AttackCreators = new List<EffectCreator>();
    }

    public void HandleAttackEffects() {
        foreach (EffectCreator creator in AttackCreators) {
            creator.Activate();
        }
    }

}
