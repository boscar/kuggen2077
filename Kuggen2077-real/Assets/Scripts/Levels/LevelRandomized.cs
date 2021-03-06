﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRandomized : Level {

    public Transform[] enemySpawnPoints;
    
    private Enemy EnemyObject { get; set; }
    private Enemy EnemyRangedObject { get; set; }

    protected new void Start() {
        base.Start();
        LoadPrefabs();
        Sections = LoadSections();
    }

    private void LoadPrefabs() {
        EnemyObject = Resources.Load<Enemy>(Enemy.PREFAB);
        EnemyRangedObject = Resources.Load<Enemy>(RangeEnemy.PREFAB);
    }

    private List<Section> LoadSections () {
        List<Section> sections = new List<Section>();
        sections.Add( new RandomSectionBuilder(0)
            .Strength(2f)
            .SpawnPoints(enemySpawnPoints)
            .EnemyObjects(new Enemy[1] { EnemyRangedObject })
            .Create()
        );
        sections.Add( new RandomSectionBuilder(1)
            .SpawnPoints(enemySpawnPoints)
            .Strength(5f)
            .EnemyObjects(new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject })
            .Create()
        );
        sections.Add(new RandomSectionBuilder(2)
            .SpawnPoints(enemySpawnPoints)
            .Strength(12f)
            .EnemyObjects(new Enemy[2] { EnemyObject, EnemyRangedObject })
            .Create()
        );
        return sections;
    }

}
