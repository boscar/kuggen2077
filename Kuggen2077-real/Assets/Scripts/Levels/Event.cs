using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event {

    public float TimeStamp { get; private set; }

    protected Event (float timeStamp) {
        TimeStamp = timeStamp;
    }

    public abstract void Activate();

}
