using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

    private EnemySpawnerController[] enemySpawnerControllers;
    public int switchSpawnInterval = 10;
    private float timer = 10;


    void Start () {
        enemySpawnerControllers = transform.GetComponentsInChildren<EnemySpawnerController>();
        Debug.Log(enemySpawnerControllers.Length);
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= switchSpawnInterval / ((30 + Time.time) / 30)) {
            foreach(EnemySpawnerController e in enemySpawnerControllers) {
                e.Active = false;
            }
            enemySpawnerControllers[(int)(Random.value * enemySpawnerControllers.Length)].Active = true;
            enemySpawnerControllers[(int)(Random.value * enemySpawnerControllers.Length)].Active = true;
            enemySpawnerControllers[(int)(Random.value * enemySpawnerControllers.Length)].Active = true;

            timer = 0;
        }
	}
}
