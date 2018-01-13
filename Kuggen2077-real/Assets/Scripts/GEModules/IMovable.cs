using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable {

    FloatStat MovementSpeed { get; }

    float MovementFloatiness { get; set; }

    MovementHandler MovementHandler { get; set; }

    Rigidbody Rigidbody { get; set; }

    void ActivateEffect(IEffect effect);

    void ActivateEffect(IEffect effect, GameEntity.EffectFrequency frequency);

}
