using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody selfRigidbody;
    private Gyroscope selfGyroscope;

    private Vector3 screenCenterPoint;

    /*
        0 - Keyboard (DEPRECATED, REMOVE LATER)
        1 - Gyroscope
        2 - Touchscreen
    */
    public static int controllerType = 1;
    /*
        Magnitude of acceleration caused by inputs.
    */
    public float sensitivity;

    // Start is called before the first frame update
    void OnEnable()
    {
        selfRigidbody = GetComponent<Rigidbody>();
        selfGyroscope = Input.gyro;
        selfGyroscope.enabled = true;
        screenCenterPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Debug.Log(screenCenterPoint);
    }

    public void flipControlls() {
        //Flip to touchscreen/flip to gyro
        if (controllerType == 1) {
            controllerType = 2;
            selfGyroscope.enabled = false;
        } else {
            controllerType = 1;
            selfGyroscope.enabled = true;
        }
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
        return new Vector3(selfGyroscope.gravity.x, 0, 0);
    }

    Vector3 getTouchscreenInput() {
        if (Input.touchCount > 0) {

            Touch newTouch = Input.GetTouch(0);

            Vector3 normalizedMovement = new Vector3(newTouch.position.x, newTouch.position.y, 0);

            normalizedMovement.x = (normalizedMovement.x - screenCenterPoint.x) / screenCenterPoint.x;
            normalizedMovement.y = (normalizedMovement.y - screenCenterPoint.y) / screenCenterPoint.y;

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
        selfRigidbody.velocity = (new Vector3(getInput().x * sensitivity,
                                  selfRigidbody.velocity.y, 0));
        // selfRigidbody.AddForce(getInput() * sensitivity);   
    }
}
