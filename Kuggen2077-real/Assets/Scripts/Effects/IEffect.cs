using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect {

    /**
     * Return true if the effect is finished.
     */
    bool Update(float deltaTime);
}
