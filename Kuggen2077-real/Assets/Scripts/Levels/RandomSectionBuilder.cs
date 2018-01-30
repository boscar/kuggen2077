using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSectionBuilder {

    private int index;
    private float duration = RandomSection.MEDIUM;
    private float strength = 5f;
    private float powerupSpawnChance = Section.DEFAULT_POWERUP_SPAWN_CHANCE;
    private Transform[] spawnPoints;
    private Enemy[] enemyObjects;

    public RandomSectionBuilder(int index) {
        this.index = index;
    }

    public RandomSectionBuilder Duration (float duration) {
        this.duration = duration;
        return this;
    }

    public RandomSectionBuilder Strength(float strength) {
        this.strength = strength;
        return this;
    }

    public RandomSectionBuilder PowerupSpawnChance(float powerupSpawnChance) {
        this.powerupSpawnChance = powerupSpawnChance;
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
        if (spawnPoints == null) {
            throw new KuggenException("Must assign spawn points for Section");
        }
        if (enemyObjects == null) {
            throw new KuggenException("Must assign enemyobjects for Section");
        }

        return new RandomSection(index, duration, strength, powerupSpawnChance, spawnPoints, enemyObjects);
    }

}
