using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody selfRigidbody;

    /*
        0 - Keyboard (testing)
        1 - Gyroscope
        2 - Touchscreen
    */
    public int controllerType;
    /*
        Magnitude of acceleration caused by inputs.
    */
    public float sensitivity;

    // Start is called before the first frame update
    void OnEnable()
    {
        selfRigidbody = GetComponent<Rigidbody>();
    }

    Vector3 getKeyboardInput() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            return Vector3.left;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            return Vector3.right;
        }

        return Vector3.zero;
    }

    // Input can wary, hence specific function.
    Vector3 getInput() {
        switch (controllerType) {
            case 0:
                return getKeyboardInput();
            case 1:
                break;
            case 2:
                break;
        }

        return Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        selfRigidbody.AddForce(getInput() * sensitivity);   
    }
}
