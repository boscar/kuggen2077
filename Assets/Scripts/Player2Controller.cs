using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : IPlayerController {

	public float moveSpeed;
	private Rigidbody myRigidBody;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	private Camera mainCamera;

    private bool spaceDown = false;
    private bool dashing = false;
    private Vector3 dashVelocity;
    public float dashSpeed = 7;
    public float dashDuration = 0.3f;
    private float dashTimer = 0;

    public bool useController;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody> ();
		mainCamera = FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal2"), 0f, -Input.GetAxisRaw ("Vertical2"));
		moveVelocity = moveInput * moveSpeed;

        if (!useController) {
            HandleKeyboardControls();
        } else {
            HandleControllerControls();
        }
	}

	void FixedUpdate () {
        if(dashing) {
            HandleDash(Time.fixedDeltaTime);
        } else {
            myRigidBody.velocity = moveVelocity;
        }
	}

    private void HandleDash(float deltaTime) {
        dashTimer += deltaTime;
        if(dashTimer > dashDuration) {
            dashing = false;
            dashTimer = 0;
            return;
        }
        myRigidBody.velocity = dashVelocity * Mathf.Pow((1 - (dashTimer / dashDuration)), 1.5f);
    }

	public void changeGun(float bulletSpeed, float timeBetweenShot, float damageToGive){
		Debug.Log ("changeGun");
		theGun.bulletSpeed = bulletSpeed;
		theGun.timeBetweenShot = timeBetweenShot;
		theGun.damageToGive = (int)damageToGive;
	}

    private void HandleKeyboardControls() {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength)) {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0)) {
            theGun.isFiring = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            theGun.isFiring = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !spaceDown && !dashing) {
            spaceDown = true;
            dashing = true;
            dashVelocity = moveInput * dashSpeed;
        }

        if (Input.GetKeyUp(KeyCode.Space) && spaceDown) {
            spaceDown = false;
        }
    }

    private void HandleControllerControls() {
        Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal2") + Vector3.forward * -Input.GetAxisRaw("RVertical2");
        if (playerDirection.sqrMagnitude > 0.0f) {
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            theGun.isFiring = true;
        } 
        else {
            theGun.isFiring = false;
        }

        /*if (Input.GetAxis("RAxis2") > 0) {
            theGun.isFiring = true;
        }

        if (Input.GetAxis("RAxis2") <= 0) {
            theGun.isFiring = false;
        }*/

        if (Input.GetAxis("LAxis2") > 0 && !spaceDown && !dashing) {
            spaceDown = true;
            dashing = true;
            dashVelocity = moveInput * dashSpeed;
        }

        if (Input.GetAxis("LAxis2") <= 0 && spaceDown) {
            spaceDown = false;
        }
    }
		
}
