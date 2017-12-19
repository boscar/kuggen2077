using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntity : MonoBehaviour {

    public enum EffectFrequency { FIXED_UPDATE };

    private List<IEffect> effects = new List<IEffect>();
    private List<IEffect> effectsToRemove = new List<IEffect>();
    public void ActivateEffect(IEffect effect) {
        ActivateEffect(effect, EffectFrequency.FIXED_UPDATE);
    }

    public void ActivateEffect(IEffect effect, EffectFrequency frequency) {
        switch (frequency) {
            case EffectFrequency.FIXED_UPDATE:
                effects.Add(effect);
                break;
            default:
                effects.Add(effect);
                break;
        }
        effect.Activate();
    }

    protected void FixedUpdate () {
        HandleEffects(Time.fixedDeltaTime);
    }

    private void HandleEffects(float deltaTime) {
        foreach (IEffect effect in effects) {
            if (effect.Update(deltaTime)) {
                effectsToRemove.Add(effect);
            }
        }
        foreach (IEffect effect in effectsToRemove) {
            effects.Remove(effect);
        }
        effectsToRemove.Clear();
    }
}
