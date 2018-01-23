using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour, IObserver<Player> {

	public Player playerReference;

	public Slider healthSlider;
	public Text scoreText;
	public Text weaponText;

	void Awake () {
		playerReference.AddObserver (this);
	}
	
	public void OnUpdate(Player player) {
		healthSlider.value = (float) player.CurrentHitPoints / (float)player.HitPoints;
		scoreText.text = Utils.LeftPad (player.GetScore().ToString (), 2, "0");
		weaponText.text = player.AttackActions [Player.ATTACK_PRIMARY].displayName;
	}
}
