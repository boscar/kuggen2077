using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunPickup : PickupCollider {

    protected override void Pickup(Player player) {
        Debug.Log("Picked up machine gun");
		player.setAttackAction (Player.ATTACK_PRIMARY, new MachineGunAttackAction (player));
    }

}