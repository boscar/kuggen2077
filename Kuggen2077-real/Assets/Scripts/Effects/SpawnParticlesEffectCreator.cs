using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticlesEffectCreator : EffectCreator {

    private ParticleSystem ParticleSystem { get; set; }
    private float Duration { get; set; }
    private Vector3 PositionOffset { get; set; }

    public SpawnParticlesEffectCreator(GameEntity gameEntity, string particlePrefabPath, float duration, Vector3 positionOffset) : base(gameEntity) {
        ParticleSystem = Resources.Load<ParticleSystem>(particlePrefabPath);
        Duration = duration;
        PositionOffset = positionOffset;
    }

    public override bool Activate() {
        if (ParticleSystem == null) {
            return false;
        }

        ParticleSystem particleSystemInstance = GameObject.Instantiate<ParticleSystem>(ParticleSystem,
            GameEntity.transform.position,
            GameEntity.transform.rotation,
            GameEntity.transform);
        particleSystemInstance.transform.localPosition = PositionOffset;
        GameEntity.ActivateEffect(new SpawnParticlesHitEffect(particleSystemInstance, Duration));

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
            if (timer < duration) {
                return false;
            }
            GameObject.Destroy(ParticleSystem);
            return true;
        }

    }

}
