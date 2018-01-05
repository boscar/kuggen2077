using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryColorChangeEffectCreator : RecieveAttackEffectCreator {

    private const float DURATION = 0.1f;

    private Renderer Renderer { get; set; }
    private Color Color { get; set; }
    private Color OriginalColor { get; set; }

    public TemporaryColorChangeEffectCreator(IAttackable attackable, Color color) : base(attackable) {
        Renderer = Attackable.Transform.GetComponent<Renderer>();
        if (Renderer == null) {
            throw new KuggenException(this + " requires a renderer.");
        }
        OriginalColor = Renderer.material.GetColor("_Color");
        Color = color;
    }

    public override bool Activate(Attack attack) {
        Attackable.ActivateEffect(new TemporaryColorChangeEffect(Renderer, OriginalColor, Color, DURATION), GameEntity.EffectFrequency.FIXED_UPDATE);
        return true;
    }

    public class TemporaryColorChangeEffect : IEffect {
        public string Id { get { return this.ToString() + this.GetHashCode(); } }

        private Renderer renderer;
        private Color color;
        private Color originalColor;
        private float timer = 0;
        private float duration;

        public TemporaryColorChangeEffect(Renderer renderer, Color originalColor, Color color, float duration) {
            this.renderer = renderer;
            this.color = color;
            this.originalColor = originalColor;
            this.duration = duration;
        }

        public void Activate() {
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
