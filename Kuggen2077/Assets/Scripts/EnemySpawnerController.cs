using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour {

	public AbstractEnemy enemy;

	public float spawnRate;
	private float spawnCount;

    public bool Active { get; set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!Active) {
            return;
        }
		spawnCount -= Time.deltaTime;
		if (spawnCount <= 0) {
			AbstractEnemy newEnemy = Instantiate<AbstractEnemy> (enemy, gameObject.transform.position, gameObject.transform.rotation);
			spawnCount = (spawnRate / ((30 + Time.time) / 30));
		}
	}
}
