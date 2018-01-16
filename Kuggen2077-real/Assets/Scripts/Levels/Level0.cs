using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : Level {

    public Transform NorthSpawnPoint;
    public Transform EastSpawnPoint;
    public Transform SouthSpawnPoint;
    public Transform WestSpawnPoint;

    private Enemy EnemyObject { get; set; }
    private Enemy EnemyRangedObject { get; set; }

    protected new void Start () {
        base.Start();
        if (NorthSpawnPoint == null || EastSpawnPoint == null || SouthSpawnPoint == null || WestSpawnPoint == null) {
            throw new KuggenException("Spawn point must be set for " + this);
        }
        LoadPrefabs();
        Sections = CreateSections();
    }

    private void LoadPrefabs () {
        EnemyObject = Resources.Load<Enemy>(Enemy.PREFAB);
        Debug.Log(RangeEnemy.PREFAB);
        EnemyRangedObject = Resources.Load<Enemy>(RangeEnemy.PREFAB);
        Debug.Log(EnemyRangedObject);
    }

    private List<Section> CreateSections() {
        List<Section> sections = new List<Section>();

        sections.Add(CreateFirstSection());
        sections.Add(CreateSecondSection());
        sections.Add(CreateThirdSection());

        foreach (Section section in sections) {
            section.Events.Sort((x, y) => x.TimeStamp.CompareTo(y.TimeStamp));
        }
        sections.Sort((x, y) => x.Index.CompareTo(y.Index));

        return sections;
    }

    private Section CreateFirstSection() {
        Section section = new Section(0);

        section.Events.Add(new SpawnEvent(EnemyRangedObject, NorthSpawnPoint.position, 2));
        
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 5));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 5.9f));

        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 9));
        section.Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 9.9f));

        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 13));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 13.9f));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 13.9f));
        section.Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 13));

        section.Events.Add(new SpawnEnemyEvent(EnemyRangedObject, NorthSpawnPoint.position, 17,
            () => {
                StartCoroutine(FinishSectionCourantine(section, 5));
                Debug.Log("Section 1 complete!");
            }
        ));

        return section;
    }

    private Section CreateSecondSection() {
        Section section = new Section(1);

        section.Events.Add(new SpawnEvent(EnemyRangedObject, SouthSpawnPoint.position, 2));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 2.5f));
        section.Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 2.9f));

        section.Events.Add(new SpawnEvent(EnemyRangedObject, WestSpawnPoint.position, 7));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, EastSpawnPoint.position, 7.5f));
        
        section.Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 12f));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 11.8f));
        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 12.1f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, WestSpawnPoint.position, 12.9f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, NorthSpawnPoint.position, 12.9f));

        section.Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 17f));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 16.8f));
        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 17.1f));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 16.9f));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 17.8f));
        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 18.1f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, NorthSpawnPoint.position, 19.9f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, WestSpawnPoint.position, 18.9f));
        section.Events.Add(new SpawnEnemyEvent(EnemyRangedObject, SouthSpawnPoint.position, 18.9f,
            () => {
                StartCoroutine(FinishSectionCourantine(section, 5));
                Debug.Log("Section 2 complete!");
            }
        ));

        return section;
    }


    private Section CreateThirdSection() {
        Section section = new Section(2);

        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 2.5f));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 2.9f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, EastSpawnPoint.position, 3.5f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, WestSpawnPoint.position, 3.9f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, EastSpawnPoint.position, 4.5f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, WestSpawnPoint.position, 4.9f));

        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 7));
        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 7.5f));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 8));
        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 8.5f));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 9));
        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 9.5f));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 10));
        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 10.5f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, WestSpawnPoint.position, 11));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, NorthSpawnPoint.position, 12.5f));

        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 17));
        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 17.5f));
        section.Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 17.1f));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 17.8f));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 18));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, NorthSpawnPoint.position, 18.5f));
        section.Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 18.1f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, EastSpawnPoint.position, 18.8f));
        section.Events.Add(new SpawnEvent(EnemyObject, WestSpawnPoint.position, 19));
        section.Events.Add(new SpawnEvent(EnemyObject, NorthSpawnPoint.position, 19.5f));
        section.Events.Add(new SpawnEvent(EnemyObject, SouthSpawnPoint.position, 19.1f));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 19.8f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, WestSpawnPoint.position, 20));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, NorthSpawnPoint.position, 20.5f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, SouthSpawnPoint.position, 20.1f));
        section.Events.Add(new SpawnEvent(EnemyRangedObject, EastSpawnPoint.position, 20.8f));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 21.8f));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 22.8f));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 23.8f));
        section.Events.Add(new SpawnEvent(EnemyObject, EastSpawnPoint.position, 24.8f));
        section.Events.Add(new SpawnEnemyEvent(EnemyRangedObject, NorthSpawnPoint.position, 25,
            () => {
                StartCoroutine(FinishSectionCourantine(section, 5));
                Debug.Log("Section 3 complete!");
            }
        ));

        return section;
    }

    protected IEnumerator FinishSectionCourantine(Section section, float duration) {
        yield return new WaitForSeconds(duration);
        if (section != null) {
            section.IsFinished = true;
        }
    }

}
