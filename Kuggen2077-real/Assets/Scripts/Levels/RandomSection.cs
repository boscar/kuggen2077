using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSection : Section {

    public const float SHORT = 18;
    public const float MEDIUM = 30;
    public const float LONG = 45;

    public RandomSection (int index, float duration, float spawnAmount, Transform[] spawnPoints, Enemy[] enemyObjects) : base(index, DEFAULT_POWERUP_SPAWN_CHANCE, DEFAULT_POWERUPS) {
        Events = GenerateEnemyEvents(duration, spawnAmount, spawnPoints, enemyObjects);
    }

    private List<Event> GenerateEnemyEvents(float duration, float spawnAmount, Transform[] spawnPoints, Enemy[] enemyObjects) {
        List<Event> events = new List<Event>();

        List<float> spawnTimestamps = GetSpawnTimestamps(duration, spawnAmount);

        return events;
    }

    private List<float> GetSpawnTimestamps(float duration, float spawnAmount) {
        List<float> timestamps = new List<float>();
        float spawnInterval = GetSpawnInterval(spawnAmount);
        float intervalOffset = spawnInterval * 0.4f;
        while(duration > (spawnInterval + intervalOffset)) {
            float timestamp = spawnInterval - intervalOffset + (Random.value * (2 * intervalOffset));
            duration =- timestamp;
            timestamps.Add(timestamp);
        }
        return timestamps;
    }

    private float GetSpawnInterval(float spawnAmount) {
        return 2f + (spawnAmount / 1.7f);
    }
}
