using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HasCooldown : MonoBehaviour
{
    Button selfButton;
    Image selfImage;

    public float cooldown = 3;

    // Start is called before the first frame update
    void Start()
    {
        selfButton = GetComponent<Button>();
        selfImage = GetComponent<Image>();
    }

    bool isOnCooldown = false;

    float remainingCooldown;

    public void startCooldown() {
        selfButton.interactable = false;
        selfImage.enabled = false;
        isOnCooldown = true;
        remainingCooldown = cooldown;
    }

    public void endCooldown() {
        selfButton.interactable = true;
        selfImage.enabled = true;
        isOnCooldown = false;
    }

    private void Update() {
        if(isOnCooldown) {
            remainingCooldown -= Time.deltaTime;
            if (remainingCooldown < 0) {
                endCooldown();
            }
        }
    }
}
