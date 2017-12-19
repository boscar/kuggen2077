using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : Event {

    private Vector3 Position { get; set; }
    private GameObject GameObjectToSpawn { get; set; }

    public SpawnEvent(GameObject gameObject, Vector3 position, float timeStamp) : base(timeStamp) {
        Position = position;
        GameObjectToSpawn = gameObject;
    }

    public override void Activate() {
        GameObject.Instantiate<GameObject>(GameObjectToSpawn, Position, Quaternion.identity);
    }

}
