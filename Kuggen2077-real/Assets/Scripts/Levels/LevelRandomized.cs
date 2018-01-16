using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRandomized : Level {

    public Transform[] enemySpawnPoints;
    
    private Enemy EnemyObject { get; set; }
    private Enemy EnemyRangedObject { get; set; }

    protected new void Start() {
        base.Start();
        LoadPrefabs();
        //Sections = LoadSections();
    }

    private void LoadPrefabs() {
        EnemyObject = Resources.Load<Enemy>(Enemy.PREFAB);
        EnemyRangedObject = Resources.Load<Enemy>(RangeEnemy.PREFAB);
    }

}
