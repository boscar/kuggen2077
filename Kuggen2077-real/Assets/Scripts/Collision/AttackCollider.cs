using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour {

    public AttackAction AttackAction { get; set; }
    public string[] AttackableLayers { get; set; }
    public bool Continous { get; set; }
    public float AttackInterval { get; set; }

    private bool isActivated = true;
    public bool IsActivated {
        get { return isActivated; }
        set { isActivated = value; }
    }

    private List<GameObject> ignoredGameObjects = new List<GameObject>();

    public void OnTriggerEnter(Collider collider) {
        TryImpact(collider);
    }

    public void OnTriggerStay(Collider collider) {
        TryImpact(collider);
    }

    private void TryImpact(Collider collider) {
        if(!IsActivated) {
            return;
        }
        if (ignoredGameObjects.Contains(collider.gameObject)) {
            return;
        }
        if (Utils.Contains(AttackableLayers, LayerMask.LayerToName(collider.gameObject.layer))) {
            Impact(collider);
        }
    }

    protected virtual void Impact(Collider collider) {
        GameEntity entity = ComponentDictionary.GetEntity(collider);
        if (entity != null && entity is IAttackable) {
            AttackAction.Hit((IAttackable)entity);
            ignoredGameObjects.Add(collider.gameObject);
            if(Continous) {
                StartCoroutine(StopIgnoreCourantine(collider.gameObject, AttackInterval));
            }
        }
    }

    private IEnumerator StopIgnoreCourantine(GameObject gameObject, float duration) {
        yield return new WaitForSeconds(duration);
        if (gameObject != null) {
            ignoredGameObjects.Remove(gameObject);
        }
    }

}
