using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperPickup : PickupCollider {

    public const string RESOURCE_PATH = "pickups/sniper-pickup";

    protected override void Pickup(Player player) {
        Debug.Log("Picked up sniper rifle");
		player.setAttackAction (Player.ATTACK_PRIMARY, new SniperAttackAction(player));
    }

}
