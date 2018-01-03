using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour, IObserver<Player> {

	public Player playerReference;

	void Start () {
		playerReference.addObserver (this);
	}
	
	public void onUpdate(Player player) {
		Debug.Log (Utils.LeftPad(player.Score.ToString(), 2, "0"));
		Debug.Log (player.CurrentHitPoints);
		Debug.Log (player.AttackActions);
	}
}
