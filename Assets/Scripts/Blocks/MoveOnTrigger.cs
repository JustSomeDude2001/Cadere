using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTrigger : MonoBehaviour
{
    public GameObject triggerBlock;
    public GameObject ghostBlock;

    private Vector2 targetPosition;

    public float targetApproachRate;

    private Transform selfTransform;
    private bool finishedMovement = false;
    private const float MOVEMENT_EPSILON = (float)0.00001; // Not using float.Epsilon due to too much precision.
    void OnEnable() {
        selfTransform = GetComponent<Transform>();

        Vector3 targetPosition3D = ghostBlock.GetComponent<Transform>().position;

        targetPosition = new Vector2(targetPosition3D.x, targetPosition3D.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (finishedMovement) {
            return;
        }

        if (triggerBlock != null) {
            return;
        }

        Vector2 currentPosition = new Vector2(selfTransform.position.x, selfTransform.position.y);

        Vector2 movementVector = (targetPosition - currentPosition) * targetApproachRate;

        Vector2 nextPosition = currentPosition + movementVector;

        if (movementVector.magnitude <= MOVEMENT_EPSILON) {
            nextPosition = targetPosition;
            finishedMovement = true;
            Debug.Log("Moving Block Finished Moving");
        }

        Vector3 finalPosition = new Vector3(nextPosition.x, nextPosition.y, 0);

        selfTransform.position = finalPosition;
    }
}
