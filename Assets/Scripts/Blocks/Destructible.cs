using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public int Durability;
    
    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Player") {
            Durability--;
        }

        if (Durability <= 0) {
            Destroy(this.gameObject);
        }

        Debug.Log("Block Destroyed");
    }
}
