using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsMoney : MonoBehaviour
{

    public GameObject moneyTemplate;
    public float moneySpawnChance = 0.1f;

    PlayerStats playerStats;

    void Start()
    {
        playerStats = PlayerStats.GetInstance();
        if (playerStats.globalMoneySpawnChance * moneySpawnChance > Random.Range(0, 1)) {
            GameObject newMoney = GameObject.Instantiate<GameObject>(moneyTemplate, transform);
            AddsMoney addsMoney = newMoney.GetComponent<AddsMoney>();
            addsMoney.value = (int)(addsMoney.value * playerStats.moneyMultiplier);
        }
    }
}
