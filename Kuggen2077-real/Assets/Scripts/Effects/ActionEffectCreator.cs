using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionEffectCreator : EffectCreator {

    private Action ActivateAction { get; set; }
    private Func<float, bool> UpdateFunc { get; set; }

    public ActionEffectCreator(GameEntity gameEntity, Action activateAction) : this(gameEntity, activateAction, null) { }

    public ActionEffectCreator(GameEntity gameEntity, Action activateAction, Func<float, bool> updateFunc) : base(gameEntity) {
        ActivateAction = activateAction;
        UpdateFunc = updateFunc;
    }

    public override bool Activate() {
        ActivateAction();
        if (UpdateFunc != null) {
            GameEntity.ActivateEffect(new ActionEffect(UpdateFunc), GameEntity.EffectFrequency.FIXED_UPDATE);
        }
        return true;
    }

    public class ActionEffect : IEffect {
        public string Id { get { return this.ToString(); } }

        private Func<float, bool> updateFunction;
        private float timer = 0;

        public ActionEffect(Func<float, bool> updateFunc) {
            this.updateFunction = updateFunc;
        }

        public void Activate() {
            //NOOPs
        }

        public bool Update(float deltaTime) {
            timer += deltaTime;
            return updateFunction(timer);
        }

    }
}
