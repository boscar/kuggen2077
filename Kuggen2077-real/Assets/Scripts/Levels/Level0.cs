using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : Level {

    public Transform NorthSpawnPoint;
    public Transform EastSpawnPoint;
    public Transform SouthSpawnPoint;
    public Transform WestSpawnPoint;

    private GameObject EnemyObject { get; set; }
    private GameObject EnemyRangedObject { get; set; }

    protected new void Start () {
        base.Start();
        if (NorthSpawnPoint == null || EastSpawnPoint == null || SouthSpawnPoint == null || WestSpawnPoint == null) {
            throw new KuggenException("Spawn point must be set for " + this);
        }
        LoadPrefabs();
        AddEnemySpawnEvents();
        Events.Sort((x, y) => x.TimeStamp.CompareTo(y.TimeStamp));
    }

    private void LoadPrefabs () {
        EnemyObject = Resources.Load<GameObject>(Enemy.PREFAB);
        Debug.Log(RangeEnemy.PREFAB);
        EnemyRangedObject = Resources.Load<GameObject>(RangeEnemy.PREFAB);
        Debug.Log(EnemyRangedObject);
    }

    private void AddEnemySpawnEvents() {
        Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 2));

        Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 4));
        Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 4.9f));

        Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 7));
        Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 7.9f));

        Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 11));
        Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 11.9f));
        Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 11.9f));
        Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 11));

        Events.Add(new SpawnEvent(EnemyRangedObject, NorthSpawnPoint.position, 14));
    }

}
