using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IS TEMPORARY IMPLEMENTATION. See Controller.cs
/// </summary>
public class ControllerBrakes : MonoBehaviour
{
    private PlayerStats stats;
    private Rigidbody selfRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        stats = PlayerStats.GetInstance();
        selfRigidbody = GetComponent<Rigidbody>();
    }

    public void brake() {
        selfRigidbody.velocity *= stats.brakeRate;
    }
}
