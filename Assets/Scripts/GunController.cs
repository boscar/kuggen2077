using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : IGun {
	
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
		}
	}
}
