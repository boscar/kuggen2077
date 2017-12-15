using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AttackCollider {

    public float Speed { get; set; }

    private Rigidbody Rigidbody { get; set; }

    protected void Start() {
        Rigidbody = GetComponent<Rigidbody>();
        if (Rigidbody == null) {
            throw new KuggenException("Rigidbody can not be null for " + this);
        }
    }

    public void FixedUpdate() {
        MoveProjectile(Time.fixedDeltaTime);
    }

    protected void MoveProjectile(float deltaTime) {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
    protected override void Impact(Collider collider) {
        base.Impact(collider);
        Destroy(gameObject);
    }

}
