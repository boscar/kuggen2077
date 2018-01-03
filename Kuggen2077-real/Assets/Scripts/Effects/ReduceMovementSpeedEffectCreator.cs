using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceMovementSpeedEffectCreator : EffectCreator {

    private string Id;
    private float easingFactor;
    private float slowMultiplier;
    private float duration;

    public ReduceMovementSpeedEffectCreator(Player player, float slowMultiplier, float duration, float easingFactor) : base(player) {
        Id = ToString();
        this.slowMultiplier = slowMultiplier;
        this.easingFactor = easingFactor;
        this.duration = duration;
    }

    public override bool Activate() {
        ReduceMovementSpeedEffect effect = GameEntity.GetEffect<ReduceMovementSpeedEffect>(Id);
        if (effect == null) {
            effect = new ReduceMovementSpeedEffect((Player)GameEntity, slowMultiplier, duration, easingFactor, Id);
        }
        return true;
    }

    public class ReduceMovementSpeedEffect : IEffect {

        public string Id { get; private set; }

        private Player player;
        private float easingFactor = 1;
        private float slowMultiplier;
        private float duration;

        public float Timer { get; set; }

        public ReduceMovementSpeedEffect(Player player, float slowMultiplier, float duration, float easingFactor, string id) {
            this.player = player;
            this.slowMultiplier = slowMultiplier;
            this.easingFactor = easingFactor;
            this.duration = duration;
            this.Id = id;
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
            player.MovementSpeed.UpdateMultiplier(Id, slowMultiplier);
            return false;
        }

    }

}
