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
            Impact(collider);
        }
    }

    protected void Impact(Collider collider) {
        Debug.Log("Hit " + collider.gameObject);
        GameEntity entity = ComponentDictionary.GetEntity(collider);
        if(entity != null) {
            Debug.Log("Hit " + entity);
        }
        Destroy(this.gameObject);
    }
}
