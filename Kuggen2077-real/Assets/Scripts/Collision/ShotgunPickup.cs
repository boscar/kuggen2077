using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : PickupCollider {

    protected override void Pickup(Player player) {
        Debug.Log("Picked up shotgun");
		player.setAttackAction (Player.ATTACK_PRIMARY, new ShotgunAttackAction (player));
    }

}
