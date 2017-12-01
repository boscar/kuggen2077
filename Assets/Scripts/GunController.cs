using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : IGun {

	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource> ();
		Debug.Log (source.ToString ());
	}
	
	// Update is called once per frame
	void Update () {
		if (isFiring == false) {
			shotCounter = 0;
			return;
		}

		shotCounter -= Time.deltaTime;
		if (shotCounter <= 0) {
			shotCounter = timeBetweenShot;
            float rotY = firePoint.rotation.eulerAngles.y + ((Random.value * (2 * spread)) - spread);
            Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
			IBulletController newBullet = Instantiate<IBulletController> (bullet, firePoint.position, bulletRotation);
            newBullet.speed = bulletSpeed;
			newBullet.damageToGive = damageToGive;

			source.pitch = 0.9f + (Random.value * 0.2f);
			source.Play ();
		}
	}
}
