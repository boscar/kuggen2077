using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperPickup : PickupCollider {

    public const string RESOURCE_PATH = "pickups/sniper-pickup";
    public const string WEAPON_PATH = "weapons/sniper";

    private GameObject weaponGameObject;

    public new void Awake() {
        base.Awake();
        weaponGameObject = Resources.Load<GameObject>(WEAPON_PATH);
    }

    protected override void Pickup(Player player) {
        Debug.Log("Picked up sniper rifle");
		player.setAttackAction (Player.ATTACK_PRIMARY, new SniperAttackAction(player));
        player.CurrentHitPoints += 10;
        ChangeWeaponObject(player.gameObject);
    }

    private void ChangeWeaponObject(GameObject playerGameObject) {
        GameObject oldWeapon = Utils.FindChildWithTag(playerGameObject, WEAPON_TAG);
        GameObject newWeapon = GameObject.Instantiate<GameObject>(weaponGameObject, oldWeapon.transform.position, oldWeapon.transform.rotation, oldWeapon.transform.parent);
        GameObject.Destroy(oldWeapon);
    }

}
