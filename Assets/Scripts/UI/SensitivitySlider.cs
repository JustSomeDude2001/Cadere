using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    PlayerStats stats;
    private Slider selfSlider;

    void OnEnable() {
        stats = PlayerStats.GetInstance();
        selfSlider = GetComponent<Slider>();
        selfSlider.value = stats.sensitivity;
    }

    public void changeSensitivity() {
        stats.sensitivity = (int)selfSlider.value;
        // Debug.Log(Controller.sensitivity);
    }
}
