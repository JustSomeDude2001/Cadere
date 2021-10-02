using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTrigger : MonoBehaviour
{
    public GameObject triggerBlock;
    public GameObject ghostBlock;

    private Vector3 targetDisplacement;

    public float targetApproachRate;

    private Transform selfTransform;
    private bool finishedDisplacement = false;
    private const float MOVEMENT_EPSILON = (float)0.00001; // Not using float.Epsilon due to too much precision.


    void Start() {
        selfTransform = GetComponent<Transform>();

        targetDisplacement = ghostBlock.GetComponent<Transform>().position - 
                             selfTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (finishedDisplacement) {
            return;
        }

        if (triggerBlock != null) {
            return;
        }

        Vector3 currentPosition = selfTransform.position;
        Vector3 movementVector = targetDisplacement * targetApproachRate;

        Vector3 nextPosition = currentPosition + movementVector;

        if (movementVector.magnitude <= MOVEMENT_EPSILON) {
            nextPosition = selfTransform.position + targetDisplacement;
            finishedDisplacement = true;
            Debug.Log("Moving Block Finished Moving");
        }

        targetDisplacement -= movementVector;

        Vector3 finalPosition = nextPosition;

        selfTransform.position = finalPosition;
    }
}
