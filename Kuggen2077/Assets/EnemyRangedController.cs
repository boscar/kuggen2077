using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedController : AbstractEnemy {

    private Rigidbody myRb;
    public float moveSpeed;

    public IPlayerController[] thePlayers;

    private Transform target;

    public GunController theGun;


    // Use this for initialization
    void Start() {
        myRb = GetComponent<Rigidbody>();
		thePlayers = FindObjectsOfType<IPlayerController> ();
        theGun.isFiring = true;
        target = thePlayers[Random.Range(0, thePlayers.Length)].transform;
    }

    // Update is called once per frame
    void Update() {
        if (target != null) {
            transform.LookAt(target.position);
        }

    }

    void FixedUpdate() {
        if (target != null && Vector3.Distance(transform.position, target.position) > 10) {
            myRb.velocity = (transform.forward * moveSpeed);
        }
    }
}
