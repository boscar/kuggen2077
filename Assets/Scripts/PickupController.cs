using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	private Hashtable guns = new Hashtable();
	private Hashtable colors = new Hashtable();

	private float[] selectedGun;


	// Use this for initialization
	void Start () {
		// add guns. This should really be objects instead....
		float[] gun1 = { 20f, 0.5f, 20f };
		guns.Add (0, gun1);
		colors.Add (0, Color.red);

		float[] gun2 = { 7f, 0.05f, 2f };
		guns.Add (1, gun2);
		colors.Add (1, Color.blue);

		// Randomize gun;
		int gunIndex = 0;
		float random = Random.Range(0f,1f);
		Debug.Log (random);
		if (random > 0.5) {
			gunIndex = 1;
		}

		Color c = (Color) colors [gunIndex];
		gameObject.GetComponent<Renderer>().material.SetColor ("_Color", c);

		selectedGun = guns [gunIndex] as float[];

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
			other.gameObject.GetComponent<PlayerController> ().changeGun (selectedGun[0], selectedGun[1], selectedGun[2]);
		}	
	}
}
