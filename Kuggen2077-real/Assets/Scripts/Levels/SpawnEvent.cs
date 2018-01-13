using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : Event {

    protected Vector3 Position { get; set; }
    protected GameEntity GameEntityToSpawn { get; set; }

    public SpawnEvent(GameEntity gameEntity, Vector3 position, float timeStamp) : base(timeStamp) {
        Position = position;
        GameEntityToSpawn = gameEntity;
    }

    public override void Activate() {
        GameObject.Instantiate<GameEntity>(GameEntityToSpawn, Position, Quaternion.identity);
    }

}
