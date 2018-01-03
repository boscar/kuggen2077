using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour, IObserver<Player> {

	public Player playerReference;

	void Start () {
		playerReference.addObserver (this);
	}
	
	public void onUpdate(Player player) {
		Debug.Log (player.ToString());
	}
}
