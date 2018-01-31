using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour {

    public static Level Instance { get; private set; }

    public Transform[] powerupSpawnPoints;

    protected float timer = 0;
    public List<Player> Players { get; set; }
    protected List<Section> Sections { get; set; }

    protected void Start () {
        Players = new List<Player> (FindObjectsOfType<Player>());
        Instance = this;
	}

    protected void FixedUpdate () {
        timer += Time.fixedDeltaTime;
        if(Sections != null) {
            HandleSections(Time.fixedDeltaTime);
        }
	}

    private void HandleSections(float deltaTime) {
        if (Sections.Count > 0) {
            if (Sections[0].IsFinished) {
                Sections.RemoveAt(0);
                timer = 0;
            } else {
                HandleEvents(Sections[0].Events);
                HandlePickups(deltaTime, Sections[0].PowerupSpawnChance, powerupSpawnPoints, Sections[0].Powerups);
            }
        }
    }

    protected void HandleEvents(List<Event> events) {
        if (events.Count > 0 && timer >= events[0].TimeStamp) {
            events[0].Activate();
            events.RemoveAt(0);
        }
    }

    protected void HandlePickups (float deltaTime, float spawnChance, Transform[] spawnPoints, PickupCollider[] pickups) {
        if(pickups.Length <= 0) {
            return;
        }
        if (Random.value <= deltaTime * spawnChance) {
            SpawnPickup(spawnPoints, pickups);
        }
    }

    private void SpawnPickup(Transform[] spawnPoints, PickupCollider[] pickups) {
        if(spawnPoints.Length <= 0) {
            Debug.LogError("No powerup spawn points assigned to level.");
            return;
        }
        Transform spawnPoint = Utils.GetRandom<Transform>(spawnPoints);
        PickupCollider pickupObject = Utils.GetRandom<PickupCollider>(pickups);
        PickupCollider pickup  = Instantiate<PickupCollider>(pickupObject, spawnPoint.position, spawnPoint.rotation);
        pickup.DestroyDelayed(10.0f);
    }

}
