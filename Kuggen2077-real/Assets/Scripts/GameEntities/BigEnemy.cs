using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{

    public const string ATTACK_PRIMARY = "attack_primary";

    public new const string PREFAB = "enemies/enemy-big";

    protected new void Awake()
    {
        base.Awake();
        AttackActions.Add(ATTACK_PRIMARY, new EnemyDefaultAttack(this));
    }

    protected override void InitEffects()
    {
        base.InitEffects();
        RecieveAttackHandler.RecieveAttackCreators.Add(new TemporaryColorChangeEffectCreator(this, Color.white));
        RecieveAttackHandler.DeathCreators.Add(new ScoreUpdateEffectCreator(1));
    }

    protected override void InitStats()
    {
        HitPoints = 200;
        CurrentHitPoints = 200;
        MovementSpeed = new FloatStat(1);
        MovementFloatiness = 2;
    }

}
