using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody selfRigidbody;
    private Vector3 screenCenterPoint;

    /*
        0 - Keyboard (DEPRECATED, REMOVE LATER)
        1 - Gyroscope
        2 - Touchscreen
    */
    public static int controllerType = 1;

    /*
        Magnitude multiplier of acceleration caused by inputs.
    */
    public static int sensitivity = 40;

    // Start is called before the first frame update
    void OnEnable()
    {
        selfRigidbody = GetComponent<Rigidbody>();
        screenCenterPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Debug.Log(screenCenterPoint);
    }

    public void setSensitivity(int newSensitivity) {
        sensitivity = newSensitivity;
    }

    Vector3 getKeyboardInput() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            return Vector3.left;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            return Vector3.right;
        }

        return Vector3.zero;
    }

    Vector3 getGyroscopeInput() {
        return new Vector3((Input.acceleration).normalized.x, 0, 0);
    }

    Vector3 getTouchscreenInput() {
        if (Input.touchCount > 0) {

            Touch newTouch = Input.GetTouch(0);

            Vector3 normalizedMovement = new Vector3(newTouch.position.x, 0, 0);

            normalizedMovement.x = (normalizedMovement.x - screenCenterPoint.x) / screenCenterPoint.x;

            return normalizedMovement;
        }

        return Vector3.zero;
    }

    // Input can wary, hence specific function.
    Vector3 getInput() {
        switch (controllerType) {
            case 0:
                return getKeyboardInput();
            case 1:
                return getGyroscopeInput();
            case 2:
                return getTouchscreenInput();
        }

        return Vector2.zero;
    }

    void FixedUpdate()
    {
        Vector3 newVelocity = selfRigidbody.velocity;
        newVelocity.x = getInput().x * sensitivity;

        Vector3 oldVelocity = selfRigidbody.velocity;

        Vector3 deltaVelocity = newVelocity - oldVelocity;

        selfRigidbody.AddForce(deltaVelocity * selfRigidbody.mass);
        //selfRigidbody.velocity = (new Vector3(getInput().x * sensitivity,
        //                          selfRigidbody.velocity.y, 0));
        // selfRigidbody.AddForce(getInput() * sensitivity);   
    }
}
