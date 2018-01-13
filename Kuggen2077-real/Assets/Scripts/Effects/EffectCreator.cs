using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectCreator {

    protected GameEntity GameEntity { get; set; }

    protected EffectCreator(GameEntity gameEntity) {
        GameEntity = gameEntity;
    }

    public abstract bool Activate();

}
