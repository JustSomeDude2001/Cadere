using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{
    public void stopGame() {
        Debug.Log("Exiting to menu");

        PlayerPrefs.SetInt("Money", PlayerStats.GetInstance().money);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
