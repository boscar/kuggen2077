using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecelerateInterpolator {

    private float factor;

    public DecelerateInterpolator() {
        this.factor = 1.0f;
    }

    public DecelerateInterpolator(float factor) {
        this.factor = factor;
    }

    public float GetInterpolation(float input) {
        float result;
        if (factor == 1.0f) {
            result = (float)(1.0f - (1.0f - input) * (1.0f - input));
        } else {
            result = (float)(1.0f - Mathf.Pow((1.0f - input), 2 * factor));
        }
        return result;
    }

}
