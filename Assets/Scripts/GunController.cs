using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public bool isFiring;
	public IBulletController bullet;
	public float bulletSpeed;
	public float timeBetweenShot;
	public int damageToGive;
	private float shotCounter;
	public Transform firePoint;

	// Use this for initialization
	void Start () {
		
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
			IBulletController newBullet = Instantiate<IBulletController> (bullet, firePoint.position, firePoint.rotation);
			newBullet.speed = bulletSpeed;
			newBullet.damageToGive = damageToGive;

		}
	}
}
