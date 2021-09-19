using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Balances velocity of the object to prevent it's staticity,
/// as well as overacceleration.
/// </summary>
public class VelocityBalancer : MonoBehaviour
{
    private Rigidbody2D selfRigidbody;
    public float minY;
    public float maxY;

    public float targetAbsoluteY;
    public float targetAbsoluteYApproachRate;

    // Start is called before the first frame update
    void OnEnable()
    {
        selfRigidbody = GetComponent<Rigidbody2D>();
    }

    // Balancing vertical speed to prevent uncontrollable flight
    private void FixedUpdate() {
        float curX = selfRigidbody.velocity.x;
        float curY = selfRigidbody.velocity.y;

        float addX = float.Epsilon;
        float addY = float.Epsilon;

        bool needChange = false;

        if (curY > maxY) {
            addY = maxY - curY;
            needChange = true;
        }

        if (curY < minY) {
            addY = minY - curY;
            needChange = true;
        }

        if (Mathf.Abs(curY) < targetAbsoluteY) {
            if (Mathf.Abs(addY) <= float.Epsilon) {
                addY = (curY - targetAbsoluteY) * targetAbsoluteYApproachRate;
            }

            needChange = true;
        }

        if (needChange) {
            selfRigidbody.AddForce(new Vector2(addX, addY));
        }
    }
}
