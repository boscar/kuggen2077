using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceMovementSpeedEffectCreator : EffectCreator {

    private string Id;
    private float slowMultiplier;
    private float duration;

    public ReduceMovementSpeedEffectCreator(Player player, float slowMultiplier, float duration) : base(player) {
        Id = ToString();
        this.slowMultiplier = slowMultiplier;
        this.duration = duration;
    }

    public override bool Activate() {
        ReduceMovementSpeedEffect effect = GameEntity.GetEffect<ReduceMovementSpeedEffect>(Id);
        if (effect == null) {
            effect = new ReduceMovementSpeedEffect((Player)GameEntity, slowMultiplier, duration, Id);
            GameEntity.ActivateEffect(effect);
        } else {
            effect.Timer = 0;
        }
        return true;
    }

    public class ReduceMovementSpeedEffect : IEffect {

        public string Id { get; private set; }

        private Player player;
        private float slowMultiplier;
        private float duration;
        private AccelerateInterpolator interpolator;

        public float Timer { get; set; }

        public ReduceMovementSpeedEffect(Player player, float slowMultiplier, float duration, string id) {
            this.player = player;
            this.slowMultiplier = slowMultiplier;
            this.duration = duration;
            this.Id = id;
            interpolator = new AccelerateInterpolator();
        }

        public void Activate() {
            //NOOP
            Timer = 0;
            player.MovementSpeed.AddMultiplier(Id, slowMultiplier);
        }

        public bool Update(float deltaTime) {
            Timer += deltaTime;
            if (Timer >= duration) {
                player.MovementSpeed.RemoveMultiplier(Id);
                return true;
            }
            float multiplier = slowMultiplier + ((1 - slowMultiplier) * interpolator.GetInterpolation(Timer / duration));
            player.MovementSpeed.UpdateMultiplier(Id, multiplier);
            return false;
        }

    }

}
