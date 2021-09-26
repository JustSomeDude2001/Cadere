using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Balances velocity of the object to prevent it's staticity,
/// as well as overacceleration.
/// </summary>
public class VelocityBalancer : MonoBehaviour
{
    private Rigidbody selfRigidbody;
    public static float minY = -10;
    public static float maxY = +10;

    public static float targetAbsoluteY = 8;
    public static float targetAbsoluteYApproachRate = 0.7f;
    public static float restExitModifier = 10;

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("GotSelfBody");
        selfRigidbody = GetComponent<Rigidbody>();
    }

    // Balancing vertical speed to prevent uncontrollable flight
    void FixedUpdate() {

        float curX = selfRigidbody.velocity.x;
        float curY = selfRigidbody.velocity.y;

        float addX = float.Epsilon;
        float addY = float.Epsilon;

        bool needChange = false;

        // Preventing over-acceleration positive
        if (curY > maxY) {
            addY = maxY - curY;
            needChange = true;
        }

        // Preventing over-acceleration negative
        if (curY < minY) {
            addY = minY - curY;
            needChange = true;
        }

        // Preventing vertical momentum decay
        if (Mathf.Abs(curY) < targetAbsoluteY && curY >= -float.Epsilon) {
            addY = (targetAbsoluteY - curY) * targetAbsoluteYApproachRate;
            needChange = true;
        }

        // Preventing full vertical stop
        if (curY >= -float.Epsilon && curY <= float.Epsilon) {
            addY = (targetAbsoluteY - curY) * restExitModifier;
            needChange = true;
        }

        // Applying adjustments if any needed
        if (needChange) {
            selfRigidbody.AddForce(new Vector3(addX, addY, 0f) * selfRigidbody.mass);
        }
    }
}
