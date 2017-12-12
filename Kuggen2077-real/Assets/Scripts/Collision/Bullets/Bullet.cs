using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Attack Attack { get; set; }
    
    public void OnTriggerEnter(Collider collider) {
        TryImpact(collider);
    }

    /*
    public void OnTriggerStay(Collider collider) {
        TryImpact(collider);
    }
    */

    private void TryImpact(Collider collider) {
        if(Utils.Contains(Attack.AttackableLayers, LayerMask.LayerToName(collider.gameObject.layer))) {
            Impact(collider.gameObject);
        }
    }

    protected void Impact(GameObject colliderGameObject) {
        Destroy(this.gameObject);
    }
}
