using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : IGun {

    public int amountOfBullets = 10;

	private AudioSource source;

    void Start() {
        spread = 30;
        bulletSpeed = 20f;
        timeBetweenShot = 1;
        damageToGive = 1;

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
            for(int i = 0; i < amountOfBullets; ++i) {
                Invoke("SpawnBullet", Random.value * 0.05f);
            }

			source.pitch = 0.9f + (Random.value * 0.2f);
			source.Play ();
        }
    }

    private void SpawnBullet() {
        shotCounter = timeBetweenShot;
        float rotY = firePoint.rotation.eulerAngles.y + ((Random.value * (2 * spread)) - spread);
        Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, rotY, 0));
        IBulletController newBullet = Instantiate<IBulletController>(bullet, firePoint.position, bulletRotation);
        Destroy(newBullet.gameObject, 0.35f);
        newBullet.speed = bulletSpeed;
        newBullet.damageToGive = damageToGive;
    }
}
