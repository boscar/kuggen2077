using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Enemy enemy;
	public Player player;

	private Vector3 movementVector;
	private Vector3 direction = Vector3.zero;


	protected void Start() {
		InitComponents();
	}

	private void InitComponents() {
		if (enemy == null) {
			enemy = GetComponent<Enemy>();
		}
		if (enemy == null) {
			throw new KuggenException("Enemy can not be null for " + this);
		}
	}
	
	// Update is called once per frame
	protected void Update() {
		movementVector = transform.forward;
		direction = player.transform.position;
	}

	protected void FixedUpdate() {
		HandleMovement(Time.fixedDeltaTime);
	}

	private void HandleMovement(float deltaTime) {
		transform.LookAt(direction);

		if (enemy.MovementHandler == null) {
			return;
		}

		enemy.MovementHandler.BasicMove(movementVector);
	}
}
