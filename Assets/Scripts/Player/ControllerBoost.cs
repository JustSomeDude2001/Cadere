using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBoost : MonoBehaviour
{
    private PlayerStats stats;
    private Rigidbody selfRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        stats = PlayerStats.GetInstance();
        selfRigidbody = GetComponent<Rigidbody>();
    }

    public void boost() {
        if (selfRigidbody.velocity.y > 0) {
            Vector3 targetVelocity = selfRigidbody.velocity;
            targetVelocity.y = -1f * stats.boostRate;
            selfRigidbody.AddForce(targetVelocity - selfRigidbody.velocity, ForceMode.Impulse);
        }
    }
}
