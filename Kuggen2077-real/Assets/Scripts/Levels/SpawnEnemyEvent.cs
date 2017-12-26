using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnEnemyEvent : SpawnEvent {

    private Action OnDeathAction { get; set; }

    public SpawnEnemyEvent(Enemy enemy, Vector3 position, float timeStamp) : this(enemy, position, timeStamp, null) { }

    public SpawnEnemyEvent(Enemy enemy, Vector3 position, float timeStamp, Action onDeathAction) : base(enemy, position, timeStamp) {
        OnDeathAction = onDeathAction;
    }

    public override void Activate() {
        Enemy enemy = GameObject.Instantiate<Enemy>((Enemy)GameEntityToSpawn, Position, Quaternion.identity);
        ActionRecieveAttackEffectCreator effectCreator = new ActionRecieveAttackEffectCreator(enemy, OnDeathAction);
        enemy.RecieveAttackHandler.DeathCreators.Add(effectCreator);
    }
}
