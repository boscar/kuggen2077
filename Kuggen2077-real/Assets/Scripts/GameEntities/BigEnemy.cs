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
        AttackActions.Add(ATTACK_PRIMARY, new EnemyDefaultAttack(this, 30));
        SpawnYValue = 1;
    }

    protected override void InitEffects()
    {
        base.InitEffects();
        Renderer renderer = GetBodyRenderer();
        if (renderer != null) {
            RecieveAttackHandler.RecieveAttackCreators.Add(new TemporaryColorChangeEffectCreator(this, renderer, Color.white));
        }
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
