using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUnloader : MonoBehaviour
{
    void OnTriggerExit(Collider other) {
        GameObject leavingObject = other.gameObject;

        Destroy(leavingObject);
    }
}
