using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section {

    private const float DEFAULT_POWERUP_SPAWN_CHANCE = 0.05f;

    private static PickupCollider[] DEFAULT_POWERUPS {
        get {
            return new PickupCollider[] {
                Resources.Load<PickupCollider>(MachineGunPickup.RESOURCE_PATH),
                Resources.Load<PickupCollider>(ShotgunPickup.RESOURCE_PATH),
                Resources.Load<PickupCollider>(SniperPickup.RESOURCE_PATH)
            };
        }
    }

    public List<Event> Events { get; set; }
    public bool IsFinished { get; set; }
    public int Index { get; private set; }

    public float PowerupSpawnChance { get; set; }
    public PickupCollider[] Powerups { get; private set; }

    public Section (int index) : this(index, DEFAULT_POWERUP_SPAWN_CHANCE, DEFAULT_POWERUPS) { }

    public Section(int index, float spawnChance) : this(index, spawnChance, DEFAULT_POWERUPS) { }

    public Section (int index, float spawnChance, PickupCollider[] powerups) {
        Index = index;
        Events = new List<Event>();
        PowerupSpawnChance = spawnChance;
        Powerups = powerups;
    }
}
