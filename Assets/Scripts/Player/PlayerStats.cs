using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerStats
{
    private static PlayerStats instance;

    public float brakeRate = 0.5f;

    public float minYSpeed = -10;
    public float maxYSpeed = +10;

    public float targetAbsoluteYSpeed = +8;

    public float targetAbsoluteYSpeedApproachRate = 0.7f;

    public float restExitModifier = 10;

    public float sensitivity = 30;

    public int money = 0;

    public float globalMoneySpawnChance = 1;
    public float moneyMultiplier = 1;

    private PlayerStats() {
        money = PlayerPrefs.GetInt("Money", 0);
    }

    public static PlayerStats GetInstance() {
        if (instance == null) {
            instance = new PlayerStats();
        }        
        return instance;
    }

}
