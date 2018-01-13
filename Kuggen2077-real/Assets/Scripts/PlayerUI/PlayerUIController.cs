using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour, IObserver<Player> {

	public Player playerReference;

	private Slider healthSlider;
	private Text scoreText;
	private Text weaponText;

	void Awake () {
		playerReference.addObserver (this);
		InitUI ();
	}

	private void InitUI () {
		healthSlider = GameObject.FindGameObjectWithTag ("Health").GetComponent<Slider>();
		scoreText = GameObject.FindGameObjectWithTag ("Score").GetComponent<Text>();
		weaponText = GameObject.FindGameObjectWithTag ("Weapon").GetComponent<Text>();

		if (healthSlider == null) {
			throw new KuggenException("UI Slider object tagged 'Health' missing from " + this);
		}	

		if (scoreText == null) {
			throw new KuggenException("UI Text object tagged 'Score' missing from " + this);
		}	

		if (weaponText == null) {
			throw new KuggenException("UI Text object tagged 'Weapon' missing from " + this);
		}	
	}
	
	public void onUpdate(Player player) {
		healthSlider.value = (float) player.CurrentHitPoints / (float)player.HitPoints;
		scoreText.text = Utils.LeftPad (player.Score.ToString (), 2, "0");
		weaponText.text = player.AttackActions [Player.ATTACK_PRIMARY].displayName;
	}
}
