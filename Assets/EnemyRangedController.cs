using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedController : AbstractEnemy {

    private Rigidbody myRb;
    public float moveSpeed;

    public PlayerController thePlayer;

    public GunController theGun;


    // Use this for initialization
    void Start() {
        myRb = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        theGun.isFiring = true;
    }

    // Update is called once per frame
    void Update() {
        if (thePlayer != null) {
            transform.LookAt(thePlayer.transform.position);
        }

    }

    void FixedUpdate() {
        if (Vector3.Distance(transform.position, thePlayer.transform.position) > 10) {
            myRb.velocity = (transform.forward * moveSpeed);
        }
    }
}
