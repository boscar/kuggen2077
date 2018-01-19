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
		playerReference.AddObserver (this);
		InitUI ();
	}

	private void InitUI () {
		try {
			healthSlider = Utils.FindComponentInChildWithTag<Slider>(gameObject, "Health");
			scoreText = Utils.FindComponentInChildWithTag<Text>(gameObject, "Score");
			weaponText = Utils.FindComponentInChildWithTag<Text>(gameObject, "Weapon");
		} catch (System.Exception ex) {
			throw new KuggenException ("Unable to find gameobjects tagged 'Health', 'Score' or 'Weapon' in " + this);
		}

		if (healthSlider == null) {
			throw new KuggenException("Object tagged 'Health' requires Slider component: " + this);
		}	

		if (scoreText == null) {
			throw new KuggenException("Object tagged 'Score' needs Text component: " + this);
		}	

		if (weaponText == null) {
			throw new KuggenException ("Object tagged 'Weapon' needs a Text component: " + this);
		}
	}
	
	public void OnUpdate(Player player) {
		healthSlider.value = (float) player.CurrentHitPoints / (float)player.HitPoints;
		scoreText.text = Utils.LeftPad (player.GetScore().ToString (), 2, "0");
		weaponText.text = player.AttackActions [Player.ATTACK_PRIMARY].displayName;
	}
}
