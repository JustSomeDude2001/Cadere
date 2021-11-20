using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private PlayerStats stats;
    private Rigidbody selfRigidbody;
    private Vector3 screenCenterPoint;

    /*
        All deprecated controls removed.
        Only touchscreen controls.
    */

    /*
        Magnitude multiplier of acceleration caused by inputs.
    */

    void OnEnable()
    {
        stats = PlayerStats.GetInstance();
        selfRigidbody = GetComponent<Rigidbody>();
        screenCenterPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Debug.Log(screenCenterPoint);
    }

    public void setSensitivity(int newSensitivity) {
        stats.sensitivity = newSensitivity;
    }

    Vector3 getInput() {
        if (Input.touchCount > 0) {

            Touch newTouch = Input.GetTouch(0);

            Vector3 normalizedMovement = new Vector3(newTouch.position.x, 0, 0);

            normalizedMovement.x = (normalizedMovement.x - screenCenterPoint.x) / screenCenterPoint.x;

            return normalizedMovement;
        }

        return Vector3.zero;
    }

    void obtainHorizontalEffect() {
        //TO-DO
        // Move current horizontal logic of user input here.
    }

    void obtainVerticalEffect() {
        //TO-DO
        // Implement braking dependent on vertical position of the finger.
    }

    void FixedUpdate()
    {
        Vector3 newVelocity = selfRigidbody.velocity;
        newVelocity.x = getInput().x * stats.sensitivity;

        Vector3 oldVelocity = selfRigidbody.velocity;

        Vector3 deltaVelocity = newVelocity - oldVelocity;

        selfRigidbody.AddForce(deltaVelocity, ForceMode.Force);
        //selfRigidbody.velocity = (new Vector3(getInput().x * sensitivity,
        //                          selfRigidbody.velocity.y, 0));
        // selfRigidbody.AddForce(getInput() * sensitivity);   
    }
}
