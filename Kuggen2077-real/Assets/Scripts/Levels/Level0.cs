using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : Level {

    public Transform NorthSpawnPoint;
    public Transform EastSpawnPoint;
    public Transform SouthSpawnPoint;
    public Transform WestSpawnPoint;

    private GameObject EnemyObject { get; set; }
    private GameObject EnemyRangedObject { get; set; }

    protected new void Start () {
        base.Start();
        if (NorthSpawnPoint == null || EastSpawnPoint == null || SouthSpawnPoint == null || WestSpawnPoint == null) {
            throw new KuggenException("Spawn point must be set for " + this);
        }
        LoadPrefabs();
        Sections = CreateSections();
    }

    private void LoadPrefabs () {
        EnemyObject = Resources.Load<GameObject>(Enemy.PREFAB);
        Debug.Log(RangeEnemy.PREFAB);
        EnemyRangedObject = Resources.Load<GameObject>(RangeEnemy.PREFAB);
        Debug.Log(EnemyRangedObject);
    }

    private List<Section> CreateSections() {
        List<Section> sections = new List<Section>();

        sections.Add(CreateFirstSection());

        foreach (Section section in sections) {
            section.Events.Sort((x, y) => x.TimeStamp.CompareTo(y.TimeStamp));
        }
        sections.Sort((x, y) => x.Index.CompareTo(y.Index));

        return sections;
    }

    private Section CreateFirstSection() {
        Section section = new Section(0);
        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 2));

        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 4));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 4.9f));

        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 7));
        section.Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 7.9f));

        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 11));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 11.9f));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 11.9f));
        section.Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 11));

        section.Events.Add(new SpawnEvent(EnemyRangedObject, NorthSpawnPoint.position, 14));

        return section;
    }

}
