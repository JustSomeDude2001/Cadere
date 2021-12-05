using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetsSkin : MonoBehaviour
{
    PlayerStats playerStats;

    public string skin;
    Unlockable selfUnlockable;
    ExpendsMoney selfExpendsMoney;

    void Start()
    {
        playerStats = PlayerStats.GetInstance();
        selfUnlockable = GetComponent<Unlockable>();
        selfExpendsMoney = GetComponent<ExpendsMoney>();
    }

    public void setSkin() {
        if(selfUnlockable.isUnlocked == false) {
            if(selfExpendsMoney.expendMoney() == false) {
                return;
            }
        }
        Debug.Log("Set skin to" + skin);
        playerStats.currentSkin = skin;
        PlayerStats.saveGame();
    }
}
