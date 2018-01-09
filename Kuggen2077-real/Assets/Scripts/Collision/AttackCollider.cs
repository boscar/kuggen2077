using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : AbstractCollider {

    public AttackAction AttackAction { get; set; }

    protected override void Impact(Collider collider) {
        GameEntity entity = ComponentDictionary.GetEntity(collider);
        if (entity != null && entity is IAttackable) {
            AttackAction.Hit((IAttackable)entity, transform.position);
            ignoredGameObjects.Add(collider.gameObject);
            if(Continous) {
                StartCoroutine(StopIgnoreCourantine(collider.gameObject, Interval));
            }
        }
    }

}
