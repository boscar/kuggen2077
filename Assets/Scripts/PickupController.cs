using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

    public enum PickupType { MINIGUN, SHOTGUN }

    public PickupType pickupType;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Destroy(gameObject);
            switch (pickupType) {
                case PickupType.MINIGUN:
                    PickupMinigun(other.GetComponent<PlayerController>()); break;
                case PickupType.SHOTGUN:
                    PickupShotgun(other.GetComponent<PlayerController>());
                    break;
                default: break;
            }
        }
    }


    public void PickupMinigun(PlayerController playerController) {
        MinigunController mgc = Instantiate<MinigunController>(Resources.Load<MinigunController>("MiniGun"), playerController.theGun.transform.position, playerController.theGun.transform.rotation, playerController.transform);
        Destroy(playerController.theGun);
        playerController.theGun = mgc;

    }


    public void PickupShotgun(PlayerController playerController) {
        ShotgunController sgc = Instantiate<ShotgunController>(Resources.Load<ShotgunController>("Shotgun"), playerController.theGun.transform.position, playerController.theGun.transform.rotation, playerController.transform);
        Destroy(playerController.theGun);
        playerController.theGun = sgc;

    }
}
