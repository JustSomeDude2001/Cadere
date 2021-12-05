using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{   
    public string unlockableName;
    public bool isUnlocked = false;

    PlayerStats playerStats;
    void Start()
    {
        playerStats = PlayerStats.GetInstance();
        isUnlocked = PlayerPrefs.GetInt(unlockableName, 0) > 0;
    }

    public void unlock() {
        isUnlocked = true;
        PlayerPrefs.SetInt(unlockableName, 1);
        PlayerPrefs.Save();
    }
}
