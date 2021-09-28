using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{
    public void stopGame() {
        Debug.Log("Exiting to menu");

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
