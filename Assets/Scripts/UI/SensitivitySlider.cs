using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    private Slider selfSlider;

    void OnEnable() {
        selfSlider = GetComponent<Slider>();
        selfSlider.value = Controller.sensitivity;
    }

    public void changeSensitivity() {
        Controller.sensitivity = (int)selfSlider.value;
        // Debug.Log(Controller.sensitivity);
    }
}
