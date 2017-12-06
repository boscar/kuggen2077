using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponSpawnerController : MonoBehaviour {

	public GameObject weapon;

	public float spawnRate;
    public float spawnChance = 0.1f;
	private float spawnCount;

	// Use this for initialization
	void Start () {
		spawnCount = spawnRate;
	}

	// Update is called once per frame
	void Update () {
		if (shouldSpawnPickup ()) {
			spawnCount -= Time.deltaTime;
			if (spawnCount <= 0 && (UnityEngine.Random.value < spawnChance * Time.deltaTime)) {
				GameObject newPickup = Instantiate (weapon, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				newPickup.transform.parent = gameObject.transform;

                PickupController puc = newPickup.GetComponent<PickupController>();
                Array weapontypes = Enum.GetValues(typeof(PickupController.PickupType));
                System.Random random = new System.Random();
                PickupController.PickupType type = (PickupController.PickupType)weapontypes.GetValue(random.Next(weapontypes.Length));
                puc.pickupType = type;

                spawnCount = spawnRate;
			}
		}
	}

	bool shouldSpawnPickup(){
		return (gameObject.transform.childCount == 0);
	}
}
