using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTrigger : MonoBehaviour
{
    public GameObject triggerBlock;
    public GameObject ghostBlock;

    private Vector3 targetPosition;

    public float targetApproachRate;

    private Transform selfTransform;
    private bool finishedMovement = false;
    private const float MOVEMENT_EPSILON = (float)0.00001; // Not using float.Epsilon due to too much precision.
    void OnEnable() {
        selfTransform = GetComponent<Transform>();

        targetPosition = ghostBlock.GetComponent<Transform>().position;
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

        Vector3 currentPosition = selfTransform.position;
        Vector3 movementVector = (targetPosition - currentPosition) * targetApproachRate;

        Vector3 nextPosition = currentPosition + movementVector;

        if (movementVector.magnitude <= MOVEMENT_EPSILON) {
            nextPosition = targetPosition;
            finishedMovement = true;
            Debug.Log("Moving Block Finished Moving");
        }

        Vector3 finalPosition = nextPosition;

        selfTransform.position = finalPosition;
    }
}
