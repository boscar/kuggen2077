using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSection : Section {

    public const float SHORT = 30;
    public const float MEDIUM = 45;
    public const float LONG = 65;

    private const float SPAWN_INTERVAL = 0.4f;

    public RandomSection (int index, float duration, float spawnAmount, Transform[] spawnPoints, Enemy[] enemyObjects) : base(index, DEFAULT_POWERUP_SPAWN_CHANCE, DEFAULT_POWERUPS) {
        Events = GenerateEnemyEvents(duration, spawnAmount, spawnPoints, enemyObjects);
    }

    private List<Event> GenerateEnemyEvents(float duration, float spawnAmount, Transform[] spawnPoints, Enemy[] enemyObjects) {
        List<Event> events = new List<Event>();

        float spawnInterval = GetSpawnInterval(spawnAmount);
        float intervalOffset = spawnInterval * 0.15f;
        
        List<float> spawnTimestamps = GetSpawnTimestamps(duration, spawnInterval, intervalOffset);

        for (int i = 0; i < spawnTimestamps.Count; ++i) {
                events.AddRange(GetTimestampEvents(spawnTimestamps[i], spawnAmount, spawnPoints, enemyObjects, i == (spawnTimestamps.Count - 1)));
        }

        return events;
    }

    private List<float> GetSpawnTimestamps(float duration, float spawnInterval, float intervalOffset) {
        List<float> timestamps = new List<float>();
        float timestamp = 0;
        while(duration > (spawnInterval + intervalOffset)) {
            timestamp = timestamp + spawnInterval - intervalOffset + (Random.value * (2 * intervalOffset));
            duration = duration - timestamp;
            timestamps.Add(timestamp);
        }
        return timestamps;
    }

    private float GetSpawnInterval(float spawnAmount) {
        return 6f + spawnAmount * 0.4f;
    }

    private List<Event> GetTimestampEvents(float timestamp, float spawnAmount, Transform[] spawnPoints, Enemy[] enemyObjects, bool lastTimestamp) {
        List<Event> events = new List<Event>();

        int amountOfEnemies = GetAmountOfEnemies(spawnAmount);
        List<Vector3> timestampSpawnPositions = GetTimestampSpawnPositions(spawnPoints, amountOfEnemies);
        Enemy[] timestampEnemyObjects = GetTimestampEnemyObjects(enemyObjects);

        for(int i = 0; i<amountOfEnemies; ++i) {
            if(lastTimestamp && i == (amountOfEnemies - 1)) {
                events.Add(
                    new SpawnEnemyEvent(Utils.GetRandom<Enemy>(timestampEnemyObjects), Utils.GetRandom<Vector3>(timestampSpawnPositions), timestamp,
                        () => {
                            Level.Instance.StartCoroutine(FinishSectionCourantine(this, 5));
                            Debug.Log("Section complete!");
                        }));
            } else {
                events.Add(new SpawnEvent(Utils.GetRandom<Enemy>(timestampEnemyObjects), Utils.GetRandom<Vector3>(timestampSpawnPositions), timestamp));
            }
            timestamp = timestamp + SPAWN_INTERVAL + (SPAWN_INTERVAL * Random.value);
        }

        return events;
    }

    private int GetAmountOfEnemies (float spawnAmount) {
        float baseAmount = spawnAmount * 1.2f;
        float offset = baseAmount * 0.15f;
        return (int)(baseAmount - offset + (Random.value * (2 * offset)));
    }

    private List<Vector3> GetTimestampSpawnPositions(Transform[] spawnPoints, int amountOfEnemies) {
        List<Vector3> spawnPositions = new List<Vector3>();
            spawnPositions.Add(Utils.GetRandom<Transform>(spawnPoints).position);
        if (amountOfEnemies >= 9) {
            spawnPositions.Add(Utils.GetRandom<Transform>(spawnPoints).position);
        }
        if (amountOfEnemies >= 7) {
            spawnPositions.Add(Utils.GetRandom<Transform>(spawnPoints).position);
        }
        if (amountOfEnemies >= 5) {
            spawnPositions.Add(Utils.GetRandom<Transform>(spawnPoints).position);
        }
        if (amountOfEnemies >= 3) {
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
