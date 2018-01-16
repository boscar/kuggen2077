using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunPickup : PickupCollider {

    public const string RESOURCE_PATH = "pickups/machine-gun-pickup";

    protected override void Pickup(Player player) {
        Debug.Log("Picked up machine gun");
		player.setAttackAction (Player.ATTACK_PRIMARY, new MachineGunAttackAction (player));
    }

}