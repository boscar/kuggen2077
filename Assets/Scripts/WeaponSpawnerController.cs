using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnerController : MonoBehaviour {

	public GameObject weapon;

	public float spawnRate;
	private float spawnCount;

	// Use this for initialization
	void Start () {
		spawnCount = spawnRate;
	}

	// Update is called once per frame
	void Update () {
		if (shouldSpawnPickup ()) {
			spawnCount -= Time.deltaTime;
			if (spawnCount <= 0) {
				GameObject newPickup = Instantiate (weapon, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				newPickup.transform.parent = gameObject.transform;

				spawnCount = spawnRate;
			}
		}
	}

	bool shouldSpawnPickup(){
		return (gameObject.transform.childCount == 0);
	}
}
