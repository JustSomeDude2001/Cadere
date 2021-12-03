using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            GameObject.Destroy(gameObject);
        }
    }
}
