using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupCollider : AbstractCollider {

	protected AudioClip pickUpSound;

    public void Awake() {
        Layers = new string[] { LayerConstants.PLAYER };
		pickUpSound = Resources.Load<AudioClip>("Sounds/Player/Pickup");
    }

    protected override void Impact(Collider collider) {
        GameEntity entity = ComponentDictionary.GetEntity(collider);
        if (entity != null && entity is Player) {
			Player player = (Player)entity;
			player.AudioHandler.PlaySingle (pickUpSound);
			Pickup(player);
            ignoredGameObjects.Add(collider.gameObject);
            if (Continous) {
                StartCoroutine(StopIgnoreCourantine(collider.gameObject, Interval));
            } else {
                Destroy(gameObject);
            }
        }
    }

    public void DestroyDelayed(float delay) {
        StartCoroutine(DestroyCourantine(delay));
    }

    private IEnumerator DestroyCourantine(float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    protected abstract void Pickup(Player player);

}
