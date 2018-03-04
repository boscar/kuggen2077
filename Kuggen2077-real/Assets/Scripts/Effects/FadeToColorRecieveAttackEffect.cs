using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToColorRecieveAttackEffect : RecieveAttackEffectCreator {

    private Renderer Renderer { get; set; }
    private Color Color { get; set; }
    private Color OriginalColor { get; set; }
    private float delay = 0;
    private float duration = 1;

    public FadeToColorRecieveAttackEffect(IAttackable attackable, Renderer renderer, Color color, float delay, float duration) : base(attackable) {
        Renderer = renderer;
        OriginalColor = Renderer.material.GetColor("_Color");
        Color = color;
        this.delay = delay;
        this.duration = duration;
    }

    public override bool Activate(Attack attack) {
        Attackable.ActivateEffect(new FadeToColorEffect(Renderer, OriginalColor, Color, delay, duration), GameEntity.EffectFrequency.FIXED_UPDATE);
        return true;
    }

    public class FadeToColorEffect : IEffect {
        public string Id { get { return this.ToString() + this.GetHashCode(); } }

        private Renderer renderer;
        private Color color;
        private Color originalColor;
        private float timer = 0;
        private float delay = 0;
        private float duration;

        public FadeToColorEffect(Renderer renderer, Color originalColor, Color color, float delay, float duration) {
            this.renderer = renderer;
            this.color = color;
            this.originalColor = originalColor;
            this.delay = delay;
            this.duration = duration;
        }

        public void Activate() {
            Debug.Log("Activating this shit!");
            //NOOP
        }

        public bool Update(float deltaTime) {
            timer += deltaTime;
            renderer.material.SetColor("_Color", GetInterpolatedColor());
            if (timer >= duration) {
                return true;
            }
            return false;
        }

        private Color GetInterpolatedColor() {
            float percentage = timer / duration;
            return new Color(
                    ((originalColor.r * (1 - percentage)) + (color.r * percentage)) / 2,
                    ((originalColor.g * (1 - percentage)) + (color.g * percentage)) / 2,
                    ((originalColor.b * (1 - percentage)) + (color.b * percentage)) / 2,
                    ((originalColor.a * (1 - percentage)) + (color.a * percentage)) / 2
                );
        }

    }
}
