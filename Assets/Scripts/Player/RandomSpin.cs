using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class RandomSpin : MonoBehaviour
{
    Rigidbody selfRigidBody;

    void randomizeRotation() {
        selfRigidBody = GetComponent<Rigidbody>();
        selfRigidBody.angularVelocity = UnityEngine.Random.insideUnitSphere * Math.Max(selfRigidBody.velocity.sqrMagnitude, 1);
    }

    void Start() {
        randomizeRotation();
    }

    private void OnCollisionEnter(Collision other) {
        randomizeRotation();
    }
}
