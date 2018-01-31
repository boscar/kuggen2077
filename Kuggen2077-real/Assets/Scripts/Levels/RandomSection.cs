using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSection : Section {

    public const float SHORT = 30;
    public const float MEDIUM = 45;
    public const float LONG = 65;
    
    private const float SPAWN_INTERVAL = 0.4f;
    private const float SEGMENT_DURATION = 8f;
    private const float SEGMENT_DURATION_VARIATION = 2f;

    public RandomSection (int index, float duration, float strength, float powerupSpawnChance, Transform[] spawnPoints, Enemy[] enemyObjects) : base(index, powerupSpawnChance, DEFAULT_POWERUPS) {
        Events = GenerateEnemyEvents(duration, strength, spawnPoints, enemyObjects);
    }

    private List<Event> GenerateEnemyEvents(float duration, float strength, Transform[] spawnPoints, Enemy[] enemyObjects) {
        List<Event> events = new List<Event>();
        
        List<float> spawnTimestamps = GetSpawnTimestamps(duration);

        for (int i = 0; i < spawnTimestamps.Count; ++i) {
                events.AddRange(GetTimestampEvents(spawnTimestamps[i], strength, spawnPoints, enemyObjects, i == (spawnTimestamps.Count - 1)));
        }

        return events;
    }

    private List<float> GetSpawnTimestamps(float duration) {
        List<float> timestamps = new List<float>();
        float timestamp = 0;
        while(duration > (SEGMENT_DURATION * 0.5f)) {
            timestamp = timestamp + SEGMENT_DURATION - SEGMENT_DURATION_VARIATION + (Random.value * (2 * SEGMENT_DURATION_VARIATION));
            duration = duration - timestamp;
            timestamps.Add(timestamp);
        }
        return timestamps;
    }

    private List<Event> GetTimestampEvents(float timestamp, float strength, Transform[] spawnPoints, Enemy[] enemyObjects, bool lastTimestamp) {
        List<Event> events = new List<Event>();

        int strengthOfEnemies = GetStrenthOfEnemies(strength);
        List<Vector3> timestampSpawnPositions = GetTimestampSpawnPositions(spawnPoints);
        Enemy[] timestampEnemyObjects = GetTimestampEnemyObjects(enemyObjects);

        while(strengthOfEnemies >= 1) {
            Enemy enemy = Utils.GetRandom<Enemy>(timestampEnemyObjects);
            strengthOfEnemies -= enemy.Strength;
            if (lastTimestamp && strengthOfEnemies <= 0) {
                events.Add(
                    new SpawnEnemyEvent(enemy, Utils.GetRandom<Vector3>(timestampSpawnPositions), timestamp,
                        () => {
                            Level.Instance.StartCoroutine(FinishSectionCourantine(this, SEGMENT_DURATION));
                            Debug.Log("Section complete!");
                        }));
            } else {
                events.Add(new SpawnEvent(enemy, Utils.GetRandom<Vector3>(timestampSpawnPositions), timestamp));
            }
            timestamp = timestamp + SPAWN_INTERVAL + (SPAWN_INTERVAL * Random.value);
        }

        return events;
    }

    private int GetStrenthOfEnemies (float strength) {
        float baseAmount = strength * 1.2f;
        float offset = baseAmount * 0.15f;
        return (int)(baseAmount - offset + (Random.value * (2 * offset)));
    }

    private List<Vector3> GetTimestampSpawnPositions(Transform[] spawnPoints) {
        List<Vector3> spawnPositions = new List<Vector3>();
        spawnPositions.Add(Utils.GetRandom<Transform>(spawnPoints).position);
        float randomValue = Random.value;
        if (randomValue > 0.2f) {
            spawnPositions.Add(Utils.GetRandom<Transform>(spawnPoints).position);
        }
        if (randomValue > 0.4f) {
            spawnPositions.Add(Utils.GetRandom<Transform>(spawnPoints).position);
        }
        if (randomValue > 0.6f) {
            spawnPositions.Add(Utils.GetRandom<Transform>(spawnPoints).position);
        }
        if (randomValue > 0.8f) {
            spawnPositions.Add(Utils.GetRandom<Transform>(spawnPoints).position);
        }
        return spawnPositions;
    }

    private Enemy[] GetTimestampEnemyObjects(Enemy[] enemyObjects) {
        return new Enemy[3] {
            Utils.GetRandom<Enemy>(enemyObjects),
            Utils.GetRandom<Enemy>(enemyObjects),
            Utils.GetRandom<Enemy>(enemyObjects)
        };
    }

    protected IEnumerator FinishSectionCourantine(Section section, float duration) {
        yield return new WaitForSeconds(duration);
        if (section != null) {
            section.IsFinished = true;
        }
    }

}
