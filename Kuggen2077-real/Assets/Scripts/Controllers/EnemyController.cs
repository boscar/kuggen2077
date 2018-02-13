using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Enemy enemy;
	public Player player;
    public Animator anim;

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
        if(player == null && Level.Instance != null) {
			SetPlayer ();
        }
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            throw new KuggenException("Animator where unable to instantiate. Be sure to add an Animator Component" + this);
        }
    }
	
	private void SetPlayer(){
		List<Player> alivePlayers = Level.Instance.Players.FindAll (delegate(Player p) {
			return p.CurrentHitPoints > 0;
		});
		player = Utils.GetRandom<Player>(alivePlayers);
	}

	// Update is called once per frame
	void Update () {
		if (player == null || !(player.CurrentHitPoints > 0)) {
			SetPlayer ();
		}

		movementVector = transform.forward;
        direction = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
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
