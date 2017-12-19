using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryColorChangeEffectCreator : RecieveAttackEffectCreator {

    private const float DURATION = 0.1f;

    private Renderer Renderer { get; set; }
    private Color Color { get; set; }

    public TemporaryColorChangeEffectCreator(IAttackable attackable, Color color) : base(attackable) {
        Renderer = Attackable.Transform.GetComponent<Renderer>();
        if (Renderer == null) {
            throw new KuggenException(this + " requires a renderer.");
        }
        Color = color;
    }

    public override bool Activate(Attack attack) {
        Attackable.ActivateEffect(new TemporaryColorChangeEffect(Renderer, Color, DURATION), GameEntity.EffectFrequency.FIXED_UPDATE);
        return true;
    }

    public class TemporaryColorChangeEffect : IEffect {

        private Renderer renderer;
        private Color color;
        private Color originalColor;
        private float timer = 0;
        private float duration;

        public TemporaryColorChangeEffect(Renderer renderer, Color color, float duration) {
            this.renderer = renderer;
            this.color = color;
            this.duration = duration;
        }

        public void Activate() {
            originalColor = renderer.material.GetColor("_Color");
            renderer.material.SetColor("_Color", color);
        }

        public bool Update(float deltaTime) {
            timer += deltaTime;
            if (timer >= duration) {
                renderer.material.SetColor("_Color", originalColor);
                return true;
            }
            return false;
        }

    }

}
