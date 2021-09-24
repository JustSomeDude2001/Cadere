using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public GameObject target;
    private Vector3 observationOffset;


    private Transform targetTransform;
    private Transform selfTransform;
    void Start()
    {
        selfTransform = GetComponent<Transform>();
        targetTransform = target.GetComponent<Transform>();

        observationOffset = selfTransform.position - targetTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

        selfTransform.SetPositionAndRotation(targetTransform.position + observationOffset,
                                             selfTransform.rotation);
    }
}
