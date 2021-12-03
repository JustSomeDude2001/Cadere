using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpendsMoney : MonoBehaviour
{
    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = PlayerStats.GetInstance();
    }

    

}
