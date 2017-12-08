using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public ControllKeyBindings.ControllScheme controllScheme = ControllKeyBindings.ControllScheme.KEYBOARD;
    public Player player;

    private ControllKeyBindings KeyBindings { get; set; }
    private Vector3 movementInput;
    private Vector3 direction = Vector3.zero;

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
        movementInput = new Vector3(Input.GetAxisRaw(KeyBindings.HoriszontalAxisID), 0f, Input.GetAxisRaw(KeyBindings.VerticalAxisID)).normalized;
        direction = KeyBindings.GetDirection(transform);
    }

    protected void FixedUpdate() {
        HandleMovement(Time.fixedDeltaTime);
    }

    private void HandleMovement(float deltaTime) {
        transform.LookAt(direction);

        if (player.MovementHandler == null) {
            return;
        }

        player.MovementHandler.BasicMove(movementInput);

        if (Input.GetKey(KeyBindings.PrimaryAbility)) {
            player.DashAbility.Activate(player, player, movementInput);
        }
    }

}
