using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IColliderObserver {

	public Enemy enemy;
	public Player player;

	private ObservableCollider attackCollider;

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

		if (attackCollider == null) {
			attackCollider = GetComponentInChildren<ObservableCollider> ();
			attackCollider.addObserver (this);
		}

		if (attackCollider == null) {
			throw new KuggenException("Attack Collider can not be null for " + this);
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

	// handle collison
	public void HandleTriggerEnter(Collider col){
		Debug.Log ("enter111111");
	}

	public void HandleTriggerStay(Collider col) {
	}

	public void HandleTriggerExit(Collider col) {
		Debug.Log ("exit1111111");
	}
}
