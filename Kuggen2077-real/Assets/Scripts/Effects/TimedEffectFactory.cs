using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimedEffectFactory {

    public static void Create(GameEntity gameEntity, float duration, Action action) {
        gameEntity.effects.Add(new TimedEffect(duration, action));
    }

    public class TimedEffect : IEffect {

        private float timer;
        private float duration;
        private Action action; 

        public TimedEffect(float duration, Action action) {
            this.duration = duration;
            this.action = action;
        }

        public bool Update(float deltaTime) {
            timer += deltaTime;
            if (timer >= duration) {
                action();
                return true;
            }
            return false;
        }
    }
}
