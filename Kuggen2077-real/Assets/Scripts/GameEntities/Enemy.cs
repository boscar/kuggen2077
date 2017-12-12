using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameEntity, IMovable, IAttackable {

	public const float DEFAULT_ENEMY_MOVEMENT_SPEED = 6;
	public const float DEFAULT_ENEMY_MOVEMENT_FLOATINESS = 7;

	public float movementSpeed = DEFAULT_ENEMY_MOVEMENT_SPEED;

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
        get { return currentHitPoints;  }
        set {
            currentHitPoints = value;
            if(currentHitPoints > HitPoints) {
                currentHitPoints = HitPoints;
            }
        }
    }

    public Transform Transform {
        get {
            return transform;
        }
    }

    void Awake () {
        InitStats();
		InitHandlers();
	}

	void Start() {
		InitComponents();
	}

	protected new void FixedUpdate() {
		base.FixedUpdate();
		MovementHandler.Update(Time.fixedDeltaTime);
	}

    private void InitStats() {
        HitPoints = 30;
        CurrentHitPoints = 30;
    }

	private void InitHandlers() {
		MovementHandler = new MovementHandler(this);
        RecieveAttackHandler = new RecieveAttackHandler(this);
	}

	private void InitComponents() {
		Rigidbody = GetComponent<Rigidbody>();
		if (Rigidbody == null) {
			throw new KuggenException("Rigidbody can not be null for " + this);
		}
	}
}
