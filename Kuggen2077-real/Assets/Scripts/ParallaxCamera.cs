using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCamera : MainCamera {

    private const float X_POS_MULTIPLIER = 0.06f;
    private const float Y_POS_MULTIPLIER = 0.17f;
    private const float Z_POS_MULTIPLIER = 0.03f;

    private const float X_ROT_MULTIPLIER = 0.75f;
    private const float Z_ROT_MULTIPLIER = -0.1f;

    public Transform[] targets;
    public float cameraSpeed = 10.0f;

    private Vector3 BasePosition { get; set; }
    private Quaternion BaseRotation { get; set; }

    protected new void Awake() {
        base.Awake();
        BasePosition = transform.position;
        BaseRotation = transform.rotation;
    }

    void FixedUpdate() {
        if(targets.Length <= 0) {
            return;
        }

        Vector3 targetPoint = GetTargetPoint(targets);
        ApplyCameraToTarget(Time.fixedDeltaTime, targetPoint);
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

    private void ApplyCameraToTarget(float deltaTime, Vector3 targetPoint) {
        MoveCamera(Time.fixedDeltaTime, targetPoint);
        TiltCamera(Time.fixedDeltaTime, targetPoint);
    }

    private void MoveCamera(float deltaTime, Vector3 targetPoint) {
        float xDiffFromBase = targetPoint.x * X_POS_MULTIPLIER;
        float zDiffFromBase = targetPoint.z * Z_POS_MULTIPLIER;
        float yDiffFromBase = zDiffFromBase * Y_POS_MULTIPLIER;

        Vector3 destination = new Vector3(BasePosition.x + xDiffFromBase, BasePosition.y + yDiffFromBase, BasePosition.z + zDiffFromBase);
        transform.position = Vector3.Lerp(transform.position, destination, deltaTime * cameraSpeed);
    }

    private void TiltCamera(float deltaTime, Vector3 targetPoint) {
        float yzDiff = targetPoint.x * X_ROT_MULTIPLIER;
        float xDiff = targetPoint.z * Z_ROT_MULTIPLIER;
        
        Quaternion destinationRotation = Quaternion.Euler(BaseRotation.eulerAngles.x + xDiff, 
            BaseRotation.eulerAngles.y + yzDiff,
            BaseRotation.eulerAngles.z + yzDiff);
        transform.rotation = Quaternion.Lerp(transform.rotation, destinationRotation, deltaTime * cameraSpeed);
    }

}
