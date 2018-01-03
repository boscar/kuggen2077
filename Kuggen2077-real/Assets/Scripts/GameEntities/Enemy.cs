using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : GameEntity, IMovable, IAttackable, IAttacker {

    public const float DEFAULT_ENEMY_MOVEMENT_SPEED = 3;
    public const float DEFAULT_ENEMY_MOVEMENT_FLOATINESS = 3;

    public const string PREFAB = "enemies/enemy-basic";

    protected float movementSpeed = DEFAULT_ENEMY_MOVEMENT_SPEED;
    public FloatStat MovementSpeed { get; set; }

    protected float movementFloatiness = DEFAULT_ENEMY_MOVEMENT_FLOATINESS;
    public float MovementFloatiness {
        get { return movementFloatiness; }
        set { movementFloatiness = value; }
    }

    public MovementHandler MovementHandler { get; set; }
    public RecieveAttackHandler RecieveAttackHandler { get; protected set; }
    public AttackHandler AttackHandler { get; protected set; }

    public Rigidbody Rigidbody { get; set; }
    

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
    }

    void Start() {
        InitComponents();
    }

    protected new void FixedUpdate() {
        base.FixedUpdate();
        MovementHandler.Update(Time.fixedDeltaTime);
    }

    protected abstract void InitStats();


    protected void InitHandlers() {
        MovementHandler = new MovementHandler(this);
        RecieveAttackHandler = new RecieveAttackHandler(this);
        AttackHandler = new AttackHandler(this);
    }

	protected abstract void InitEffects();

    private void InitComponents() {
        Rigidbody = GetComponent<Rigidbody>();
        if (Rigidbody == null) {
            throw new KuggenException("Rigidbody can not be null for " + this);
        }
    }
}
