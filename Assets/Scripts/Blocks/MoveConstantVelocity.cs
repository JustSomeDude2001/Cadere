using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConstantVelocity : MonoBehaviour
{
    public Vector3 movementVector;
    private Rigidbody selfRigidbody;

    void Start() {
        selfRigidbody = GetComponent<Rigidbody>();

        selfRigidbody.velocity = movementVector;
    }
}
