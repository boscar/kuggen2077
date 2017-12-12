using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler {

    public const string BASIC_MOVEMENT_ID = "basic_movement";

    private IMovable movable { get; set; }

    private Vector3 lastMovementVector = Vector3.zero;

    private Dictionary<string, Vector3> velocities = new Dictionary<string, Vector3>();
    private Dictionary<string, Vector3> floatyVelocities = new Dictionary<string, Vector3>();

    public MovementHandler(IMovable movable) {
        if (movable == null) {
            throw new KuggenException("IMovable can not be null for " + this);
        }
        this.movable = movable;
    }

    public void BasicMove(Vector3 movementDirection) {
		Move(movementDirection * movable.MovementSpeed, BASIC_MOVEMENT_ID, true);
    }


    public void Move(Vector3 velocity, string id, bool useFloatiness) {
        Dictionary<string, Vector3> velocities = useFloatiness ? floatyVelocities : this.velocities;
        if (velocities.ContainsKey(id)) {
            velocities[id] = velocity;
        }else {
            velocities.Add(id, velocity);
        }
    }

    public void Update(float deltaTime) {
        Vector3 totalVelocity = Vector3.zero;

        foreach (KeyValuePair<string, Vector3> velocity in velocities) {
            totalVelocity += velocity.Value;
        }
        totalVelocity += GetTotalFloatyVelocity(deltaTime);

        lastMovementVector = totalVelocity;
        movable.Rigidbody.velocity = totalVelocity;
    }

    private Vector3 GetTotalFloatyVelocity(float deltaTime) {
        Vector3 totalWantedFloatyVelocity = Vector3.zero;
        foreach (KeyValuePair<string, Vector3> velocity in floatyVelocities) {
            totalWantedFloatyVelocity += velocity.Value;
        }
        return Vector3.Lerp(lastMovementVector, totalWantedFloatyVelocity, movable.MovementFloatiness * deltaTime);
    }

}
