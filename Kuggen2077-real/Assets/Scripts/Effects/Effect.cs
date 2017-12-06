using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Effect : IEffect {

    Func<float, bool> update;
    public Effect(Func<float, bool> update) {
        this.update = update;
    }

    public bool Update(float deltaTime) {
        return update(deltaTime);
    }
}
