using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    public void loadMainMenu() {
        Debug.Log("Exiting to menu");

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
