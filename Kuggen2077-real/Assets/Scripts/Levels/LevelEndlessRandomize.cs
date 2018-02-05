using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndlessRandomize : Level, IObservable<LevelEndlessRandomize> {

	private List<IObserver<LevelEndlessRandomize>> observers = new List<IObserver<LevelEndlessRandomize>> ();
	public List<IObserver<LevelEndlessRandomize>> Observers { get { return observers; } private set { observers = value; } }

    public Transform[] enemySpawnPoints;
    public float startStrength = 2;
    public float strengthIncrease = 4;

	private Section currentSection;
	public Section CurrentSection { 
		get { return currentSection; }
		private set {
			currentSection = value;

			if (value.Index > 0) {
				CallObservers ();
			}
		}
	}
    private int index = 0;

    private Enemy EnemyObject { get; set; }
    private Enemy EnemyFastHardObject { get; set; }
    private Enemy EnemyFastInsaneObject { get; set; }

    private Enemy EnemyRangedObject { get; set; }
    private Enemy EnemyRangedHardObject { get; set; }
    private Enemy EnemyRangedInsaneObject { get; set; }

    private Enemy EnemyBigObject { get; set; }
    private Enemy EnemyBigHardObject { get; set; }
    private Enemy EnemyBigInsaneObject { get; set; }

    protected new void Start() {
        base.Start();
        LoadPrefabs();
        CurrentSection = CreateSection(index);
    }

    private void LoadPrefabs() {
        EnemyObject = Resources.Load<Enemy>(Enemy.PREFAB);
        EnemyFastHardObject = Resources.Load<Enemy>(HardFastEnemy.PREFAB);
        EnemyFastInsaneObject = Resources.Load<Enemy>(InsaneFastEnemy.PREFAB);
        EnemyRangedObject = Resources.Load<Enemy>(RangeEnemy.PREFAB);
        EnemyRangedHardObject = Resources.Load<Enemy>(HardRangeEnemy.PREFAB);
        EnemyRangedInsaneObject = Resources.Load<Enemy>(InsaneRangeEnemy.PREFAB);
        EnemyBigObject = Resources.Load<Enemy>(BigEnemy.PREFAB);
        EnemyBigHardObject = Resources.Load<Enemy>(HardBigEnemy.PREFAB);
        EnemyBigInsaneObject = Resources.Load<Enemy>(InsaneBigEnemy.PREFAB);
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
        float strength = (strengthIncrease * index) + startStrength;
        Enemy[] enemyObjects = GetEnemyObjects(strength);
        return new RandomSectionBuilder(index)
            .Strength((strengthIncrease * index) + startStrength)
            .PowerupSpawnChance(0.02f + (strength * 0.003f))
            .SpawnPoints(enemySpawnPoints)
            .EnemyObjects(enemyObjects)
            .Create();
    }

    private Enemy[] GetEnemyObjects(float strength) {
        if(strength >= 24) {
            return new Enemy[5] { EnemyRangedInsaneObject, EnemyFastInsaneObject , EnemyRangedInsaneObject, EnemyFastInsaneObject, EnemyBigInsaneObject };
        } else if (strength >= 22) {
            return new Enemy[7] { EnemyRangedHardObject, EnemyFastHardObject, EnemyRangedInsaneObject, EnemyFastInsaneObject, EnemyRangedInsaneObject, EnemyFastInsaneObject, EnemyBigInsaneObject };
        } else if (strength >= 20) {
            return new Enemy[5] { EnemyRangedHardObject, EnemyFastHardObject, EnemyRangedInsaneObject, EnemyFastInsaneObject, EnemyBigHardObject };
        } else if (strength >= 18) {
            return new Enemy[6] { EnemyFastHardObject, EnemyRangedHardObject, EnemyFastHardObject, EnemyFastInsaneObject, EnemyRangedInsaneObject, EnemyBigHardObject };
        } else if (strength >= 16) {
            return new Enemy[6] { EnemyFastHardObject, EnemyRangedHardObject, EnemyFastHardObject, EnemyRangedHardObject, EnemyFastInsaneObject, EnemyBigHardObject };
        } else if (strength >= 14) {
            return new Enemy[5] { EnemyFastHardObject, EnemyRangedHardObject, EnemyFastHardObject, EnemyRangedHardObject, EnemyBigHardObject };
        } else if (strength >= 12) {
            return new Enemy[7] { EnemyRangedHardObject, EnemyObject, EnemyRangedObject, EnemyFastHardObject, EnemyFastHardObject, EnemyRangedHardObject, EnemyBigObject };
        } else if (strength >= 10) {
            return new Enemy[5] { EnemyRangedHardObject, EnemyObject, EnemyRangedObject, EnemyFastHardObject, EnemyBigObject };
        } else if (strength >= 8) {
            return new Enemy[6] { EnemyObject, EnemyRangedHardObject, EnemyObject, EnemyRangedObject, EnemyFastHardObject, EnemyBigObject };
        } else if (strength >= 6) {
            return new Enemy[6] { EnemyObject, EnemyRangedObject, EnemyObject, EnemyRangedObject, EnemyFastHardObject, EnemyBigObject };
        } else if (strength >= 4) {
            return new Enemy[5] { EnemyObject, EnemyRangedObject, EnemyObject, EnemyRangedObject, EnemyBigObject };
        } else if (strength >= 2) {
            return new Enemy[3] { EnemyObject, EnemyObject, EnemyRangedObject };
        } else {
            return new Enemy[1] { EnemyObject };
        }
    }

	// IObservable implementation
	public void AddObserver(IObserver<LevelEndlessRandomize> obs){
		Observers.Add (obs);
	}

	public void RemoveObserver(IObserver<LevelEndlessRandomize> obs) {
		Observers.Remove (obs);
	}

	public void CallObservers() {
		foreach (IObserver<LevelEndlessRandomize> obs in Observers) {
			obs.OnUpdate(this);
		}	
	}
}
