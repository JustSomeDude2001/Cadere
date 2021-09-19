using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D selfRigidbody;

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
        selfRigidbody = GetComponent<Rigidbody2D>();
    }

    Vector2 getKeyboardInput() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            return Vector2.left;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            return Vector2.right;
        }

        return Vector2.zero;
    }

    // Input can wary, hence specific function.
    Vector2 getInput() {
        switch (controllerType) {
            case 0:
                return getKeyboardInput();
        }

        return Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        selfRigidbody.AddForce(getInput() * sensitivity);   
    }
}
