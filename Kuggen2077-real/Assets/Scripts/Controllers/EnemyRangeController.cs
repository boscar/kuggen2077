using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeController : MonoBehaviour {

    public RangeEnemy enemy;
    public Player player;

    private ObservableCollider attackCollider;

    private Vector3 movementVector;
    private Vector3 direction = Vector3.zero;

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
    }

    // Update is called once per frame
    void Update () {
        movementVector = transform.forward;
        direction = player.transform.position;
    }

    protected void FixedUpdate()
    {
        HandleMovement(Time.fixedDeltaTime);
        HandleShoot(Time.fixedDeltaTime);
    }

    private void HandleMovement(float deltaTime)
    {
        transform.LookAt(direction);

        if (enemy.MovementHandler == null)
        {
            return;
        }

        enemy.MovementHandler.BasicMove(movementVector);
    }

    private void HandleShoot(float deltaTime)
    {
        AttackAction primaryAttackAction = enemy.AttackActions[RangeEnemy.ATTACK_PRIMARY];
        if (primaryAttackAction != null)
        {
            primaryAttackAction.InitAttack();
        }      
    }
}
