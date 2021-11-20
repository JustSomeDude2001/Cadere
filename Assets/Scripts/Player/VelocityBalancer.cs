using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Balances velocity of the object to prevent it's staticity,
/// as well as overacceleration.
/// </summary>
public class VelocityBalancer : MonoBehaviour
{
    private PlayerStats stats;
    private Rigidbody selfRigidbody;

    // Start is called before the first frame update
    void OnEnable()
    {
        stats = PlayerStats.GetInstance();
        Debug.Log("GotSelfBody");
        selfRigidbody = GetComponent<Rigidbody>();
    }

    // Balancing vertical speed to prevent uncontrollable flight
    void FixedUpdate() {

        float curXSpeed = selfRigidbody.velocity.x;
        float curYSpeed = selfRigidbody.velocity.y;

        float addXSpeed = float.Epsilon;
        float addYSpeed = float.Epsilon;

        bool needChange = false;

        // Preventing over-acceleration positive
        if (curYSpeed > stats.maxYSpeed) {
            addYSpeed = stats.maxYSpeed - curYSpeed;
            needChange = true;
        }

        // Preventing over-acceleration negative
        if (curYSpeed < stats.minYSpeed) {
            addYSpeed = stats.minYSpeed - curYSpeed;
            needChange = true;
        }

        // Preventing vertical momentum decay
        if (Mathf.Abs(curYSpeed) < stats.targetAbsoluteYSpeed && curYSpeed >= -float.Epsilon) {
            addYSpeed = (stats.targetAbsoluteYSpeed - curYSpeed) * stats.targetAbsoluteYSpeedApproachRate;
            needChange = true;
        }

        // Preventing full vertical stop
        if (curYSpeed >= -float.Epsilon && curYSpeed <= float.Epsilon) {
            addYSpeed = (stats.targetAbsoluteYSpeed - curYSpeed) * stats.restExitModifier;
            needChange = true;
        }

        // Applying adjustments if any needed
        if (needChange) {
            selfRigidbody.AddForce(new Vector3(addXSpeed, addYSpeed, 0f) * selfRigidbody.mass);
        }
    }
}
