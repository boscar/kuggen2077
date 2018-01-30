using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCamera : MainCamera {

    private const float X_MULTIPLIER = 0.08f;
    private const float Y_MULTIPLIER = 0.25f;
    private const float Z_MULTIPLIER = 0.04f;

    public Transform[] targets;
    public float cameraSpeed = 10.0f;

    private Vector3 BasePosition { get; set; }

    protected new void Awake() {
        base.Awake();
        BasePosition = transform.position;
    }

    void FixedUpdate() {
        if(targets.Length <= 0) {
            return;
        }

        Vector3 targetPoint = GetTargetPoint(targets);
        MoveCamera(Time.fixedDeltaTime, targetPoint);
    }

    private Vector3 GetTargetPoint(Transform[] targets) {
        if (targets.Length == 1) {
            return targets[0].position;
        } else if (targets.Length > 1) {
            Vector3 combinedTargetVector = Vector3.zero;
            foreach (Transform t in targets) {
                combinedTargetVector += t.position;
            }
            combinedTargetVector /= targets.Length;
            return combinedTargetVector;
        }
        return Vector3.zero;
    }

    private void MoveCamera(float deltaTime, Vector3 targetPoint) {
        float xDiffFromBase = targetPoint.x * X_MULTIPLIER;
        float zDiffFromBase = targetPoint.z * Z_MULTIPLIER;
        float yDiffFromBase = zDiffFromBase * Y_MULTIPLIER;

        Vector3 destination = new Vector3(BasePosition.x + xDiffFromBase, BasePosition.y + yDiffFromBase, BasePosition.z + zDiffFromBase);
        transform.position = Vector3.Lerp(transform.position, destination, deltaTime * cameraSpeed);
    }

}
