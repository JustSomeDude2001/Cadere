using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsChanger : MonoBehaviour
{
    public void flipControlls() {
        //Flip to touchscreen/flip to gyro
        if (Controller.controllerType == 1) {
            Controller.controllerType = 2;
        } else {
            Controller.controllerType = 1;
        }
    }
}
