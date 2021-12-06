using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TracksEquippedStatus : MonoBehaviour
{
    PlayerStats playerStats;
    ExpendsMoney selfExpendsMoney;
    Unlockable selfUnlockable;
    SetsSkin selfSetsSkin;
    Text selfText;
    void Start()
    {
        playerStats = PlayerStats.GetInstance();
        selfExpendsMoney = GetComponent<ExpendsMoney>();
        selfUnlockable = GetComponent<Unlockable>();
        selfSetsSkin = GetComponent<SetsSkin>();
        selfText = GetComponentInChildren<Text>();
    }

    void setToLocked() {
        selfText.text = selfExpendsMoney.value.ToString();
    }

    void setToUnlocked() {
        selfText.text = "Select";
    }

    void setToEquipped() {
        selfText.text = "Selected";
    }

    private void Update() {
        if (selfUnlockable.isUnlocked == false) {
            setToLocked();
            return;
        }
        if (selfSetsSkin.skin == playerStats.currentSkin) {
            setToEquipped();
        } else {
            setToUnlocked();
        }
    }
}
