using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowsMoney : MonoBehaviour
{
    PlayerStats playerStats;
    Text selfText;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = PlayerStats.GetInstance();
        selfText = GetComponent<Text>();
    }

    private void Update() {
        selfText.text = (playerStats.money).ToString();
    }

}
