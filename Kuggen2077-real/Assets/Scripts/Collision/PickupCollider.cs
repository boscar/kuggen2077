using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupCollider : AbstractCollider {

    public void Awake() {
        Layers = new string[] { LayerConstants.PLAYER };
    }

    protected override void Impact(Collider collider) {
        GameEntity entity = ComponentDictionary.GetEntity(collider);
        if (entity != null && entity is Player) {
            Pickup((Player)entity);
            ignoredGameObjects.Add(collider.gameObject);
            if (Continous) {
                StartCoroutine(StopIgnoreCourantine(collider.gameObject, Interval));
            }else {
                Destroy(gameObject);
            }
        }
    }

    protected abstract void Pickup(Player player);

}
