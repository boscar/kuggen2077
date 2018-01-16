using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSectionBuilder {

    private int index;
    private float duration = RandomSection.MEDIUM;
    private float spawnAmount = 3f;
    private Transform[] spawnPoints;
    private Enemy[] enemyObjects;

    public RandomSectionBuilder Index(int index) {
        this.index = index;
        return this;
    }

    public RandomSectionBuilder Duration (float duration) {
        this.duration = duration;
        return this;
    }

    public RandomSectionBuilder SpawnAmount(float spawnAmount) {
        this.spawnAmount = spawnAmount;
        return this;
    }

    public RandomSectionBuilder SpawnPoints(Transform[] spawnPoints) {
        this.spawnPoints = spawnPoints;
        return this;
    }

    public RandomSectionBuilder EnemyObjects(Enemy[] enemyObjects) {
        this.enemyObjects = enemyObjects;
        return this;
    }

    public RandomSection Create () {
        if(index < 0) {
            throw new KuggenException("Index in Random Section can not be lower than 0. Did you set the index?");
        }
        if (spawnPoints == null) {
            throw new KuggenException("Must assign spawn points for Section");
        }
        if (enemyObjects == null) {
            throw new KuggenException("Must assign enemyobjects for Section");
        }

        return new RandomSection(index, duration, spawnAmount, spawnPoints, enemyObjects);
    }

}
