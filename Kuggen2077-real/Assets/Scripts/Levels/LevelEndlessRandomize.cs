using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndlessRandomize : Level {

    public Transform[] enemySpawnPoints;

    public Section CreateSection(int index) {
        Enemy[] enemyObjects = GetEnemyObjects(index);
        return new RandomSectionBuilder(0)
            .Strength(2f)
            .SpawnPoints(enemySpawnPoints)
            .EnemyObjects(enemyObjects)
            .Create();
    }

    private Enemy[] GetEnemyObjects(int index) {
        return null;
    }

}
