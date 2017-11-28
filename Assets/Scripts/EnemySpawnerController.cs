using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour {

	public EnemyController enemy;

	public float spawnRate;
	private float spawnCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spawnCount -= Time.deltaTime;
		if (spawnCount <= 0) {
			EnemyController newEnemy = Instantiate (enemy, gameObject.transform.position, gameObject.transform.rotation) as EnemyController;
			spawnCount = spawnRate;
		}
	}
}
