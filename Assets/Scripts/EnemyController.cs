using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AbstractEnemy {

	private Rigidbody myRb;
	public float moveSpeed;

	public IPlayerController[] thePlayers;

    private Transform target;

	// Use this for initialization
	void Start () {
		myRb = GetComponent<Rigidbody> ();
		thePlayers = FindObjectsOfType<IPlayerController> ();
        if(thePlayers.Length > 0) {
            target = thePlayers[Random.Range(0, thePlayers.Length)].transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
            transform.LookAt (target.position);
		}

	}

	void FixedUpdate () {
		myRb.velocity = (transform.forward * moveSpeed);
	}
}
