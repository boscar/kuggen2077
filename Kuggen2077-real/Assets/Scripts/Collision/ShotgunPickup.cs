using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : PickupCollider {

    public const string RESOURCE_PATH = "pickups/shotgun-pickup";

    protected override void Pickup(Player player) {
        Debug.Log("Picked up shotgun");
		player.setAttackAction (Player.ATTACK_PRIMARY, new ShotgunAttackAction (player));
    }

}
