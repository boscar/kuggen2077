using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public bool isFiring;
	public BulletController bullet;
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
			BulletController newBullet = Instantiate (bullet, firePoint.position, firePoint.rotation) as BulletController;
			newBullet.speed = bulletSpeed;
			newBullet.damageToGive = damageToGive;

		}
	}
}
