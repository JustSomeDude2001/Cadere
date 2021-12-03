using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddsMoney : MonoBehaviour
{
    PlayerStats playerStats;

    public int value = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = PlayerStats.GetInstance();
    }

    public void addMoney() {
        playerStats.money += value;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            addMoney();
        }
    }
}
