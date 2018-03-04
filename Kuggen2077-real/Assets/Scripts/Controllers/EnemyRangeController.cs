using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeController : MonoBehaviour {

    private const float MIN_WALK_DISTANCE = 10f;

    public RangeEnemy enemy;
    public Player player;

    private Vector3 movementVector;
    private Vector3 playerPos = Vector3.zero;

    protected void Start()
    {
        InitComponents();
    }

    private void InitComponents()
    {
        if (enemy == null)
        {
            enemy = GetComponent<RangeEnemy>();
        }
        if (enemy == null)
        {
            throw new KuggenException("Enemy can not be null for " + this);
        }
        if (player == null && Level.Instance != null) {
			SetPlayer ();
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
            return;
		}

        movementVector = transform.forward;
        if(!enemy.IsActive()) movementVector = new Vector3(0,0,0);
        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }

    protected void FixedUpdate()
    {
        HandleMovement(Time.fixedDeltaTime);
        if (enemy.IsActive())
        {  
            HandleShoot(Time.fixedDeltaTime);
        }
    }

    private void HandleMovement(float deltaTime)
    {
        if(enemy.IsActive()) {
            Vector3 direction = playerPos - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), deltaTime * 10.0f);
        }

        if (enemy.MovementHandler == null)
        {
            return;
        }

        if (player != null && Vector3.Distance(transform.position, player.transform.position) > MIN_WALK_DISTANCE) {
            enemy.MovementHandler.BasicMove(movementVector);
        } else {
            enemy.MovementHandler.BasicMove(Vector3.zero);
        }
    }

    private void HandleShoot(float deltaTime)
    {
        AttackAction primaryAttackAction = enemy.AttackActions[RangeEnemy.ATTACK_RANGE];
        if (primaryAttackAction != null)
        {
            primaryAttackAction.InitAttack();
        }      
    }
}
