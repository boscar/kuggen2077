using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

    public enum PickupType { MINIGUN, SHOTGUN }

    public PickupType pickupType;

    public void Start() {
        Destroy(gameObject, 10);
        switch (pickupType) {
            case PickupType.MINIGUN:
                GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                break;
            case PickupType.SHOTGUN:
                GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
                break;
            default:
                GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                break;
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            HealPlayer(other.GetComponent<PlayerHealthManager>(), 1.0f);
            Destroy(gameObject);
            switch (pickupType) {
                case PickupType.MINIGUN:
                    PickupMinigun(other.GetComponent<IPlayerController>()); break;
                case PickupType.SHOTGUN:
                    PickupShotgun(other.GetComponent<IPlayerController>());
                    break;
                default: break;
            }
        }
    }

    private void HealPlayer(PlayerHealthManager healthManager, float amount) {
        healthManager.HurtPlayer(-amount);
    }


    public void PickupMinigun(IPlayerController playerController) {
        MinigunController mgc = Instantiate<MinigunController>(Resources.Load<MinigunController>("MiniGun"), playerController.theGun.transform.position, playerController.theGun.transform.rotation, playerController.transform);
        Destroy(playerController.theGun);
        playerController.theGun = mgc;

    }


    public void PickupShotgun(IPlayerController playerController) {
        ShotgunController sgc = Instantiate<ShotgunController>(Resources.Load<ShotgunController>("Shotgun"), playerController.theGun.transform.position, playerController.theGun.transform.rotation, playerController.transform);
        Destroy(playerController.theGun);
        playerController.theGun = sgc;

    }
}
