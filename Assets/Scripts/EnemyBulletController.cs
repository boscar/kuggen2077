using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : IBulletController {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			PlayerHealthManager healthManager = other.gameObject.GetComponent<PlayerHealthManager> ();
			Debug.Log (damageToGive);
			healthManager.HurtPlayer (damageToGive);
		}

		Destroy (gameObject,0.02f);
	}

}
