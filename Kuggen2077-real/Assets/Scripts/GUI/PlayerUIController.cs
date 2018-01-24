using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour, IObserver<Player> {

	public Player playerReference;

	public GameObject AlivePanel;
	public GameObject DeadPanel;

	public Slider healthSlider;
	public Image sliderFillArea;
	public Text scoreText;
	public Text weaponText;

	public Color Highlight;

	void Awake () {
		playerReference.AddObserver (this);
		if (sliderFillArea != null){
			sliderFillArea.color = Highlight;
		}
	}
	
	public void OnUpdate(Player player) {
		if (player.CurrentHitPoints <= 0) {
			ShowDead (player);
		} else {
			ShowAlive (player);
		}
	}

	void ShowDead(Player player){
		healthSlider.value = 0;
		AlivePanel.SetActive (false);
		DeadPanel.SetActive (true);
	}

	void ShowAlive(Player player){
		AlivePanel.SetActive (true);
		DeadPanel.SetActive (false);

		healthSlider.value = (float)player.CurrentHitPoints / (float)player.HitPoints;
		scoreText.text = Utils.LeftPad (player.GetScore ().ToString (), 2, "0");
		weaponText.text = player.AttackActions [Player.ATTACK_PRIMARY].displayName;
	}
}
