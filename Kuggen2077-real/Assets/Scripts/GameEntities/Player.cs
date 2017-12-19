﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameEntity, IMovable, IAttacker, IAttackable {

	//TODO find a way to set this dynamically
	public string id = "1"; //{ get; private set; }

    public const float DEFAULT_PLAYER_MOVEMENT_SPEED = 6;
    public const float DEFAULT_PLAYER_MOVEMENT_FLOATINESS = 7;

    public const string ATTACK_PRIMARY = "attack_primary";

    public float movementSpeed = DEFAULT_PLAYER_MOVEMENT_SPEED;

    public float MovementSpeed {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }

    public float movementFloatiness = DEFAULT_PLAYER_MOVEMENT_FLOATINESS;

    public float MovementFloatiness {
        get { return movementFloatiness; }
        set { movementFloatiness = value; }
    }

    public MovementHandler MovementHandler { get; set; }
    public RecieveAttackHandler RecieveAttackHandler { get; protected set; }

    public Rigidbody Rigidbody { get; set; }

    public Transform Transform {
        get { return transform; }
    }

    public DashAbility DashAbility { get; private set; }

    private Dictionary<string, AttackAction> attackActions = new Dictionary<string, AttackAction>();

    public Dictionary<string, AttackAction> AttackActions {
        get { return attackActions;  }
    }

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

    void Awake () {
        DashAbility = new DashAbility();
        AttackActions.Add(ATTACK_PRIMARY, new PlayerDefaultAttack(this));
        InitStats();
        InitHandlers();
        InitEffects();
    }

    void Start() {
        InitComponents();
    }

    protected new void FixedUpdate() {
        base.FixedUpdate();
        if (MovementHandler != null) {
            MovementHandler.Update(Time.fixedDeltaTime);
        }
    }

    private void InitStats() {
        HitPoints = 30;
        CurrentHitPoints = 30;
    }

    private void InitHandlers() {
        MovementHandler = new MovementHandler(this);
        RecieveAttackHandler = new RecieveAttackHandler(this);
    }

    private void InitEffects() {
        RecieveAttackHandler.RecieveAttackCreators.Add(new TemporaryColorChangeEffectCreator(this, Color.white));
    }

    private void InitComponents() {
        Rigidbody = GetComponent<Rigidbody>();
        if (Rigidbody == null) {
            throw new KuggenException("Rigidbody can not be null for " + this);
        }
    }

}
