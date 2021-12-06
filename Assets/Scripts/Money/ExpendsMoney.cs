using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpendsMoney : MonoBehaviour
{
    PlayerStats playerStats;

    public int value = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = PlayerStats.GetInstance();
    }

    public bool expendMoney() {
        if (playerStats.money < value) {
            return false;
        }
        playerStats.money -= value;
        PlayerStats.saveGame();

        return true;
    }

}
