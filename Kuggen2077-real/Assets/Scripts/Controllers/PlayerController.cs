﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public ControlKeyBindings.ControlScheme controlScheme = ControlKeyBindings.ControlScheme.KEYBOARD;
    public Player player;
    public Animator anim;


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
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            throw new KuggenException("Animator where unable to instantiate. Be sure to add an Animator Component" + this);
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
            case ControlKeyBindings.ControlScheme.GAMEPAD1:
                KeyBindings = new GamepadTwoControlKeyBindings();
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
        if (controlScheme != ControlKeyBindings.ControlScheme.KEYBOARD) {
            //Gamepad
            HandleAttackGamepad(Time.fixedDeltaTime);
        } else
        {
            //Keyboard
            HandleAttack(Time.fixedDeltaTime);
        }
        
    }

    private void HandleMovement(float deltaTime) {
        if((KeyBindings is GamepadOneControlKeyBindings || KeyBindings is GamepadTwoControlKeyBindings) && direction.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        } else if(KeyBindings is KeyboardControlKeyBindings)
        {
            transform.LookAt(direction);
        }

        if (player.MovementHandler == null) {
            return;
        }
        if(anim != null)
        {
            if (movementInput != Vector3.zero)
            {
                player.AnimationHandler.Move();
                //anim.SetBool("isRunning", true);
            }
            else
            {
                player.AnimationHandler.Idle();
             //   anim.SetBool("isRunning", false);
            }
        }
      
        player.MovementHandler.BasicMove(movementInput);


    }

    private void HandleAttack(float deltaTime)
    {

        if (Input.GetKey(KeyBindings.PrimaryAbility))
        {
            player.DashAbility.Activate(player, player, movementInput);
        }
        
        if (Input.GetKey(KeyBindings.PrimaryAttack))
        {
            AttackAction primaryAttackAction = player.AttackActions[Player.ATTACK_PRIMARY];
            if (primaryAttackAction != null)
            {
                primaryAttackAction.InitAttack();
            }
        }
    }

    private void HandleAttackGamepad(float deltaTime)
    {
        if(Input.GetAxis(KeyBindings.PrimaryAbilityAxisID) > 0)
        {
            player.DashAbility.Activate(player, player, movementInput);
        }

        if(Input.GetAxis(KeyBindings.PrimaryAttackAxisID) > 0)
        {
            AttackAction primaryAttackAction = player.AttackActions[Player.ATTACK_PRIMARY];
            if (primaryAttackAction != null)
            {
                primaryAttackAction.InitAttack();
            }
        }
      
    }

}
