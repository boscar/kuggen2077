using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateInterpolator {

    private float factor;

    public AccelerateInterpolator() {
        this.factor = 1.0f;
    }

    public AccelerateInterpolator(float factor) {
        this.factor = factor;
    }

    public float GetInterpolation(float input) {
        if (factor == 1.0f) {
            return input * input;
        } else {
            return Mathf.Pow(input, factor);
        }
    }

}
