using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IS TEMPORARY IMPLEMENTATION. See Controller.cs
/// </summary>
public class ControllerBrakes : MonoBehaviour
{
    public float brakingRate = 0.5f;
    private Rigidbody selfRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
    }

    public void brake() {
        selfRigidbody.velocity *= brakingRate;
    }
}
