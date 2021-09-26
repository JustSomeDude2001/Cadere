using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public GameObject target;
    public Vector3 observationOffset;


    private Transform targetTransform;
    private Transform selfTransform;
    void Start()
    {
        selfTransform = GetComponent<Transform>();
        targetTransform = target.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        selfTransform.SetPositionAndRotation(targetTransform.position + observationOffset,
                                             selfTransform.rotation);
    }
}
