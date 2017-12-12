using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public ControlKeyBindings.ControlScheme controlScheme = ControlKeyBindings.ControlScheme.KEYBOARD;
    public Player player;

    private ControlKeyBindings KeyBindings { get; set; }
    private Vector3 movementInput;
    private Vector3 direction = Vector3.zero;

    protected void Start() {
        InitComponents();
        AssignKeyBindings(controlScheme);
    }

    private void InitComponents() {
        if (player == null) {
            player = GetComponent<Player>();
        }
        if (player == null) {
            throw new KuggenException("Player can not be null for " + this);
        }
    }

    public void AssignKeyBindings(ControlKeyBindings.ControlScheme controlScheme) {
        switch (controlScheme) {
            case ControlKeyBindings.ControlScheme.KEYBOARD :
                KeyBindings = new KeyboardControlKeyBindings();
                break;
            case ControlKeyBindings.ControlScheme.GAMEPAD0:
                KeyBindings = new GamepadOneControlKeyBindings();
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

        if (Input.GetKey(KeyBindings.PrimaryAttack)) {
            player.AttackHandler.Attack(Player.ATTACK_PRIMARY);
        }
    }

}
