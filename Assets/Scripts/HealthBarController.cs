using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour {

	private float startingHealth;
	private float currentHealth;

	public IPlayerController player;
	private PlayerHealthManager healthManager;

	private GameObject currentHealthBar;
	private GameObject maxHealthBar;


	// Use this for initialization
	void Start () {
		healthManager = player.GetComponent<PlayerHealthManager> ();
		startingHealth = healthManager.getStartingHealth();
		currentHealth = startingHealth;
	
		currentHealthBar = transform.Find("current").gameObject;

        Debug.Log (currentHealthBar.ToString ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;
		currentHealth = healthManager.getCurrentHealth();

		float c = (float)currentHealth;
		float s = (float) startingHealth;
		float xScale = c / s;
		transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);

		if (xScale < 0.5) {
			currentHealthBar.GetComponent<Renderer> ().material.SetColor ("_Color", Color.red);
		}
	}
}
