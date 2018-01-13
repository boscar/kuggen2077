using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ActionRecieveAttackEffectCreator : RecieveAttackEffectCreator {

    private Action ActivateAction { get; set; }
    private Func<float, bool> UpdateFunc { get; set; }

    public ActionRecieveAttackEffectCreator(IAttackable attackable, Action activateAction) : this(attackable, activateAction, null) { }

    public ActionRecieveAttackEffectCreator(IAttackable attackable, Action activateAction, Func<float, bool> updateFunc) : base(attackable) {
        ActivateAction = activateAction;
        UpdateFunc = updateFunc;
    }

    public override bool Activate(Attack attack) {
        ActivateAction();
        if (UpdateFunc != null) {
            Attackable.ActivateEffect(new ActionRecieveAttackEffect(UpdateFunc), GameEntity.EffectFrequency.FIXED_UPDATE);
        }
        return true;
    }

    public class ActionRecieveAttackEffect : IEffect {
        public string Id { get { return this.ToString(); } }

        private Func<float, bool> updateFunction;
        private float timer = 0;

        public ActionRecieveAttackEffect(Func<float, bool> updateFunc) {
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
