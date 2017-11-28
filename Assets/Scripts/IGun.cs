using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGun : MonoBehaviour {

    public bool isFiring;
    public IBulletController bullet;
    public float bulletSpeed;
    public float timeBetweenShot;
    public float damageToGive;
    protected float shotCounter;
    public Transform firePoint;
    public float spread = 3;

}
