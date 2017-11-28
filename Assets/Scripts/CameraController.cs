using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController player;
	public bool followPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (followPlayer) {
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, player.transform.position.z); 
		}
	}
}
