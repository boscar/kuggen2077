using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndlessRandomize : Level {

    public Transform[] enemySpawnPoints;
    public float startStrength = 2;
    public float strengthIncrease = 4;

    private Section CurrentSection;
    private int index = 0;

    private Enemy EnemyObject { get; set; }
    private Enemy EnemyFastHardObject { get; set; }
    private Enemy EnemyRangedObject { get; set; }

    protected new void Start() {
        base.Start();
        LoadPrefabs();
        CurrentSection = CreateSection(index);
    }

    private void LoadPrefabs() {
        EnemyObject = Resources.Load<Enemy>(Enemy.PREFAB);
        EnemyFastHardObject = Resources.Load<Enemy>(HardFastEnemy.PREFAB);
        EnemyRangedObject = Resources.Load<Enemy>(RangeEnemy.PREFAB);
    }

    protected new void FixedUpdate() {
        timer += Time.fixedDeltaTime;
        if (CurrentSection != null) {
            if (CurrentSection.IsFinished) {
                index++;
                CurrentSection = CreateSection(index);
                timer = 0;
            } else {
                HandleEvents(CurrentSection.Events);
                HandlePickups(Time.fixedDeltaTime, CurrentSection.PowerupSpawnChance, powerupSpawnPoints, CurrentSection.Powerups);
            }
        }
    }

    public Section CreateSection(int index) {
        Enemy[] enemyObjects = GetEnemyObjects(index);
        float strength = (strengthIncrease * index) + startStrength;
        return new RandomSectionBuilder(0)
            .Strength((strengthIncrease * index) + startStrength)
            .PowerupSpawnChance(0.02f + (strength * 0.003f))
            .SpawnPoints(enemySpawnPoints)
            .EnemyObjects(enemyObjects)
            .Create();
    }

    private Enemy[] GetEnemyObjects(int index) {
        if (index < 10) {
            switch (index) {
                case 0:
                    return new Enemy[1] { EnemyObject };
                case 1:
                    return new Enemy[1] { EnemyFastHardObject };
                case 2:
                    return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
                case 3:
                    return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
                case 4:
                    return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
                case 5:
                    return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
                case 6:
                    return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
                case 7:
                    return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
                case 8:
                    return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
                case 9:
                    return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
                default:
                    return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
            }
        } else {
            return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
        }
    }

}
