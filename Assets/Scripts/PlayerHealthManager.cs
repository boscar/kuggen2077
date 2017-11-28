using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {


	public float startingHealth;
	private float currentHealth;

	private Renderer rend;
	private Color defaultColor;


	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		rend = GetComponent<Renderer> ();
		defaultColor = rend.material.GetColor ("_Color");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			gameObject.SetActive (false);
		}
	}

	public void HurtPlayer(float damage){
		
		currentHealth -= damage;
		setColorWhite ();
		Invoke ("setColorDefault", 0.1f);
	}

	void setColorWhite(){
		rend.material.SetColor ("_Color", Color.white);
	}

	void setColorDefault(){
		rend.material.SetColor ("_Color", defaultColor);
	}

	public float getStartingHealth(){
		return startingHealth;
	}

	public float getCurrentHealth(){
		return currentHealth;
	}
}
