using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameEntity, IMovable, IAttackable, IAttacker {

    public const float DEFAULT_ENEMY_MOVEMENT_SPEED = 6;
    public const float DEFAULT_ENEMY_MOVEMENT_FLOATINESS = 7;

    public float movementSpeed = DEFAULT_ENEMY_MOVEMENT_SPEED;

    public const string ATTACK_PRIMARY = "attack_primary";

    public float MovementSpeed {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }

    public float movementFloatiness = DEFAULT_ENEMY_MOVEMENT_FLOATINESS;

    public float MovementFloatiness {
        get { return movementFloatiness; }
        set { movementFloatiness = value; }
    }

    public MovementHandler MovementHandler { get; set; }

    public Rigidbody Rigidbody { get; set; }

    public RecieveAttackHandler RecieveAttackHandler { get; protected set; }

    protected int hitPoints;
    public int HitPoints {
        get { return hitPoints; }
        set {
            hitPoints = value;
            if (currentHitPoints > hitPoints) {
                currentHitPoints = hitPoints;
            }
        }
    }

    protected int currentHitPoints;
    public int CurrentHitPoints {
        get { return currentHitPoints; }
        set {
            currentHitPoints = value;
            if (currentHitPoints > HitPoints) {
                currentHitPoints = HitPoints;
            }
        }
    }

    public Transform Transform {
        get {
            return transform;
        }
    }

    private Dictionary<string, AttackAction> attackActions = new Dictionary<string, AttackAction>();

    public Dictionary<string, AttackAction> AttackActions {
        get { return attackActions; }
    }

    protected void Awake() {
        InitStats();
        InitHandlers();
        InitEffects();
        AttackActions.Add(ATTACK_PRIMARY, new EnemyDefaultAttack(this));
    }

    void Start() {
        InitComponents();
    }

    protected new void FixedUpdate() {
        base.FixedUpdate();
        MovementHandler.Update(Time.fixedDeltaTime);
    }

    protected void InitStats() {
        HitPoints = 30;
        CurrentHitPoints = 30;
    }

    protected void InitHandlers() {
        MovementHandler = new MovementHandler(this);
        RecieveAttackHandler = new RecieveAttackHandler(this);
    }

    private void InitEffects() {
        RecieveAttackHandler.RecieveAttackCreators.Add(new TemporaryColorChangeEffectCreator(this, Color.white));
		RecieveAttackHandler.DeathCreators.Add (new ScoreUpdateEffectCreator ());
    }

    private void InitComponents() {
        Rigidbody = GetComponent<Rigidbody>();
        if (Rigidbody == null) {
            throw new KuggenException("Rigidbody can not be null for " + this);
        }
    }
}
