using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private static PlayerStats instance;

    public float brakeRate = 0.5f;
    public float boostRate = 25f;

    public float minYSpeed = -10;
    public float maxYSpeed = +10;

    public float targetAbsoluteYSpeed = +8;

    public float targetAbsoluteYSpeedApproachRate = 0.7f;

    public float restExitModifier = 10;

    public float sensitivity = 30;

    public int money = 0;

    public float globalMoneySpawnChance = 1;
    public float moneyMultiplier = 1;

    public string currentSkin = "SkinSphere";

    public List<GameObject> availableSkins;
    public Color currentColor;

    private PlayerStats() {
        float red = PlayerPrefs.GetFloat("Red", 0);
        float gre = PlayerPrefs.GetFloat("Gre", 0);
        float blu = PlayerPrefs.GetFloat("Blu", 0);
        currentColor = new Color(red, gre, blu);
        PlayerPrefs.SetInt("SkinSphere", 1);
        money = PlayerPrefs.GetInt("Money", 0);
        currentSkin = PlayerPrefs.GetString("Skin", "SkinSphere");
        availableSkins = new List<GameObject>(Resources.LoadAll<GameObject>(""));
        Debug.Log("Resources loaded:" + availableSkins.Count);
        foreach(GameObject x in availableSkins) {
            Debug.Log(x.name);
        }
    }

    public static PlayerStats GetInstance() {
        if (instance == null) {
            instance = new PlayerStats();
        }
        return instance;
    }

    public static void refresh() {
        instance.money = PlayerPrefs.GetInt("Money", 0);
        instance.currentSkin = PlayerPrefs.GetString("Skin", "SkinSphere");
        instance.availableSkins = new List<GameObject>(Resources.LoadAll<GameObject>(""));
    }

    public static void saveGame() {
        PlayerPrefs.SetInt("Money", instance.money);
        PlayerPrefs.SetString("Skin", instance.currentSkin);
        float red = instance.currentColor.r;
        float gre = instance.currentColor.g;
        float blu = instance.currentColor.b;
        PlayerPrefs.SetFloat("Red", red);
        PlayerPrefs.SetFloat("Gre", gre);
        PlayerPrefs.SetFloat("Blu", blu);        
        PlayerPrefs.Save();
    }

}
