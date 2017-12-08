using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public ControllKeyBindings.ControllScheme controllScheme = ControllKeyBindings.ControllScheme.KEYBOARD;
    public Player player;

    private ControllKeyBindings KeyBindings { get; set; }
    private Vector3 movementInput;

    protected void Start() {
        InitComponents();
        AssignKeyBindings(controllScheme);
    }

    private void InitComponents() {
        if (player == null) {
            player = GetComponent<Player>();
        }
        if (player == null) {
            throw new KuggenException("Player can not be null for " + this);
        }
    }

    public void AssignKeyBindings(ControllKeyBindings.ControllScheme controllScheme) {
        switch (controllScheme) {
            case ControllKeyBindings.ControllScheme.KEYBOARD :
                KeyBindings = new KeyboardControllKeyBindings();
                break;
            default : break;
        }

    }

    protected void Update() {
        movementInput = new Vector3(Input.GetAxisRaw(KeyBindings.HoriszontalAxisID), 0f, Input.GetAxisRaw(KeyBindings.VerticalAxisID));

        Ray cameraRay = MainCamera.Instance.Camera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength)) {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    protected void FixedUpdate() {
        HandleMovement(Time.fixedDeltaTime);
    }

    private void HandleMovement(float deltaTime) {
        if (player.MovementHandler == null) {
            return;
        }

        player.MovementHandler.BasicMove(movementInput);

        if (Input.GetKey(KeyBindings.PrimaryAbility)) {
            player.DashAbility.Activate(player, player, movementInput);
        }
    }

}
