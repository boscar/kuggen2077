using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public AttackAction AttackAction { get; set; }

    public float Speed { get; set; }
    public string[] AttackableLayers { get; set; }

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
    
    public void OnTriggerEnter(Collider collider) {
        TryImpact(collider);
    }

    /*
    public void OnTriggerStay(Collider collider) {
        TryImpact(collider);
    }
    */

    private void TryImpact(Collider collider) {
        if(Utils.Contains(AttackableLayers, LayerMask.LayerToName(collider.gameObject.layer))) {
            Impact(collider);
        }
    }

    protected void Impact(Collider collider) {
        GameEntity entity = ComponentDictionary.GetEntity(collider);
        if(entity != null && entity is IAttackable) {
            AttackAction.Hit((IAttackable)entity);
        }
        Destroy(this.gameObject);
    }
}
