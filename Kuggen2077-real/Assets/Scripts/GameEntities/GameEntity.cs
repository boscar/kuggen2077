using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntity : MonoBehaviour {

    public List<IEffect> effects = new List<IEffect>();
    private List<IEffect> effectsToRemove = new List<IEffect>();

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
