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

            DieDelayed();
        }
    }

    public void Die () {
        GameEntity.Destroy(Attackable.Transform.gameObject);
    }

    public void DieDelayed() {
        DestroyRenderers();
        DestroyColliders();
        ((MonoBehaviour)Attackable).StartCoroutine(DieCourantine(2));
    }

    private void DestroyRenderers() {
        Renderer renderer = ((MonoBehaviour)Attackable).GetComponent<Renderer>();
        if (renderer != null) {
            renderer.enabled = false;
        }
        foreach (Renderer childRenderer in Attackable.Transform.GetComponentsInChildren<Renderer>()) {
            childRenderer.enabled = false;
        }
    }

    private void DestroyColliders() {
        Collider collider = ((MonoBehaviour)Attackable).GetComponent<Collider>();
        if (collider != null) {
            collider.enabled = false;
        }
        foreach (Collider childCollider in Attackable.Transform.GetComponentsInChildren<Collider>()) {
            childCollider.enabled = false;
        }
    }

    private IEnumerator DieCourantine(float delay) {
        yield return new WaitForSeconds(delay);
        Die();
    }
}
