using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Effect : IEffect {

    Action activate;
    Func<float, bool> update;

    public Effect(Action activate, Func<float, bool> update) {
        this.activate = activate;
        this.update = update;
    }

    public void Activate() {
        activate();
    }

    public bool Update(float deltaTime) {
        return update(deltaTime);
    }
}
