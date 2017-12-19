using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : Level {

    public Transform NorthSpawnPoint;
    public Transform EastSpawnPoint;

    private GameObject EnemyObject { get; set; }

    protected new void Start () {
        base.Start();
        if (NorthSpawnPoint == null || EastSpawnPoint == null) {
            throw new KuggenException("Spawn point must be set for " + this);
        }
        LoadPrefabs();
        AddEnemySpawnEvents();
        Events.Sort((x, y) => x.TimeStamp.CompareTo(y.TimeStamp));
    }

    private void LoadPrefabs () {
        EnemyObject = Resources.Load<GameObject>(Enemy.PREFAB);
    }

    private void AddEnemySpawnEvents() {
        Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 2));
        Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 4));
    }

}
