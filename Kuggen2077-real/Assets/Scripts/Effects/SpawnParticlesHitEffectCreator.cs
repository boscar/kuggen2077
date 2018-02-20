using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticlesHitEffectCreator : HitEffectCreator {

    private ParticleSystem ParticleSystem { get; set; }
    private float Duration { get; set; }

    public SpawnParticlesHitEffectCreator(IAttacker attacker, string particlePrefabPath, float duration) : base(attacker) {
        ParticleSystem = Resources.Load<ParticleSystem>(particlePrefabPath);
        Duration = duration;
    }

    public override bool Activate(Attack attack) {
        if (ParticleSystem == null) {
            return false;
        }
        if (!(Attacker is GameEntity)) {
            return false;
        }

        ParticleSystem particleSystemInstance = GameObject.Instantiate<ParticleSystem>(ParticleSystem,
            attack.Position,
            Utils.MirrorRotation(attack.Rotation));
        ((GameEntity)Attacker).ActivateEffect(new SpawnParticlesHitEffect(particleSystemInstance, Duration));

        return true;
    }

    public class SpawnParticlesHitEffect : IEffect {
        public string Id { get { return this.ToString(); } }

        private ParticleSystem ParticleSystem { get; set; }
        private float duration;
        private float timer = 0;

        public SpawnParticlesHitEffect(ParticleSystem particleSystem, float duration) {
            this.ParticleSystem = particleSystem;
            this.duration = duration;
        }

        public void Activate() {
            if (ParticleSystem == null) {
                return;
            }
            ParticleSystem.Play();
        }

        public bool Update(float deltaTime) {
            timer += deltaTime;
            if(timer < duration) {
                return false;
            }
            GameObject.Destroy(ParticleSystem);
            return true;
        }

    }

}
