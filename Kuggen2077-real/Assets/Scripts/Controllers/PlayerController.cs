using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Player player;

    private Vector3 movementInput;
    private DashEffectCreator dashEffect = new DashEffectCreator();

    protected void Start() {
        if (player == null) {
            player = GetComponent<Player>();
        }
    }

    private void InitComponents() {
        if (player == null) {
            player = GetComponent<Player>();
        }
        if (player == null) {
            throw new KuggenException("Player can not be null for " + this);
        }
    }

    protected void Update() {
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

    protected void FixedUpdate() {
        player.MovementHandler.BasicMove(movementInput);

        if(Input.GetKeyUp(KeyCode.Space)) {
            dashEffect.Activate(player, player, movementInput);
        }
    }

}
