using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Rigidbody myRb;
	public float moveSpeed;

	public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		myRb = GetComponent<Rigidbody> ();
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thePlayer != null) {
			transform.LookAt (thePlayer.transform.position);
		}

	}

	void FixedUpdate () {
		myRb.velocity = (transform.forward * moveSpeed);
	}
}
