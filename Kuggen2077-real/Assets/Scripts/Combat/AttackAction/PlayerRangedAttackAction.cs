using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerRangedAttackAction : RangedAttackAction<Player> {

	protected AudioHandler AudioHandler;
	protected AudioClip fireSound;

	public PlayerRangedAttackAction(Player player) : base(player) {
		AudioHandler = player.AudioHandler;
	}

	protected override abstract void Fire();
}
