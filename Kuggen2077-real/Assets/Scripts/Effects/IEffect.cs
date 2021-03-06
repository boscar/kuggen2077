﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect {

    string Id { get; }

    void Activate();

    /**
     * Return true if the effect is finished.
     */
    bool Update(float deltaTime);
}
