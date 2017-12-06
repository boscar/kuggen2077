using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {


	public float health;
	private float currentHealth;
    public GameObject corpse;

    private Renderer rend;
    private Color defaultColor;

    // Use this for initialization
    void Start () {
		currentHealth = health;
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.GetColor("_Color");
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
        setColorWhite();
        Invoke("setColorDefault", 0.1f);
    }

    void setColorWhite() {
        rend.material.SetColor("_Color", Color.white);
    }

    void setColorDefault() {
        rend.material.SetColor("_Color", defaultColor);
    }
}
