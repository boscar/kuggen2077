using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperPickup : PickupCollider {

    protected override void Pickup(Player player) {
        Debug.Log("Picked up sniper rifle");
        player.AttackActions[Player.ATTACK_PRIMARY] = new SniperAttackAction(player);
    }

}
