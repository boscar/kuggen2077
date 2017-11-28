using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerInterval : MonoBehaviour {

	public int damageToGive;
	public float damageInterval;
	private float damageCounter;

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			damageCounter -= Time.deltaTime;
			if (damageCounter <= 0) {
				damageCounter = damageInterval;
				damagePlayer (other.gameObject.GetComponent<PlayerHealthManager> ());
			}
		}	
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			damageCounter = 0;
		}
	}

	void damagePlayer(PlayerHealthManager manager){
		manager.HurtPlayer (damageToGive);
	}
}
