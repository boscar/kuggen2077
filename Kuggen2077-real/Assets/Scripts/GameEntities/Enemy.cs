using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameEntity, IMovable {

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

	void Awake () {
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
	}

	private void InitComponents() {
		Rigidbody = GetComponent<Rigidbody>();
		if (Rigidbody == null) {
			throw new KuggenException("Rigidbody can not be null for " + this);
		}
	}
}
