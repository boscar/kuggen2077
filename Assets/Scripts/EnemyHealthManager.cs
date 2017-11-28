using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {


	public float health;
	private float currentHealth;
    public GameObject corpse;

	// Use this for initialization
	void Start () {
		currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
            if(corpse != null) {
                corpse.GetComponent<Renderer>().enabled = true;
                corpse.transform.parent = null;
            }
            Destroy (gameObject);
			ScoreManager.addPoint ();

        }
	}

	public void HurtEnemy(float damage){
		currentHealth -= damage;
	}
}
