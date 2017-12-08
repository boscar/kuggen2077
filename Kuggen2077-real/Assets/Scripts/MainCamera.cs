using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private static MainCamera instance;
    public static MainCamera Instance {
        get { return instance;  }    
    }

    public Camera Camera { get; private set; }

	void Awake () {
        Camera = GetComponent<Camera>();
        if (Camera == null) {
            throw new KuggenException(this + " needs to have a Camera component.");
        }
        instance = this;
    }
}
