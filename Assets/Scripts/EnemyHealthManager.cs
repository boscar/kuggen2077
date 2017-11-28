using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {


	public int health;
	private int currentHealth;
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

	public void HurtEnemy(int damage){
		currentHealth -= damage;
	}
}
