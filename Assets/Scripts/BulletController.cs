using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;
	public int damageToGive;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Enemy") {
			EnemyHealthManager healthManager = other.gameObject.GetComponent<EnemyHealthManager> ();
			Debug.Log (damageToGive);
			healthManager.HurtEnemy (damageToGive);
		}

		Destroy (gameObject,0.02f);
	}

}
