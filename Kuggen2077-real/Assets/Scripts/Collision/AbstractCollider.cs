using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCollider : MonoBehaviour {
    
    public string[] Layers { get; set; }
    public bool Continous { get; set; }
    public float Interval { get; set; }

    protected bool isActivated = true;
    public bool IsActivated {
        get { return isActivated; }
        set { isActivated = value; }
    }

    protected List<GameObject> ignoredGameObjects = new List<GameObject>();

    public void OnTriggerEnter(Collider collider) {
        TryImpact(collider);
    }

    public void OnTriggerStay(Collider collider) {
        TryImpact(collider);
    }

    private void TryImpact(Collider collider) {
        if (!IsActivated) {
            return;
        }
        if (ignoredGameObjects.Contains(collider.gameObject)) {
            return;
        }
        if (Utils.Contains(Layers, LayerMask.LayerToName(collider.gameObject.layer))) {
            Impact(collider);
        }
    }

    protected abstract void Impact(Collider collider);

    protected IEnumerator StopIgnoreCourantine(GameObject gameObject, float duration) {
        yield return new WaitForSeconds(duration);
        if (gameObject != null) {
            ignoredGameObjects.Remove(gameObject);
        }
    }
}
