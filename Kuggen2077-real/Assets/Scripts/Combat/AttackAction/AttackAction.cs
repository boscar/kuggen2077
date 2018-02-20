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

    private List<HitEffectCreator> hitEffectCreators = new List<HitEffectCreator>();
    public List<HitEffectCreator> HitEffectCreators {
        get { return hitEffectCreators; }
    }

    public AttackAction(IAttacker attacker) {
        Attacker = attacker;
    }

    public abstract void InitAttack();

    public abstract void Hit(IAttackable attackable, Transform transform);

    protected void ActivateHitEffects (Attack attack) {
        foreach (HitEffectCreator hitEffectCreator in HitEffectCreators) {
            hitEffectCreator.Activate(attack);
        }
    }

}
