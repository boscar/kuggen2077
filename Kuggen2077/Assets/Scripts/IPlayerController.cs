using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPlayerController : MonoBehaviour {

    public IGun theGun;
    public float floatiness = 8;
    protected Vector3 lastMovementVector = Vector3.zero;

    protected Vector3 GetMovementVector (Vector3 wantedMovementVector, float deltaTime) {
        Vector3 movementVector = Vector3.Lerp(lastMovementVector, wantedMovementVector, floatiness * deltaTime);
        lastMovementVector = movementVector;
        return movementVector;
    }

}
