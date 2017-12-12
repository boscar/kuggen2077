using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameEntity, IMovable, IAttacker {

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
    public AttackHandler AttackHandler { get; set; }

    public Rigidbody Rigidbody { get; set; }

    public Transform Transform {
        get { return transform; }
    }

    public DashAbility DashAbility { get; private set; }

    private Dictionary<string, AttackAction> attackActions = new Dictionary<string, AttackAction>();

    public Dictionary<string, AttackAction> AttackActions {
        get { return attackActions;  }
    }

    void Awake () {
        DashAbility = new DashAbility();
        AttackActions.Add(ATTACK_PRIMARY, new PlayerDefaultAttack());
        InitHandlers();
    }

    void Start() {
        InitComponents();
    }

    protected new void FixedUpdate() {
        base.FixedUpdate();
        MovementHandler.Update(Time.fixedDeltaTime);
    }

    private void InitHandlers() {
        MovementHandler = new MovementHandler(this);
        AttackHandler = new AttackHandler(this);
    }

    private void InitComponents() {
        Rigidbody = GetComponent<Rigidbody>();
        if (Rigidbody == null) {
            throw new KuggenException("Rigidbody can not be null for " + this);
        }
    }

}
