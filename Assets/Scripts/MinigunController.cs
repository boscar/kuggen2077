using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunController : IGun {

	private AudioSource source;

    void Start() {
        spread = 2;
        bulletSpeed = 20f;
        timeBetweenShot = 0.05f;
        damageToGive = 0.2f;

		source = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update() {
        if (isFiring == false) {
            shotCounter = 0;
            return;
        }

        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0) {
            int amount = 1 + (int)(Random.value * 2);
            for(int i = 0; i < amount; ++i) {
                SpawnBullet();
            }

			source.pitch = 0.95f + (Random.value * 0.1f);
			source.Play ();
        }
    }

    private void SpawnBullet() {
        shotCounter = timeBetweenShot;
        float rotY = firePoint.rotation.eulerAngles.y + ((Random.value * (2 * spread)) - spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        IBulletController newBullet = Instantiate<IBulletController>(bullet, firePoint.position, bulletRotation);
        newBullet.speed = bulletSpeed;
        newBullet.damageToGive = damageToGive;
    }
}
