using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveAttackHandler {

    private IAttackable Attackable { get; set; }

	public List<SoundEffectCreator> RecieveAttackSoundEffects { get; private set; }
	public List<SoundEffectCreator> DeathSoundEffects { get; private set; }

    public List<RecieveAttackEffectCreator> RecieveAttackCreators { get; private set; }
	public List<RecieveAttackEffectCreator> DeathCreators { get; private set; }

    public RecieveAttackHandler(IAttackable attackable) {
        if (attackable == null) {
            throw new KuggenException("IAttacker can not be null for " + this);
        }
        Attackable = attackable;
        
		RecieveAttackSoundEffects = new List<SoundEffectCreator> ();
		DeathSoundEffects = new List<SoundEffectCreator> ();

		RecieveAttackCreators = new List<RecieveAttackEffectCreator>();
		DeathCreators = new List<RecieveAttackEffectCreator>();
    }

	public void RecieveAttack(Attack attack) {
        foreach(RecieveAttackEffectCreator creators in RecieveAttackCreators) {
            creators.Activate(attack);
        }

		foreach(SoundEffectCreator sound in RecieveAttackSoundEffects) {
			sound.Activate();
		}

        Attackable.CurrentHitPoints -= attack.Damage;
        if (Attackable.CurrentHitPoints <= 0) {
			foreach(RecieveAttackEffectCreator death in DeathCreators) {
				death.Activate(attack);
			}

			foreach(SoundEffectCreator sound in DeathSoundEffects) {
				sound.Activate ();
			}

			Die();
        }
    }

    public void Die () {
        GameEntity.Destroy(Attackable.Transform.gameObject);
    }

}
